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
    public partial class frmTrabajdoresMODIFICAR : Form
    {
        private bool soloConsulta;

        public frmTrabajdoresMODIFICAR()
        {
            InitializeComponent();
        }
        public frmTrabajdoresMODIFICAR(bool soloConsulta)
        {
            InitializeComponent();
            this.soloConsulta = soloConsulta;
        }

        private void frmTrabajdoresMODIFICAR_Load(object sender, EventArgs e)
        {
            btnModificar.Visible = !soloConsulta;

            if (soloConsulta)
            {
                pcb_apoyo.Image = Properties.Resources.img_apoyo4;
            }
            else
            {
                pcb_apoyo.Image = Properties.Resources.img_apoyo;
            }

            // Estado
            cmb_estado.Items.Add("Inactivo"); // 0
            cmb_estado.Items.Add("Activo");   // 1

            // Puestos
            cls_puestos puestos = new cls_puestos();
            DataTable tablaPuestos = puestos.ConsultarTodos();

            cmb_puesto.DisplayMember = "puesto";
            cmb_puesto.ValueMember = "id_puesto";
            cmb_puesto.DataSource = tablaPuestos;

            cmb_estado.SelectedIndex = -1;
            cmb_puesto.SelectedIndex = -1;

            CargarTabla();

        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            clsTrabajadores trabajador = new clsTrabajadores();

            //Filtra el DataGridView dinámicamente
            dgv_trabajadores.DataSource = trabajador.ConsultarGrid(txt_buscar.Text.Trim());

            // Si hay coincidencias, llenar las cajas de texto con la primera fila
            DataTable tabla = trabajador.ConsultarGrid(txt_buscar.Text.Trim());

            if (tabla.Rows.Count > 0)
            {
                DataRow fila = tabla.Rows[0];

                txt_clave.Text = fila["Clave"].ToString();
                txt_nombre.Text = fila["Nombre"].ToString();
                txt_apellidoP.Text = fila["Paterno"].ToString();
                txt_apellidoM.Text = fila["Materno"].ToString();
                txt_telefono.Text = fila["Telefono"].ToString();
                txt_correo.Text = fila["Correo"].ToString();
                txt_cp.Text = fila["CP"].ToString();
                txt_calle.Text = fila["Calle"].ToString();
                txt_colonia.Text = fila["Colonia"].ToString();

                cmb_estado.SelectedIndex = Convert.ToInt32(fila["Estado"]);
                cmb_puesto.SelectedValue = Convert.ToInt32(fila["Puesto"]);
            }


        }
        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            txt_buscar.Clear();
            txt_clave.Clear();
            txt_nombre.Clear();
            txt_apellidoP.Clear();
            txt_apellidoM.Clear();
            txt_telefono.Clear();
            txt_correo.Clear();
            txt_cp.Clear();
            txt_calle.Clear();
            txt_colonia.Clear();
            txt_password.Clear();

            cmb_estado.SelectedIndex = -1;
            cmb_puesto.SelectedIndex = -1;
        }

        private void CargarTabla()
        {
            clsTrabajadores trabajador = new clsTrabajadores();
            dgv_trabajadores.DataSource = trabajador.CargarDataGrid();
            dgv_trabajadores.Columns["Password"].Visible = false;
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_clave.Text))
                {
                    MessageBox.Show("Debe buscar un trabajador primero.");
                    return;
                }

                clsTrabajadores trabajador = new clsTrabajadores();

                trabajador.Clave_trabajador = txt_clave.Text.Trim();
                trabajador.Nombre = txt_nombre.Text.Trim();
                trabajador.ApellidoP = txt_apellidoP.Text.Trim();
                trabajador.ApellidoM = txt_apellidoM.Text.Trim();
                trabajador.Telefono = txt_telefono.Text.Trim();
                trabajador.Correo = txt_correo.Text.Trim();
                trabajador.Cp = txt_cp.Text.Trim();
                trabajador.Calle = txt_calle.Text.Trim();
                trabajador.Colonia = txt_colonia.Text.Trim();
                trabajador.Contrasena = txt_password.Text.Trim();
                trabajador.Estado = cmb_estado.SelectedIndex;
                trabajador.IdPuesto = Convert.ToInt32(cmb_puesto.SelectedValue);

                string mensaje = trabajador.GuardarActualizar(1);

                MessageBox.Show(mensaje, "Trabajadores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgv_trabajadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgv_trabajadores.Rows[e.RowIndex];

            txt_clave.Text = fila.Cells["Clave"].Value.ToString();
            txt_nombre.Text = fila.Cells["Nombre"].Value.ToString();
            txt_apellidoP.Text = fila.Cells["Paterno"].Value.ToString();
            txt_apellidoM.Text = fila.Cells["Materno"].Value.ToString();
            txt_telefono.Text = fila.Cells["Telefono"].Value.ToString();
            txt_correo.Text = fila.Cells["Correo"].Value.ToString();
            txt_cp.Text = fila.Cells["CP"].Value.ToString();
            txt_calle.Text = fila.Cells["Calle"].Value.ToString();
            txt_colonia.Text = fila.Cells["Colonia"].Value.ToString();

            txt_password.Text = "";

            cmb_estado.SelectedIndex = Convert.ToInt32(fila.Cells["Estado"].Value);

            cmb_puesto.Text = fila.Cells["Puesto"].Value.ToString();
        }
    }
}
