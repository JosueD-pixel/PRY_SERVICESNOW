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
    public partial class frm_mobiliario : Form
    {
        cls_Mobiliario mobiliario;
        int id_mobiliario;
        public frm_mobiliario()
        {
            InitializeComponent();
            CargarGrid();
        }
        public void CargarGrid()
        {
            mobiliario = new cls_Mobiliario();
            dgv_mobiliario.DataSource = null;
            try
            {
                dgv_mobiliario.SuspendLayout();
                dgv_mobiliario.DataSource = mobiliario.CargarDataGrid();
                dgv_mobiliario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_mobiliario.ClearSelection();
                dgv_mobiliario.CurrentCell = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            id_mobiliario = 0;
            mobiliario.LimpiarPanel(pnl_mobiliario);
            mobiliario.LimpiarPanel(pnl_mobil2);
            dgv_mobiliario.ClearSelection();
            dgv_mobiliario.CurrentCell = null;
            txt_nombreMobiliario.Focus();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que el nombre del servicio no esté vacío
                if (string.IsNullOrWhiteSpace(txt_nombreMobiliario.Text))
                {
                    MessageBox.Show(
                        "Ingrese el nombre del servicio.",
                        "Datos incompletos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txt_nombreMobiliario.Focus();
                    return;
                }
                // 0 = guardar, 1 = actualizar
                int tipoOperacion = id_mobiliario == 0 ? 0 : 1;

                string accion = tipoOperacion == 0
                    ? "guardar"
                    : "actualizar";

                DialogResult respuesta = MessageBox.Show(
                    $"¿Está seguro de que desea {accion} este registro?",
                    "Confirmar operación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                // Si responde No, detener todo
                if (respuesta != DialogResult.Yes)
                {
                    return;
                }

                mobiliario.Id_mobiliario = id_mobiliario;

                mobiliario.Nombre_mobiliario = txt_nombreMobiliario.Text;
                mobiliario.Descripcion_mbo = txt_descripcion.Text;
                mobiliario.Cantidad = txt_cantidad.Text;

                string mensaje = mobiliario.GuardarActualizar(tipoOperacion);

                MessageBox.Show(
                    mensaje,
                    "Servicios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Recargar tabla
                CargarGrid();

                // Limpiar campos y CheckBox
                mobiliario.LimpiarPanel(pnl_mobiliario);

                // Deseleccionar tabla
                dgv_mobiliario.ClearSelection();
                dgv_mobiliario.CurrentCell = null;

                txt_nombreMobiliario.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que exista una fila seleccionada
                if (dgv_mobiliario.CurrentRow == null ||
                    dgv_mobiliario.CurrentRow.IsNewRow)
                {
                    MessageBox.Show(
                        "Seleccione el servicio que desea modificar.",
                        "Datos incompletos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // Obtener la fila seleccionada
                DataGridViewRow fila = dgv_mobiliario.CurrentRow;

                // Obtener los datos de la fila
                id_mobiliario = Convert.ToInt32(
                    dgv_mobiliario.SelectedRows[0].Cells["id_mobiliario"].Value
                );

                txt_idMobiliario.Text = id_mobiliario.ToString();

                txt_nombreMobiliario.Text = fila.Cells["Nombre"].Value?.ToString() ?? "";

                txt_descripcion.Text = fila.Cells["descripcion"].Value.ToString();

                txt_cantidad.Text = fila.Cells["total"].Value.ToString();

                // Evitar que se modifique el ID manualmente
                txt_idMobiliario.ReadOnly = true;

                txt_nombreMobiliario.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los datos del mobiliario.\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Comprobar que realmente haya una fila seleccionada
                if (dgv_mobiliario.SelectedRows.Count == 0)
                {
                    MessageBox.Show(
                        "Seleccione el mobiliario que desea eliminar.",
                        "Datos incompletos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                int idSeleccionado = Convert.ToInt32(
                   dgv_mobiliario.SelectedRows[0].Cells["id_mobiliario"].Value
                );

                DialogResult resp = MessageBox.Show(
                    $"¿Está seguro de eliminar el Mobiliario con ID {idSeleccionado}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resp != DialogResult.Yes)
                {
                    return;
                }

                mobiliario.Id_mobiliario = idSeleccionado;

                string mensaje = mobiliario.Eliminar();

                MessageBox.Show(
                    mensaje,
                    "Mobiliario",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarGrid();

                id_mobiliario = 0;
                dgv_mobiliario.ClearSelection();
                dgv_mobiliario.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void txt_buscarServicio_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string texto = txt_buscarServicio.Text.Trim();

                dgv_mobiliario.DataSource = mobiliario.Buscar(texto);

                dgv_mobiliario.ClearSelection();
                dgv_mobiliario.CurrentCell = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al buscar el servicio:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void frm_mobiliario_Load(object sender, EventArgs e)
        {
            cls_AsignarMobiliarios mobiliario = new cls_AsignarMobiliarios();
            dgv_mobiliario.DataSource = mobiliario.CargarMobiliario();
        }

        private void pnl_mobiliario_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

