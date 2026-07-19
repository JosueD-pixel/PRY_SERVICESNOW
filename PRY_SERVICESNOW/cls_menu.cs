using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySqlConnector;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRY_SERVICESNOW
{
    internal class cls_menu
    {
        private Form formularioActivo;

        public void AgregarAlContenedor(Form formulario, Panel panel)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            formularioActivo = formulario;

            panel.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panel.Controls.Add(formulario);
            panel.Tag = formulario;

            formulario.BringToFront();
            formulario.Show();
        }

        public string ObtenerNombreRol(int rol)
        {
            switch (rol)
            {
                case 1: return "Administrador";
                case 2: return "Recepcionista";
                case 3: return "Trabajador";
                default: return "Desconocido";
            }
        }

     

        public void ConfigurarMenuPorRol(
            Panel pnl_salas,
            Panel pnl_trabajadores,
            Panel pnl_reservas,
            PictureBox btnServicios,
            PictureBox btnMobiliario,
            PictureBox btn_salaAgregar,
            PictureBox btn_salasModificar,
            PictureBox btn_salasEliminar,
            PictureBox btn_agregarReservas,
            PictureBox btn_modificarReservas,
            PictureBox btn_eliminarReservas
              )
        {
            // ADMINISTRADOR
            if (cls_login.EsAdministrador)
            {
                // Mostrar todos los catálogos
                pnl_salas.Visible = false;
                pnl_trabajadores.Visible = false;
                pnl_reservas.Visible = false;

                btnServicios.Visible = true;
                btnMobiliario.Visible = true;

                // Salas: puede todo
                btn_salaAgregar.Visible = true;
                btn_salasModificar.Visible = true;
                btn_salasEliminar.Visible = true;

                // Reservas: solo buscar
                btn_agregarReservas.Visible = false;
                btn_modificarReservas.Visible = false;
                btn_eliminarReservas.Visible = false;
            }

            // RECEPCIONISTA
            else if (cls_login.EsRecepcionista)
            {
                pnl_salas.Visible = false;
                pnl_trabajadores.Visible = false;
                pnl_reservas.Visible = false;

                // NO debe ver mobiliario ni servicios
                btnServicios.Visible = false;
                btnMobiliario.Visible = false;

                // Salas: solo buscar
                btn_salaAgregar.Visible = false;
                btn_salasModificar.Visible = false;
                btn_salasEliminar.Visible = false;

                // Reservas: puede todo
                btn_agregarReservas.Visible = true;
                btn_modificarReservas.Visible = true;
                btn_eliminarReservas.Visible = true;
            }

            // TRABAJADOR
            else if (cls_login.EsTrabajador)
            {
                pnl_salas.Visible = false;
                pnl_reservas.Visible = false;

                // NO debe ver trabajadores
                pnl_trabajadores.Visible = false;

                // NO debe ver mobiliario ni servicios
                btnServicios.Visible = false;
                btnMobiliario.Visible = false;

                // Salas: solo buscar
                btn_salaAgregar.Visible = false;
                btn_salasModificar.Visible = false;
                btn_salasEliminar.Visible = false;

                // Reservas: solo buscar
                btn_agregarReservas.Visible = false;
                btn_modificarReservas.Visible = false;
                btn_eliminarReservas.Visible = false;
            }
        }

    }
}
