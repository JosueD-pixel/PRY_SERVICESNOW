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
    public partial class frmTrabajadoresAGREGAR : Form
    {
        clsTrabajadores trabajador = new clsTrabajadores();
        public frmTrabajadoresAGREGAR()
        {
            InitializeComponent();

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrWhiteSpace(txt_clave.Text))
                {
                    MessageBox.Show("Ingrese la clave del trabajador.");
                    txt_clave.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_nombre.Text))
                {
                    MessageBox.Show("Ingrese el nombre del trabajador.");
                    txt_nombre.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_apellidoP.Text))
                {
                    MessageBox.Show("Ingrese el apellido paterno.");
                    txt_apellidoP.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_apellidoM.Text))
                {
                    MessageBox.Show("Ingrese el apellido materno.");
                    txt_apellidoM.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_cp.Text))
                {
                    MessageBox.Show("Ingrese el código postal.");
                    txt_cp.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_colonia.Text))
                {
                    MessageBox.Show("Ingrese la colonia.");
                    txt_colonia.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_calle.Text))
                {
                    MessageBox.Show("Ingrese la calle.");
                    txt_calle.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_correo.Text))
                {
                    MessageBox.Show("Ingrese el correo.");
                    txt_correo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_telefono.Text))
                {
                    MessageBox.Show("Ingrese el teléfono.");
                    txt_telefono.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_password.Text))
                {
                    MessageBox.Show("Ingrese la contraseña.");
                    txt_password.Focus();
                    return;
                }

                if (cmb_puesto.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un puesto.");
                    return;
                }

                if (cmb_estado.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione el estado.");
                    return;
                }

                // Validación teléfono
                if (txt_telefono.Text.Length != 10)
                {
                    MessageBox.Show("El teléfono debe contener exactamente 10 dígitos.");
                    txt_telefono.Focus();
                    return;
                }

                // Validación CP
                if (txt_cp.Text.Length != 5)
                {
                    MessageBox.Show("El código postal debe contener 5 dígitos.");
                    txt_cp.Focus();
                    return;
                }

                // Validación formato correo
                try
                {
                    var mail = new System.Net.Mail.MailAddress(txt_correo.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("El correo electrónico no tiene un formato válido.");
                    txt_correo.Focus();
                    return;
                }

                // Validación correo duplicado
                clsTrabajadores validar = new clsTrabajadores();
                if (validar.CorreoExiste(txt_correo.Text.Trim()))
                {
                    MessageBox.Show("El correo electrónico ya existe en la base de datos.");
                    txt_correo.Focus();
                    return;
                }


                // Confirmación
                DialogResult respuesta = MessageBox.Show(
                    "¿Desea guardar este registro?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta != DialogResult.Yes)
                    return;

                // Pasar datos a la clase
                clsTrabajadores trabajador = new clsTrabajadores();

                trabajador.Clave_trabajador = txt_clave.Text.Trim();
                trabajador.Nombre = txt_nombre.Text.Trim();
                trabajador.ApellidoP = txt_apellidoP.Text.Trim();
                trabajador.ApellidoM = txt_apellidoM.Text.Trim();
                trabajador.Cp = txt_cp.Text.Trim();
                trabajador.Colonia = txt_colonia.Text.Trim();
                trabajador.Calle = txt_calle.Text.Trim();

                trabajador.Correo = txt_correo.Text.Trim();
                trabajador.Telefono = txt_telefono.Text.Trim();
                trabajador.Contrasena = txt_password.Text.Trim();

                trabajador.IdPuesto = Convert.ToInt32(cmb_puesto.SelectedValue);
                trabajador.Estado = cmb_estado.SelectedIndex;

                // Guardar
                string mensaje = trabajador.GuardarActualizar(0);

                MessageBox.Show(mensaje, "Trabajadores", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                txt_clave.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void LimpiarCampos()
        {
            txt_clave.Text = "";
            txt_nombre.Text = "";
            txt_apellidoP.Text = "";
            txt_apellidoM.Text = "";
            txt_cp.Text = "";
            txt_colonia.Text = "";
            txt_calle.Text = "";
            txt_correo.Text = "";
            txt_telefono.Text = "";
            txt_password.Text = "";
            cmb_estado.SelectedIndex = -1;
            cmb_puesto.SelectedIndex = -1;
        }

        private void frmTrabajadoresAGREGAR_Load(object sender, EventArgs e)
        {
            // Estado
            cmb_estado.Items.Add("Inactivo");
            cmb_estado.Items.Add("Activo");

            // Puestos
            cls_puestos puestos = new cls_puestos();
            DataTable tablaPuestos = puestos.ConsultarTodos();

            cmb_puesto.DisplayMember = "puesto";   // Primero
            cmb_puesto.ValueMember = "id_puesto";         // Segundo
            cmb_puesto.DataSource = tablaPuestos;         // Último

            cmb_estado.SelectedIndex = -1;
            cmb_puesto.SelectedIndex = -1;

        }

        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

            if (txt_telefono.Text.Length >= 10 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }


        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txt_cp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

            if (txt_cp.Text.Length >= 5 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
