using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PRY_SERVICESNOW
{
    internal class cls_asignarServicios
    {

        private int id_asignacionS;
        private int id_sala;
        private int estado;

        private List<int> id_servicios = new List<int>();

        public int Id_asignacionS
        {
            get => id_asignacionS;
            set => id_asignacionS = value;
        }

        public List<int> Id_servicios
        {
            get => id_servicios;
            set => id_servicios = value ?? new List<int>();
        }

        public int Id_sala
        {
            get => id_sala;
            set => id_sala = value;
        }

        public int Estado
        {
            get => estado;
            set => estado = value;
        }


        public DataTable ObtenerServicios()
        {
            DataTable tablaServicios = new DataTable();

            try
            {
                cls_Conexion conexionBD = new cls_Conexion();

                using (MySqlConnection conexion = conexionBD.AbrirConexion())
                {
                    string consulta = @"SELECT id_servicio, servicio
                                        FROM tbl_Servicios
                                        ORDER BY servicio;";

                    using (MySqlDataAdapter adaptador =
                           new MySqlDataAdapter(consulta, conexion))
                    {
                        adaptador.Fill(tablaServicios);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron obtener los servicios.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return tablaServicios;
        }
        public DataTable ObtenerSalas()
        {
            DataTable tablaSalas = new DataTable();

            try
            {
                cls_Conexion conexionBD = new cls_Conexion();

                using (MySqlConnection conexion = conexionBD.AbrirConexion())
                {
                    string consulta = @"SELECT id_sala, nombre
                                FROM Tbl_Salas
                                WHERE estado = 1
                                ORDER BY nombre;";

                    using (MySqlDataAdapter adaptador =
                           new MySqlDataAdapter(consulta, conexion))
                    {
                        adaptador.Fill(tablaSalas);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron obtener las salas.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return tablaSalas;
        }
        public DataTable ObtenerAsignaciones()
        {
            DataTable tablaAsignaciones = new DataTable();

            try
            {
                cls_Conexion conexionBD = new cls_Conexion();

                using (MySqlConnection conexion = conexionBD.AbrirConexion())
                {
                    string consulta = @"
                SELECT
                    A.id_asignacionS AS ID,
                    A.id_sala,
                    A.id_servicios,
                    SV.servicio AS Servicio,
                    S.nombre AS Sala,
                    CASE
                        WHEN A.estado = 1 THEN 'Activo'
                        ELSE 'Inactivo'
                    END AS Estado
                FROM Tbl_Asignacion_servicios AS A
                INNER JOIN Tbl_Servicios AS SV
                    ON A.id_servicios = SV.id_servicio
                INNER JOIN Tbl_Salas AS S
                    ON A.id_sala = S.id_sala
                ORDER BY S.nombre, SV.servicio;";

                    using (MySqlDataAdapter adaptador =
                           new MySqlDataAdapter(consulta, conexion))
                    {
                        adaptador.Fill(tablaAsignaciones);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron obtener las asignaciones.\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return tablaAsignaciones;
        }
        public void LimpiarPanel(Panel panelDestino)
        {
            foreach (Control control in panelDestino.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = 0;

                }
                else if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
                else if (control is CheckedListBox checkedListBox)
                {
                    for (int i = 0; i < checkedListBox.Items.Count; i++)
                    {
                        checkedListBox.SetItemChecked(i, false);
                    }

                    checkedListBox.ClearSelected();
                }
            }
        }
        public string GuardarActualizar(int tipoOperacion)
        {
            string msg = "";

            if ((tipoOperacion == 0 || tipoOperacion == 1) &&
       id_sala <= 0)
            {
                throw new Exception(
                    "No se recibió una sala válida."
                );
            }

            if ((tipoOperacion == 0 || tipoOperacion == 1) &&
                (id_servicios == null || id_servicios.Count == 0))
            {
                throw new Exception(
                    "No se recibió ningún servicio para guardar."
                );
            }

            cls_Conexion conexionBD = new cls_Conexion();

            try
            {
                using (MySqlConnection conexion =
                       conexionBD.AbrirConexion())
                {
                    using (MySqlTransaction transaccion =
                           conexion.BeginTransaction())
                    {
                        try
                        {
                            switch (tipoOperacion)
                            {
                                // =====================================
                                // 0 = GUARDAR
                                // =====================================
                                case 0:

                                    string sqlInsertar = @"
                                INSERT INTO Tbl_Asignacion_servicios
                                (
                                    id_servicios,
                                    id_sala,
                                    estado
                                )
                                VALUES
                                (
                                    @idServicio,
                                    @idSala,
                                    1
                                )
                                ON DUPLICATE KEY UPDATE
                                    estado = 1;";

                                    foreach (int idServicio in id_servicios)
                                    {
                                        using (MySqlCommand comando =
                                               new MySqlCommand(
                                                   sqlInsertar,
                                                   conexion,
                                                   transaccion))
                                        {
                                            comando.Parameters.AddWithValue(
                                                "@idServicio",
                                                idServicio
                                            );

                                            comando.Parameters.AddWithValue(
                                                "@idSala",
                                                id_sala
                                            );

                                            comando.ExecuteNonQuery();
                                        }
                                    }

                                    msg = "Los servicios se asignaron correctamente.";
                                    break;

                                // =====================================
                                // 1 = MODIFICAR
                                // =====================================
                                case 1:

                                    /*
                                     * Primero desactivamos todos los
                                     * servicios de la sala.
                                     */
                                    string sqlDesactivar = @"
                                UPDATE Tbl_Asignacion_servicios
                                SET estado = 0
                                WHERE id_sala = @idSala;";

                                    using (MySqlCommand comando =
                                           new MySqlCommand(
                                               sqlDesactivar,
                                               conexion,
                                               transaccion))
                                    {
                                        comando.Parameters.AddWithValue(
                                            "@idSala",
                                            id_sala
                                        );

                                        comando.ExecuteNonQuery();
                                    }

                                    /*
                                     * Después activamos solamente los
                                     * servicios que están marcados.
                                     */
                                    string sqlActivar = @"
                                INSERT INTO Tbl_Asignacion_servicios
                                (
                                    id_servicios,
                                    id_sala,
                                    estado
                                )
                                VALUES
                                (
                                    @idServicio,
                                    @idSala,
                                    1
                                )
                                ON DUPLICATE KEY UPDATE
                                    estado = 1;";

                                    foreach (int idServicio in id_servicios)
                                    {
                                        using (MySqlCommand comando =
                                               new MySqlCommand(
                                                   sqlActivar,
                                                   conexion,
                                                   transaccion))
                                        {
                                            comando.Parameters.AddWithValue(
                                                "@idServicio",
                                                idServicio
                                            );

                                            comando.Parameters.AddWithValue(
                                                "@idSala",
                                                id_sala
                                            );

                                            comando.ExecuteNonQuery();
                                        }
                                    }

                                    msg = "Los servicios de la sala se modificaron correctamente.";
                                    break;

                                // =====================================
                                // 2 = ELIMINAR
                                // =====================================
                                case 2:

                                    string sqlEliminar = @"
                                UPDATE Tbl_Asignacion_servicios
                                SET estado = 0
                                WHERE id_asignacionS = @idAsignacionS;";

                                    int filasAfectadas;

                                    using (MySqlCommand comando =
                                           new MySqlCommand(
                                               sqlEliminar,
                                               conexion,
                                               transaccion))
                                    {
                                        comando.Parameters.AddWithValue(
                                            "@idAsignacionS",
                                            id_asignacionS
                                        );

                                        filasAfectadas =
                                            comando.ExecuteNonQuery();
                                    }

                                    if (filasAfectadas == 0)
                                    {
                                        throw new Exception(
                                            "No se encontró la asignación seleccionada."
                                        );
                                    }

                                    msg = "El servicio se eliminó de la sala correctamente.";
                                    break;

                                default:

                                    throw new Exception(
                                        "El tipo de operación no es válido."
                                    );
                            }

                            // Confirmar todos los cambios
                            transaccion.Commit();
                        }
                        catch (Exception ex)
                        {
                            // Deshacer todos los cambios
                            transaccion.Rollback();

                            throw new Exception(
                                "Error en la operación. " +
                                "Se cancelaron los cambios: " +
                                ex.Message
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error de conexión: " + ex.Message
                );
            }

            return msg;
        }
    }
}
