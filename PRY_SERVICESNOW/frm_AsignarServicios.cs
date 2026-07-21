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
    public partial class frm_AsignarServicios : Form
    {
        cls_asignarServicios servicios;
        private bool modoModificar = false;
        private int idSalaModificar = 0;
        public frm_AsignarServicios()
        {
            InitializeComponent();
            CargarServicios();
            CargarSalas();
            CargarAsignaciones();
        }

        private void CargarServicios()
        {
            try
            {
                cls_asignarServicios asignacion = new cls_asignarServicios();

                DataTable tablaServicios = asignacion.ObtenerServicios();

                clb_servicios.DataSource = tablaServicios;
                clb_servicios.DisplayMember = "servicio";
                clb_servicios.ValueMember = "id_servicio";
                clb_servicios.CheckOnClick = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los servicios.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void CargarSalas()
        {
            try
            {
                cls_asignarServicios asignacion =
                    new cls_asignarServicios();

                DataTable tablaSalas = asignacion.ObtenerSalas();

                // Crear opción inicial
                DataRow filaInicial = tablaSalas.NewRow();

                filaInicial["id_sala"] = 0;
                filaInicial["nombre"] = "-- Seleccione una sala --";

                tablaSalas.Rows.InsertAt(filaInicial, 0);

                cmb_sala.DataSource = tablaSalas;

                // Texto que verá el usuario
                cmb_sala.DisplayMember = "nombre";

                // ID que se utilizará para guardar
                cmb_sala.ValueMember = "id_sala";

                cmb_sala.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar las salas.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void CargarAsignaciones()
        {
            cls_asignarServicios asignaciones =
                new cls_asignarServicios();

            dgv_serviciosAsignados.DataSource =
                asignaciones.ObtenerAsignaciones();



            dgv_serviciosAsignados.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgv_serviciosAsignados.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgv_serviciosAsignados.MultiSelect = false;
            dgv_serviciosAsignados.ReadOnly = true;
            dgv_serviciosAsignados.AllowUserToAddRows = false;
            dgv_serviciosAsignados.RowHeadersVisible = false;

            if (dgv_serviciosAsignados.Columns.Contains("id_sala"))
            {
                dgv_serviciosAsignados.Columns["id_sala"].Visible = false;
            }

            if (dgv_serviciosAsignados.Columns.Contains("id_servicios"))
            {
                dgv_serviciosAsignados.Columns["id_servicios"].Visible = false;
            }

            dgv_serviciosAsignados.ClearSelection();
        }
        private List<int> ObtenerServiciosMarcados()
        {
            List<int> idsServicios = new List<int>();

            foreach (DataRowView fila in clb_servicios.CheckedItems)
            {
                int idServicio = Convert.ToInt32(
                    fila["id_servicio"]
                );

                idsServicios.Add(idServicio);
            }

            return idsServicios;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_sala.SelectedValue == null ||
                    !int.TryParse(
                        cmb_sala.SelectedValue.ToString(),
                        out int idSalaSeleccionada) ||
                    idSalaSeleccionada == 0)
                {
                    MessageBox.Show(
                        "Seleccione una sala.",
                        "Datos incompletos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    cmb_sala.Focus();
                    return;
                }

                List<int> serviciosMarcados =
                    ObtenerServiciosMarcados();

                if (serviciosMarcados.Count == 0)
                {
                    MessageBox.Show(
                        "Seleccione al menos un servicio.",
                        "Datos incompletos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Está seguro de que desea asignar los servicios seleccionados?",
                    "Confirmar asignación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta != DialogResult.Yes)
                {
                    return;
                }

                cls_asignarServicios asignacion =
                    new cls_asignarServicios();

                int tipoOperacion = modoModificar ? 1 : 0;

                asignacion.Id_sala = modoModificar
                    ? idSalaModificar
                    : idSalaSeleccionada;

                asignacion.Id_servicios = serviciosMarcados;

                string mensaje =
                    asignacion.GuardarActualizar(tipoOperacion);

                MessageBox.Show(
                    mensaje,
                    "Asignación de servicios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarAsignaciones();
                dgv_serviciosAsignados.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            servicios.LimpiarPanel(pnl_sala);
            servicios.LimpiarPanel(pnl_servicio);

            dgv_serviciosAsignados.ClearSelection();

            cmb_sala.Focus();
        }
        private void CargarDatosParaModificar()
        {
            if (dgv_serviciosAsignados.CurrentRow == null ||
                !dgv_serviciosAsignados.CurrentRow.Selected)
            {
                MessageBox.Show(
                    "Seleccione una asignación de la tabla.",
                    "Sin selección",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // Obtener el ID de la sala de la fila seleccionada
             idSalaModificar= Convert.ToInt32(
                dgv_serviciosAsignados
                    .CurrentRow
                    .Cells["id_sala"]
                    .Value
            );

            // Seleccionar automáticamente la sala
            cmb_sala.SelectedValue = idSalaModificar;

            // Desmarcar todos los servicios antes de cargar
            for (int i = 0; i < clb_servicios.Items.Count; i++)
            {
                clb_servicios.SetItemChecked(i, false);
            }

            // Guardar los IDs de los servicios activos de esa sala
            HashSet<int> serviciosActivos = new HashSet<int>();

            foreach (DataGridViewRow fila in dgv_serviciosAsignados.Rows)
            {
                if (fila.IsNewRow)
                {
                    continue;
                }

                int idSalaFila = Convert.ToInt32(
                    fila.Cells["id_sala"].Value
                );

                string estado = Convert.ToString(
                    fila.Cells["Estado"].Value
                );

                if (idSalaFila == idSalaModificar &&
                    estado == "Activo")
                {
                    int idServicio = Convert.ToInt32(
                        fila.Cells["id_servicios"].Value
                    );

                    serviciosActivos.Add(idServicio);
                }
            }

            // Marcar en el CheckedListBox los servicios activos
            for (int i = 0; i < clb_servicios.Items.Count; i++)
            {
                DataRowView servicio =
                    clb_servicios.Items[i] as DataRowView;

                if (servicio == null)
                {
                    continue;
                }

                int idServicioLista = Convert.ToInt32(
                    servicio["id_servicio"]
                );

                bool estaAsignado =
                    serviciosActivos.Contains(idServicioLista);

                clb_servicios.SetItemChecked(
                    i,
                    estaAsignado
                );
            }

            clb_servicios.ClearSelected();

            modoModificar = true;

            // Impedir que cambie de sala mientras modifica
            cmb_sala.Enabled = false;

            // El botón Guardar ahora guardará los cambios
            btn_guardar.Text = "Guardar cambios";
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            CargarDatosParaModificar();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que haya una fila seleccionada
                if (dgv_serviciosAsignados.SelectedRows.Count == 0)
                {
                    MessageBox.Show(
                        "Seleccione una asignación de la tabla.",
                        "Sin selección",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                DataGridViewRow filaSeleccionada =
                    dgv_serviciosAsignados.SelectedRows[0];

                // Obtener el ID de la asignación
                int idAsignacionSeleccionada = Convert.ToInt32(
                    filaSeleccionada.Cells["ID"].Value
                );

                string servicio = Convert.ToString(
                    filaSeleccionada.Cells["Servicio"].Value
                );

                string sala = Convert.ToString(
                    filaSeleccionada.Cells["Sala"].Value
                );

                string estado = Convert.ToString(
                    filaSeleccionada.Cells["Estado"].Value
                );

                // Evitar eliminar una asignación que ya está inactiva
                if (estado.Equals(
                    "Inactivo",
                    StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "La asignación seleccionada ya está inactiva.",
                        "Asignación inactiva",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    dgv_serviciosAsignados.ClearSelection();
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar el servicio " +
                    $"\"{servicio}\" de la sala \"{sala}\"?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (respuesta != DialogResult.Yes)
                {
                    return;
                }

                cls_asignarServicios asignacion =
                    new cls_asignarServicios();

                asignacion.Id_asignacionS =
                    idAsignacionSeleccionada;

                string mensaje =
                    asignacion.GuardarActualizar(2);

                MessageBox.Show(
                    mensaje,
                    "Eliminar asignación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Actualizar tabla
                CargarAsignaciones();

                // Restablecer los controles
                cmb_sala.SelectedIndex = 0;
                cmb_sala.Enabled = true;

                for (int i = 0;
                     i < clb_servicios.Items.Count;
                     i++)
                {
                    clb_servicios.SetItemChecked(i, false);
                }

                clb_servicios.ClearSelected();
                dgv_serviciosAsignados.ClearSelection();

                // Si utilizaste estas variables para modificar
                modoModificar = false;
                idSalaModificar = 0;
                btn_guardar.Text = "Guardar";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
