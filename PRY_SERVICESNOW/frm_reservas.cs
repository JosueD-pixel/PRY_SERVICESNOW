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
    public partial class frm_reservas : Form
    {
        private DateTime semanaActual; 

        public frm_reservas()
        {
            InitializeComponent();
        }

        private void frm_reservas_Load(object sender, EventArgs e)
        {
            cls_reservas reservas = new cls_reservas();

            reservas.CargarSalas(cmb_sala);
            reservas.CargarTrabajadores(cmb_trabajador);

            MostrarSemana();
            CargarHorario();
        }

        private void CargarHorario()
        {
            cls_reservas reservas = new cls_reservas();
            dgv_horario.DataSource = reservas.GenerarHorarioSemana();

            dgv_horario.RowHeadersVisible = false;
            dgv_horario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private DateTime ObtenerLunes(DateTime fecha)
        {
            int diferencia = fecha.DayOfWeek - DayOfWeek.Monday;

            if (diferencia < 0)
            {
                diferencia += 7;
            }

            return fecha.AddDays(-diferencia);
        }

        private void MostrarSemana()
        {
            DateTime inicio = semanaActual;
            DateTime fin = semanaActual.AddDays(4);

            txt_semana.Text = $"Del {inicio:dd/MM/yy} al {fin:dd/MM/yy}";
        }

        private void btn_semanaSiguiente_Click(object sender, EventArgs e)
        {
            semanaActual = semanaActual.AddDays(7);
            MostrarSemana();
            CargarHorario();
        }

        private void btn_semanaAnterior_Click(object sender, EventArgs e)
        {
            semanaActual = semanaActual.AddDays(-7);
            MostrarSemana();
            CargarHorario();
        }
    }
}
