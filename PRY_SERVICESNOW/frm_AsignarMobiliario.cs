using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRY_SERVICESNOW
{
    public partial class frm_AsignarMobiliario : Form
    {


        // VARIABLES INTERNAS DEL FORMULARIO
        int id_asignacionSeleccionada = 0;
        int id_mobiliarioSeleccionado = 0;
        int cantidadOriginal = 0;

        public frm_AsignarMobiliario()
        {
            InitializeComponent();
        }

        private void frm_AsignarMobiliario_Load(object sender, EventArgs e)
        {
            cls_AsignarMobiliario asignacion = new cls_AsignarMobiliario();

            // Cargar salas
            cmb_sala.DataSource = asignacion.CargarSalas();
            cmb_sala.DisplayMember = "nombre";
            cmb_sala.ValueMember = "id_sala";

            // Cargar mobiliario
            cmb_mobiliario.DataSource = asignacion.CargarMobiliario();
            cmb_mobiliario.DisplayMember = "nombre";
            cmb_mobiliario.ValueMember = "id_mobiliario";

            // Cargar asignaciones
            CargarAsignaciones();
        }

        private void CargarAsignaciones()
        {
            cls_AsignarMobiliario asignacion = new cls_AsignarMobiliario();
            dgv_mobiliario.DataSource = asignacion.CargarDataGrid();
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            cls_AsignarMobiliario asignacion = new cls_AsignarMobiliario();
            dgv_mobiliario.DataSource = asignacion.Buscar(txt_buscar.Text.Trim());
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            cls_AsignarMobiliario asignacion = new cls_AsignarMobiliario();

            asignacion.Id_sala = Convert.ToInt32(cmb_sala.SelectedValue);
            asignacion.Id_mobiliario = Convert.ToInt32(cmb_mobiliario.SelectedValue);
            asignacion.cantidad_pasada = Convert.ToInt32(nud_cantidad.Value);
            asignacion.Folio = "FOLIO-" + Guid.NewGuid().ToString().Substring(0, 4);

            // Validación
            bool valido = asignacion.ValidarAsignacion(
                asignacion.Id_sala,
                asignacion.Id_mobiliario,
                asignacion.cantidad_pasada
            );

            if (!valido)
                return;

            // Guardar
            string msg = asignacion.GuardarAsignacion();
            MessageBox.Show(msg);

            // Recargar grid
            CargarAsignaciones();
        }

        private void dgv_mobiliario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgv_mobiliario.Rows[e.RowIndex];

            id_asignacionSeleccionada = Convert.ToInt32(fila.Cells["id_asignacionM"].Value);
            id_mobiliarioSeleccionado = Convert.ToInt32(fila.Cells["id_mobiliario"].Value);
            cantidadOriginal = Convert.ToInt32(fila.Cells["cantidad_pasada"].Value);

            txt_sala.Text = fila.Cells["Sala"].Value.ToString();
            txt_mobiliario.Text = fila.Cells["Mobiliario"].Value.ToString();
            txt_cantidad.Text = cantidadOriginal.ToString();
            txt_folio.Text = fila.Cells["Folio"].Value.ToString();

            txt_sala.ReadOnly = true;
            txt_mobiliario.ReadOnly = true;
            txt_folio.ReadOnly = true;
            txt_cantidad.ReadOnly = false;
        }

        private void btn_modifi_Click(object sender, EventArgs e)
        {
            if (id_asignacionSeleccionada == 0)
            {
                MessageBox.Show("Selecciona una asignación primero.");
                return;
            }

            int cantidadNueva = Convert.ToInt32(txt_cantidad.Text);

            cls_AsignarMobiliario asignacion = new cls_AsignarMobiliario();

            // Inventario total
            int inventario = asignacion.ObtenerInventario(id_mobiliarioSeleccionado);

            // Total asignado actualmente
            int asignado = asignacion.ObtenerCantidadAsignada(id_mobiliarioSeleccionado);

            // Disponible considerando modificación
            int disponible = inventario - (asignado - cantidadOriginal);

            if (cantidadNueva > disponible)
            {
                MessageBox.Show("Inventario agotado. No puedes asignar más mobiliario.");
                return;
            }

            // Modificar
            asignacion.id_asignacionM = id_asignacionSeleccionada;
            asignacion.cantidad_pasada = cantidadNueva;

            if (asignacion.ModificarCantidad())
            {
                MessageBox.Show("Cantidad modificada correctamente.");
                CargarAsignaciones();
            }
            else
            {
                MessageBox.Show("Error al modificar.");
            }
        }



    }
}
