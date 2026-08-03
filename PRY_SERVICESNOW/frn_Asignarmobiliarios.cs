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
    public partial class frn_Asignarmobiliarios : Form
    {
        public frn_Asignarmobiliarios()
        {
            InitializeComponent();
            CargarCombos();
            CargarTabla();
        }
        cls_AsignarMobiliarios asignacion = new cls_AsignarMobiliarios();
        private void CargarCombos()
        {
            cmb_sala.DataSource = asignacion.CargarSalas();
            cmb_sala.DisplayMember = "nombre";
            cmb_sala.ValueMember = "id_sala";

            cmb_mobiliario.DataSource = asignacion.CargarMobiliario();
            cmb_mobiliario.DisplayMember = "nombre";
            cmb_mobiliario.ValueMember = "id_mobiliario";
        }

        private void CargarTabla()
        {
            dgv_asignaciones.DataSource = asignacion.CargarDataGrid();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            asignacion.Id_sala = Convert.ToInt32(cmb_sala.SelectedValue);
            asignacion.Id_mobiliario = Convert.ToInt32(cmb_mobiliario.SelectedValue);
            asignacion.Cantidad_pasada = Convert.ToInt32(nud_cantidad.Value);


            if (!asignacion.ValidarAsignacion(asignacion.Id_sala, asignacion.Id_mobiliario, asignacion.Cantidad_pasada))
                return;

            MessageBox.Show(
                asignacion.GuardarAsignacion(),
                "Registro de asignación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            CargarTabla();
            Limpiar();

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (asignacion.Eliminar())
            {
                MessageBox.Show(
                    "Asignación eliminada correctamente.",
                    "Eliminación exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarTabla();
                Limpiar();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo eliminar la asignación.",
                    "Error al eliminar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            asignacion.Cantidad_pasada = Convert.ToInt32(nud_cantidad.Value);

            if (asignacion.ModificarCantidad())
            {
                MessageBox.Show(
                    "Cantidad modificada correctamente.",
                    "Modificación exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarTabla();
                Limpiar();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo modificar la cantidad.",
                    "Error al modificar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dgv_asignaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgv_asignaciones.Rows[e.RowIndex];

            cmb_sala.Text = fila.Cells["Sala"].Value.ToString();
            cmb_mobiliario.Text = fila.Cells["Mobiliario"].Value.ToString();
            nud_cantidad.Value = Convert.ToInt32(fila.Cells["Cantidad"].Value);
            txt_folio.Text = fila.Cells["Folio"].Value.ToString();
        }

        private void Limpiar()
        {
            nud_cantidad.Value = 0;
            txt_folio.Clear();
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            dgv_asignaciones.DataSource = asignacion.Buscar(txt_buscar.Text.Trim());
        }

        private void dgv_asignaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
