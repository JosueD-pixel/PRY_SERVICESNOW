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
            CargarCombos();
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
                    AplicarFiltros();
                }
                else if (rdb_consulta2.Checked)
                {
                    tabla = reportes.ObtenerServiciosPorSala();
                    dgv_reportes.DataSource = tabla;
                    AplicarFiltros();
                }
                else if (rdb_consulta3.Checked)
                {
                    tabla= reportes.ObtenerMobiliarioPorSala();
                    dgv_reportes.DataSource = tabla;
                    AplicarFiltros();
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
            reportes = new cls_reportes();

            // Obtener la vista filtrada del DataGridView
            DataView vistaFiltrada = dgv_reportes.DataSource as DataView;

            // Si no hay vista filtrada, usar la tabla normal
            DataTable tablaParaPDF;

            if (vistaFiltrada != null)
            {
                tablaParaPDF = vistaFiltrada.ToTable();
            }
            else
            {
                tablaParaPDF = tabla;
            }

            if (rdb_consulta1.Checked == true)
            {
                reportes.ExportarPDF(tablaParaPDF,
                    "Reporte de reservas con trabajador, sala y tipo de sala",
                    "Reservas.pdf");
            }
            else if (rdb_consulta2.Checked == true)
            {
                reportes.ExportarPDF(tablaParaPDF,
                    "Reporte de servicios asignados",
                    "ServiciosAsignados.pdf");
            }
            else if (rdb_consulta3.Checked == true)
            {
                reportes.ExportarPDF(tablaParaPDF,
                    "Reporte de mobiliario asignado",
                    "MobiliarioAsignado.pdf");
            }
        }

        private void dgv_reportes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CargarCombos()
        {
            cls_Conexion conexionBD = new cls_Conexion();

            using (var conexion = conexionBD.AbrirConexion())
            {
                // SALAS
                using (var cmd = new MySqlConnector.MySqlCommand("SELECT id_sala, nombre FROM tbl_salas", conexion))
                {
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());

                    // Insertar opción TODOS
                    DataRow filaTodos = dt.NewRow();
                    filaTodos["id_sala"] = 0;
                    filaTodos["nombre"] = "Todos";
                    dt.Rows.InsertAt(filaTodos, 0);

                    cmb_sala.DataSource = dt;
                    cmb_sala.DisplayMember = "nombre";
                    cmb_sala.ValueMember = "id_sala";
                    cmb_sala.SelectedIndex = 0;
                }

                // SERVICIOS
                using (var cmd = new MySqlConnector.MySqlCommand("SELECT id_servicio, servicio FROM tbl_servicios", conexion))
                {
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());

                    DataRow filaTodos = dt.NewRow();
                    filaTodos["id_servicio"] = 0;
                    filaTodos["servicio"] = "Todos";
                    dt.Rows.InsertAt(filaTodos, 0);

                    cmb_servicio.DataSource = dt;
                    cmb_servicio.DisplayMember = "servicio";
                    cmb_servicio.ValueMember = "id_servicio";
                    cmb_servicio.SelectedIndex = 0;
                }

                // MOBILIARIO
                using (var cmd = new MySqlConnector.MySqlCommand("SELECT id_mobiliario, nombre FROM tbl_mobiliario", conexion))
                {
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());

                    DataRow filaTodos = dt.NewRow();
                    filaTodos["id_mobiliario"] = 0;
                    filaTodos["nombre"] = "Todos";
                    dt.Rows.InsertAt(filaTodos, 0);

                    cmb_mobiliario.DataSource = dt;
                    cmb_mobiliario.DisplayMember = "nombre";
                    cmb_mobiliario.ValueMember = "id_mobiliario";
                    cmb_mobiliario.SelectedIndex = 0;
                }
            }
        }

        private void cmb_sala_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void cmb_servicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void cmb_mobiliario_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            if (tabla == null || tabla.Rows.Count == 0)
            {
                return;
            }

            DataView vista = new DataView(tabla);
            string filtro = "";

            // FILTRO POR SALA
            if (cmb_sala.Enabled == true && cmb_sala.SelectedIndex != -1)
            {
                if (cmb_sala.Text != "Todos")
                {
                    filtro += $"Sala = '{cmb_sala.Text}'";
                }
            }

            // FILTRO POR SERVICIO
            if (cmb_servicio.Enabled == true && cmb_servicio.SelectedIndex != -1)
            {
                if (cmb_servicio.Text != "Todos")
                {
                    if (filtro != "")
                    {
                        filtro += " AND ";
                    }

                    filtro += $"Servicio = '{cmb_servicio.Text}'";
                }
            }

            // FILTRO POR MOBILIARIO
            if (cmb_mobiliario.Enabled == true && cmb_mobiliario.SelectedIndex != -1)
            {
                if (cmb_mobiliario.Text != "Todos")
                {
                    if (filtro != "")
                    {
                        filtro += " AND ";
                    }

                    filtro += $"Mobiliario = '{cmb_mobiliario.Text}'";
                }
            }

            vista.RowFilter = filtro;
            dgv_reportes.DataSource = vista;
        }



    }
}
