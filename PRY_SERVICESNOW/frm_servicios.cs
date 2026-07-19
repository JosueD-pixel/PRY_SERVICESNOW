using System;
using System.Linq;
using System.Windows.Forms;

namespace PRY_SERVICESNOW
{
    public partial class frm_servicios : Form
    {
        cls_servicios servicio;
        int id_servicio;
        public frm_servicios()
        {
            InitializeComponent();
            CargarGrid();
        }

        private void frm_horarios_Load(object sender, EventArgs e)
        {

            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            dgv_servicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // ajusta columnas al ancho
            dgv_servicios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // ajusta filas
            dgv_servicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_servicios.MultiSelect = false;
            CargarGrid();

        }
        public void CargarGrid()
        {
            servicio = new cls_servicios();
            dgv_servicios.DataSource = null;
            try
            {
                dgv_servicios.SuspendLayout();
                dgv_servicios.DataSource = servicio.CargarDataGrid();
                dgv_servicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_servicios.ClearSelection();
                dgv_servicios.CurrentCell = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cls_servicios servicio = new cls_servicios();

                string texto = txt_buscarServicio.Text.Trim();

                dgv_servicios.DataSource = servicio.Buscar(texto);

                dgv_servicios.ClearSelection();
                dgv_servicios.CurrentCell = null;
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

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Comprobar que realmente haya una fila seleccionada
                if (dgv_servicios.SelectedRows.Count == 0)
                {
                    MessageBox.Show(
                        "Seleccione el equipo que desea eliminar.",
                        "Datos incompletos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                int idSeleccionado = Convert.ToInt32(
                    dgv_servicios.SelectedRows[0].Cells["Clave"].Value
                );

                DialogResult resp = MessageBox.Show(
                    $"¿Está seguro de eliminar el Servicio con ID {idSeleccionado}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resp != DialogResult.Yes)
                {
                    return;
                }

                servicio.Id_servicio = idSeleccionado;

                string mensaje = servicio.Eliminar();

                MessageBox.Show(
                    mensaje,
                    "Servicio",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarGrid();

                id_servicio = 0;
                dgv_servicios.ClearSelection();
                dgv_servicios.CurrentCell = null;
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

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que el nombre del servicio no esté vacío
                if (string.IsNullOrWhiteSpace(txt_nombreServicio.Text))
                {
                    MessageBox.Show(
                        "Ingrese el nombre del servicio.",
                        "Datos incompletos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txt_nombreServicio.Focus();
                    return;
                }
                // 0 = guardar, 1 = actualizar
                int tipoOperacion = id_servicio == 0 ? 0 : 1;

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

                servicio = new cls_servicios();

                servicio.Id_servicio = id_servicio;

                servicio.Nombre_servicio = txt_nombreServicio.Text;


                string mensaje = servicio.GuardarActualizar(tipoOperacion);

                MessageBox.Show(
                    mensaje,
                    "Servicios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Recargar tabla
                CargarGrid();

                // Limpiar campos y CheckBox
                servicio.LimpiarPanel(pnl_servicios);

                // Deseleccionar tabla
                dgv_servicios.ClearSelection();
                dgv_servicios.CurrentCell = null;

                txt_nombreServicio.Focus();
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
                if (dgv_servicios.CurrentRow == null ||
                    dgv_servicios.CurrentRow.IsNewRow)
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
                DataGridViewRow fila = dgv_servicios.CurrentRow;

                // Obtener los datos de la fila
                id_servicio = Convert.ToInt32(
                    fila.Cells["Clave"].Value
                );

                txt_idServicio.Text = id_servicio.ToString();

                txt_nombreServicio.Text =
                    fila.Cells["Servicio"].Value?.ToString() ?? "";

                // Evitar que se modifique el ID manualmente
                txt_idServicio.ReadOnly = true;

                txt_nombreServicio.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los datos del servicio.\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            id_servicio = 0;
            servicio.LimpiarPanel(pnl_servicios);
            dgv_servicios.ClearSelection();
            dgv_servicios.CurrentCell = null;
        }
    }
}
