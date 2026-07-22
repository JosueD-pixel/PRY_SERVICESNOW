using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRY_SERVICESNOW
{
    public partial class frm_menuprincipal : Form
    {
        public frm_menuprincipal()
        {
            InitializeComponent();
            OcultarSubMenus();
            AsignarEventos(pnl_menu);
        }
        cls_menu menu;
        private bool menuAbierto = true;

        private void frm_menuprincipal_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Maximized;
            menu = new cls_menu();

            lblUsuario.Text = "Usuario: " + cls_login.UsuarioActual;
            lblRol.Text = "Rol: " + menu.ObtenerNombreRol(cls_login.Rol);

            menu.ConfigurarMenuPorRol(
                pnl_salas,
                pnl_trabajadores,
                pnl_reservas,
                btn_Mobiliario,
                btn_Servicios,
                btn_salaAgregar,
                btn_salasMobiliario,
                btn_salaServicios,
                btn_agregarReserva,
                btn_modificarReservas,
                btn_eliminarReservas
            );
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.BackColor = Color.FromArgb(180, 120, 90);
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.BackColor = Color.Transparent;
        }

        private void AsignarEventos(Control contenedor)
        {
            foreach (Control control in contenedor.Controls)
            {
                if (control is PictureBox pbc)
                {
                    pbc.MouseEnter += PictureBox_MouseEnter;
                    pbc.MouseLeave += PictureBox_MouseLeave;
                }

                if (control.HasChildren)
                {
                    AsignarEventos(control);
                }
            }
        }

        private void OcultarSubMenus()
        {
            pnl_salas.Visible = false;
            pnl_trabajadores.Visible = false;
            pnl_reservas.Visible = false;
        }
        private void MostrarSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            if (menuAbierto)
            {
                pnl_menu.Width = 0;
                menuAbierto = false;
            }
            else
            {
                pnl_menu.Width = 250;
                menuAbierto = true;
            }
        }

        private void btn_cerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_salas_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pnl_salas);
        }

        private void btn_trabajadores_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pnl_trabajadores);
        }

        private void btn_reservas_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pnl_reservas);
        }

        private void btn_agregarTra_Click(object sender, EventArgs e)
        {
            menu = new cls_menu();
            menu.AgregarAlContenedor(new frmTrabajadoresAGREGAR(), pnl_formulario);
        }

        private void btn_eliminartra_Click(object sender, EventArgs e)
        {
            menu = new cls_menu();
            menu.AgregarAlContenedor(new frmTrabajadoresELIMINAR(), pnl_formulario);
        }

        private void btn_modificarTra_Click(object sender, EventArgs e)
        {
            menu.AgregarAlContenedor(
            new frmTrabajdoresMODIFICAR(false),
            pnl_formulario);

        }

        private void btn_buscarTra_Click(object sender, EventArgs e)
        {
            menu.AgregarAlContenedor(
            new frmTrabajdoresMODIFICAR(true),
            pnl_formulario);
        }


        private void btn_Servicios_Click(object sender, EventArgs e)
        {
            menu = new cls_menu();
            menu.AgregarAlContenedor(new frm_servicios(), pnl_formulario);
        }

        private void btn_Mobiliario_Click(object sender, EventArgs e)
        {
            menu = new cls_menu();
            menu.AgregarAlContenedor(new frm_mobiliario(), pnl_formulario);
        }

        private void btn_salaAgregar_Click(object sender, EventArgs e)
        {
            menu = new cls_menu();
            menu.AgregarAlContenedor(new frm_salasCRUDd(), pnl_formulario);
        }

        private void btn_salaServicios_Click(object sender, EventArgs e)
        {
            menu = new cls_menu();
            menu.AgregarAlContenedor(new frm_AsignarServicios(), pnl_formulario);
        }

        private void btn_Reportes_Click(object sender, EventArgs e)
        {
            menu = new cls_menu();
            menu.AgregarAlContenedor(new frm_reportes(), pnl_formulario);
        }
    }
}
