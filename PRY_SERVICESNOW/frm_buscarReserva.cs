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
    public partial class frm_buscarReserva : Form
    {
        public frm_buscarReserva()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void CargarReservas()
        {
            cls_cancelacion cancelacion = new cls_cancelacion();
            dgv_reservas.DataSource = cancelacion.CargarReservasActivas();

            dgv_reservas.RowHeadersVisible = false;
            dgv_reservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgv_reservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgv_reservas.Rows[e.RowIndex];

                cmb_trabajador.Text = fila.Cells["Trabajador"].Value.ToString();
                cmb_salas.Text = fila.Cells["Sala"].Value.ToString();
                dtp_fecha.Value = Convert.ToDateTime(fila.Cells["fecha_uso"].Value);
                nud_horaInicio.Value = Convert.ToInt32(fila.Cells["hora_inicio"].Value.ToString().Substring(0, 2));
                nud_horaFinal.Value = Convert.ToInt32(fila.Cells["hora_fin"].Value.ToString().Substring(0, 2));
                txt_motivo.Text = fila.Cells["motivo"].Value.ToString();

            }
        }

        private void frm_buscarReserva_Load(object sender, EventArgs e)
        {
            CargarReservas();
        }
    }
}
