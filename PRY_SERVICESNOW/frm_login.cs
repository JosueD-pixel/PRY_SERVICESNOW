using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PRY_SERVICESNOW
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void pnl_superior_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_salir_MouseEnter(object sender, EventArgs e)
        {
            btn_salir.BackColor = Color.FromArgb(201, 123, 99);
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_minimizar_MouseEnter(object sender, EventArgs e)
        {
            btn_minimizar.BackColor = Color.FromArgb(201, 123, 99);
        }

        private void btn_minimizar_MouseLeave(object sender, EventArgs e)
        {
            btn_minimizar.BackColor = Color.Transparent;
        }

        private void btn_salir_MouseLeave(object sender, EventArgs e)
        {
            btn_salir.BackColor = Color.Transparent;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btn_ingresar_MouseEnter(object sender, EventArgs e)
        {
            btn_ingresar.Image = Properties.Resources.btn_selection_ingresar;
        }

        private void btn_ingresar_MouseLeave(object sender, EventArgs e)
        {
            btn_ingresar.Image = Properties.Resources.btn_ingresar;
        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            try
            {
                cls_login login = new cls_login();
                login.Clave = txt_clave.Text;
                login.Password = txt_password.Text;

                bool resp = login.ValidarAcceso();

                if (resp)
                {
                    this.Hide();

                    frm_menuprincipal menu = new frm_menuprincipal();
                    menu.ShowDialog();

                    this.Show();
                    txt_clave.Clear();
                    txt_password.Clear();
                    txt_password.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Error de autenticación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                txt_clave.Clear();
                txt_password.Clear();
                txt_clave.Focus();
            }
        }
    }
}
