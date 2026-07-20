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
    public partial class frm_salasCRUD : Form
    {
        cls_salas sala;
        int id_sala;

        public frm_salasCRUD()
        {
            InitializeComponent();
        }
        



        private void frm_salasCRUD_Load(object sender, EventArgs e)
        {
            CargarGrid();
            CargarTipoSala();
            CargarUbicaciones();

        }
        public void CargarGrid()
        {
            sala = new cls_salas();
            dgv_salas.DataSource = null;

            try
            {
                dgv_salas.SuspendLayout();
                dgv_salas.DataSource = sala.CargarDataGrid();
                dgv_salas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_salas.ClearSelection();
                dgv_salas.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar salas:\n" + ex.Message);
            }
        }

     
        private void CargarTipoSala()
        {
            try
            {
                sala = new cls_salas();
                cmb_tiposala.DataSource = sala.CargarTipoSala();
                cmb_tiposala.DisplayMember = "nombre";
                cmb_tiposala.ValueMember = "id_tiposala";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tipos de sala:\n" + ex.Message);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void CargarUbicaciones()
        {
            sala = new cls_salas();
            cmb_ubicacion.Items.Clear();

            foreach (string ubic in sala.CargarUbicaciones())
            {
                cmb_ubicacion.Items.Add(ubic);
            }

            cmb_ubicacion.SelectedIndex = 0;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_nombre.Text))
                {
                    MessageBox.Show("Ingrese el nombre de la sala.",
                        "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_nombre.Focus();
                    return;
                }

                int tipoOperacion = id_sala == 0 ? 0 : 1;

                string accion = tipoOperacion == 0 ? "guardar" : "actualizar";

                DialogResult respuesta = MessageBox.Show(
                    $"¿Está seguro de que desea {accion} esta sala?",
                    "Confirmar operación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta != DialogResult.Yes)
                    return;

               
                sala.Nombre = txt_nombre.Text;
                sala.Descripcion = txt_descripcion.Text;
                sala.Ubicacion = cmb_ubicacion.Text;
                sala.Capacidad = (int)nud_capacidad.Value;
                sala.Estado = rdb_activo.Checked ? 1 : 0;
                sala.Id_tiposala = Convert.ToInt32(cmb_tiposala.SelectedValue);

                string mensaje = sala.GuardarActualizar(tipoOperacion);

                MessageBox.Show(mensaje, "Salas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrid();
                btn_limpiar_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar sala:\n" + ex.Message);
            }
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_salas.CurrentRow == null || dgv_salas.CurrentRow.IsNewRow)
                {
                    MessageBox.Show("Seleccione la sala que desea modificar.",
                        "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow fila = dgv_salas.CurrentRow;

                id_sala = Convert.ToInt32(fila.Cells["Clave"].Value);
                txt_idsala.Text = id_sala.ToString();

                txt_nombre.Text = fila.Cells["Nombre"].Value.ToString();
                txt_descripcion.Text = fila.Cells["Descripción"].Value.ToString();
                cmb_ubicacion.Text = fila.Cells["Ubicación"].Value.ToString();
                nud_capacidad.Value = Convert.ToInt32(fila.Cells["Capacidad"].Value);

                int estado = Convert.ToInt32(fila.Cells["Estado"].Value);
                rdb_activo.Checked = estado == 1;
                rdb_inactivo.Checked = estado == 0;

                cmb_tiposala.Text = fila.Cells["TipoSala"].Value.ToString();

                txt_idsala.ReadOnly = true;
                txt_nombre.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos de la sala:\n" + ex.Message);
            }

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_salas.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione la sala que desea eliminar.",
                        "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idSeleccionado = Convert.ToInt32(
                    dgv_salas.SelectedRows[0].Cells["Clave"].Value
                );

                DialogResult resp = MessageBox.Show(
                    $"¿Está seguro de eliminar la sala con ID {idSeleccionado}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resp != DialogResult.Yes)
                    return;

                sala.Id_sala = idSeleccionado;

                string mensaje = sala.Eliminar();

                MessageBox.Show(mensaje, "Salas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrid();
                id_sala = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar sala:\n" + ex.Message);
            }
        }

        private void txt_buscarServicio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string texto = txt_buscarSala.Text.Trim();
                dgv_salas.DataSource = sala.Buscar(texto);
                dgv_salas.ClearSelection();
                dgv_salas.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar sala:\n" + ex.Message);
            }
        }

        private void txt_buscarSala_TextChanged(object sender, EventArgs e)
        {
            string texto = txt_buscarSala.Text.Trim();
            dgv_salas.DataSource = sala.Buscar(texto);
            dgv_salas.ClearSelection();
            dgv_salas.CurrentCell = null;
        }





        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            id_sala = 0;

            sala.LimpiarPanel(panel3);

            dgv_salas.ClearSelection();
            dgv_salas.CurrentCell = null;

            txt_nombre.Focus();
        }

        private void pnl_superior_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
