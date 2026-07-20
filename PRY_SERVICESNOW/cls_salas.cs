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
    internal class cls_salas
    {
       
            // ============================
            // CAMPOS PRIVADOS
            // ============================
            private int id_sala;
            private string nombre;
            private string descripcion;
            private string ubicacion;
            private int capacidad;
            private int estado;
            private int id_tiposala;

            private MySqlDataAdapter consulta;
            private MySqlCommand comando;
            private DataTable tabla;

            // ============================
            // PROPIEDADES
            // ============================
            public int Id_sala { get => id_sala; set => id_sala = value; }
            public string Nombre { get => nombre; set => nombre = value; }
            public string Descripcion { get => descripcion; set => descripcion = value; }
            public string Ubicacion { get => ubicacion; set => ubicacion = value; }
            public int Capacidad { get => capacidad; set => capacidad = value; }
            public int Estado { get => estado; set => estado = value; }
            public int Id_tiposala { get => id_tiposala; set => id_tiposala = value; }

            // ============================
            // CARGAR GRID
            // ============================
            public DataTable CargarDataGrid()
            {
                tabla = new DataTable();
                try
                {
                    cls_Conexion conexionBD = new cls_Conexion();
                    using (var conexion = conexionBD.AbrirConexion())
                    {
                        string sql = @"
                        SELECT 
                            s.id_sala AS Clave,
                            s.nombre AS Nombre,
                            s.descripcion AS Descripción,
                            s.ubicacion AS Ubicación,
                            s.capacidad AS Capacidad,
                            s.estado AS Estado,
                            t.nombre AS TipoSala
                        FROM tbl_salas s
                        INNER JOIN tbl_tiposalas t ON s.id_tiposala = t.id_tiposala;
                    ";

                        using (consulta = new MySqlDataAdapter(sql, conexion))
                        {
                            consulta.Fill(tabla);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al cargar salas: " + ex.Message);
                }

                return tabla;
            }

            // ============================
            // CARGAR TIPOS DE SALA (BD)
            // ============================
            public DataTable CargarTipoSala()
            {
                tabla = new DataTable();
                try
                {
                    cls_Conexion conexionBD = new cls_Conexion();
                    using (var conexion = conexionBD.AbrirConexion())
                    {
                        string sql = "SELECT id_tiposala, nombre FROM tbl_tiposalas";

                        using (consulta = new MySqlDataAdapter(sql, conexion))
                        {
                            consulta.Fill(tabla);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al cargar tipos de sala: " + ex.Message);
                }

                return tabla;
            }

            // ============================
            // CARGAR UBICACIONES (MANUAL)
            // ============================
            public List<string> CargarUbicaciones()
            {
                return new List<string>
            {
                "Departamento A",
                "Departamento B",
                "Departamento C",
                "Departamento D",
                "Servicios de mantenimiento",
                "Biblioteca"
            };
            }

            // ============================
            // BUSCAR
            // ============================
            public DataTable Buscar(string texto)
            {
                tabla = new DataTable();
                cls_Conexion conexionBD = new cls_Conexion();

                using (var conexion = conexionBD.AbrirConexion())
                {
                    string sql = @"
                    SELECT 
                        s.id_sala AS Clave,
                        s.nombre AS Nombre,
                        s.descripcion AS Descripción,
                        s.ubicacion AS Ubicación,
                        s.capacidad AS Capacidad,
                        s.estado AS Estado,
                        t.nombre AS TipoSala
                    FROM tbl_salas s
                    INNER JOIN tbl_tiposalas t ON s.id_tiposala = t.id_tiposala
                    WHERE s.nombre LIKE @busqueda
                       OR s.descripcion LIKE @busqueda
                       OR s.ubicacion LIKE @busqueda
                    ORDER BY s.id_sala;
                ";

                    using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue("@busqueda", "%" + texto + "%");

                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comando))
                        {
                            adaptador.Fill(tabla);
                        }
                    }
                }

                return tabla;
            }

            // ============================
            // ELIMINAR
            // ============================
            public string Eliminar()
            {
                string msg = "";
                try
                {
                    cls_Conexion conexionBD = new cls_Conexion();
                    using (var conexion = conexionBD.AbrirConexion())
                    {
                        string sql = "DELETE FROM tbl_salas WHERE id_sala = @id_sala";

                        using (comando = new MySqlCommand(sql, conexion))
                        {
                            comando.Parameters.AddWithValue("@id_sala", id_sala);

                            int filas = comando.ExecuteNonQuery();
                            msg = filas > 0
                                ? "Sala eliminada correctamente"
                                : "No se pudo eliminar la sala";
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar sala: " + ex.Message);
                }

                return msg;
            }

            // ============================
            // GUARDAR / ACTUALIZAR
            // ============================
            public string GuardarActualizar(int tipoOperacion)
            {
                string msg = "";
                try
                {
                    cls_Conexion conexionBD = new cls_Conexion();
                    using (var conexion = conexionBD.AbrirConexion())
                    {
                        switch (tipoOperacion)
                        {
                            case 0: // INSERTAR
                                string sqlN = @"
                                INSERT INTO tbl_salas(nombre, descripcion, ubicacion, capacidad, estado, id_tiposala)
                                VALUES (@nombre, @descripcion, @ubicacion, @capacidad, @estado, @id_tiposala);
                            ";

                                using (comando = new MySqlCommand(sqlN, conexion))
                                {
                                    comando.Parameters.AddWithValue("@nombre", nombre);
                                    comando.Parameters.AddWithValue("@descripcion", descripcion);
                                    comando.Parameters.AddWithValue("@ubicacion", ubicacion);
                                    comando.Parameters.AddWithValue("@capacidad", capacidad);
                                    comando.Parameters.AddWithValue("@estado", estado);
                                    comando.Parameters.AddWithValue("@id_tiposala", id_tiposala);

                                    int filas = comando.ExecuteNonQuery();
                                    msg = filas > 0
                                        ? "Sala registrada correctamente"
                                        : "No se pudo registrar la sala";
                                }
                                break;

                            case 1: // ACTUALIZAR
                                string sqlA = @"
                                UPDATE tbl_salas 
                                SET nombre=@nombre, descripcion=@descripcion, ubicacion=@ubicacion,
                                    capacidad=@capacidad, estado=@estado, id_tiposala=@id_tiposala
                                WHERE id_sala=@id_sala;
                            ";

                                using (comando = new MySqlCommand(sqlA, conexion))
                                {
                                    comando.Parameters.AddWithValue("@id_sala", id_sala);
                                    comando.Parameters.AddWithValue("@nombre", nombre);
                                    comando.Parameters.AddWithValue("@descripcion", descripcion);
                                    comando.Parameters.AddWithValue("@ubicacion", ubicacion);
                                    comando.Parameters.AddWithValue("@capacidad", capacidad);
                                    comando.Parameters.AddWithValue("@estado", estado);
                                    comando.Parameters.AddWithValue("@id_tiposala", id_tiposala);

                                    int filas = comando.ExecuteNonQuery();
                                    msg = filas > 0
                                        ? "Sala actualizada correctamente"
                                        : "No se pudo actualizar la sala";
                                }
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al guardar/actualizar sala: " + ex.Message);
                }

                return msg;
            }

            // ============================
            // LIMPIAR PANEL
            // ============================
            public void LimpiarPanel(Panel panelDestino)
            {
                foreach (Control control in panelDestino.Controls)
                {
                    if (control is TextBox txt)
                        txt.Clear();

                    else if (control is ComboBox cmb)
                        cmb.SelectedIndex = 0;

                    else if (control is CheckBox chk)
                        chk.Checked = false;

                    else if (control is RadioButton rb)
                        rb.Checked = false;

                    else if (control is NumericUpDown nud)
                        nud.Value = 0;
                }
            }

        
    }
}

