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
    public partial class frmTrabajadoresELIMINAR : Form
    {
        public frmTrabajadoresELIMINAR()
        {
            InitializeComponent();
        }

        private void CargarTabla()
        {
            clsTrabajadores trabajador = new clsTrabajadores();
            dgv_trabajadores.DataSource = trabajador.CargarDataGrid();
        }

        private void frmTrabajadoresELIMINAR_Load(object sender, EventArgs e)
        {
            CargarTabla();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_buscar.Text))
                {
                    MessageBox.Show("Seleccione un trabajador para eliminar.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Está seguro de eliminar este trabajador?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta != DialogResult.Yes)
                    return;

                clsTrabajadores trabajador = new clsTrabajadores();
                trabajador.Clave_trabajador = txt_buscar.Text.Trim();

                string mensaje = trabajador.Eliminar();

                MessageBox.Show(mensaje, "Trabajadores", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarTabla();
                txt_buscar.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            clsTrabajadores trabajador = new clsTrabajadores();
            dgv_trabajadores.DataSource = trabajador.Consultar(txt_buscar.Text.Trim());
        }

        private void dgv_trabajadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Obtener la fila seleccionada
            DataGridViewRow fila = dgv_trabajadores.Rows[e.RowIndex];

            // Pasar la clave al TextBox de búsqueda
            txt_buscar.Text = fila.Cells["Clave"].Value.ToString();
        }
    }
}
