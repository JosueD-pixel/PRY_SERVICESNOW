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
    public partial class frm_reportes : Form
    {
        cls_reportes reportes;
        DataTable tabla;
        public frm_reportes()
        {
            InitializeComponent();
        }

        private void frm_reportes_Load(object sender, EventArgs e)
        {
            ConfigurarDataGrid();
        }

        private void ConfigurarDataGrid()
        {
            dgv_reportes.ReadOnly = true;
            dgv_reportes.AllowUserToAddRows = false;
            dgv_reportes.AllowUserToDeleteRows = false;
            dgv_reportes.MultiSelect = false;

            dgv_reportes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_reportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dgv_reportes.RowHeadersVisible = false;
        }

        private void btn_ver_Click(object sender, EventArgs e)
        {
            reportes = new cls_reportes();
            tabla = new DataTable();
            dgv_reportes.DataSource = null;
            dgv_reportes.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.Fill;
            try
            {
                if (rdb_consulta1.Checked)
                {
                    tabla = reportes.ObtenerReservas();
                    dgv_reportes.DataSource = tabla;
                }
                else if (rdb_consulta2.Checked)
                {
                    tabla = reportes.ObtenerServiciosPorSala();
                    dgv_reportes.DataSource = tabla;
                }
                else if (rdb_consulta3.Checked)
                {
                    tabla= reportes.ObtenerMobiliarioPorSala();
                    dgv_reportes.DataSource = tabla;
                }
                else
                {
                    MessageBox.Show(
                        "Seleccione una consulta.",
                        "Consulta no seleccionada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar el reporte.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            reportes= new cls_reportes ();
            if (rdb_consulta1.Checked == true)
            {
                reportes.ExportarPDF(tabla, "Reporte de reservas con trabajador, sala y tipo de sala", "Reservas.pdf");
            }
            else if (rdb_consulta2.Checked == true)
            {
                reportes.ExportarPDF(tabla, "Reporte de servicios asignados", "ServiciosAsignados.pdf");
            }
            else if (rdb_consulta3.Checked == true)
            {
                reportes.ExportarPDF(tabla, "Reporte de mobiliario asignado","MobiliarioAsignado.pdf");
            }
        }
    }
}
