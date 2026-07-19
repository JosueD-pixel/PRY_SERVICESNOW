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
    internal class cls_servicios
    {
        private string nombre_servicio;

        private int id_servicio;

        private MySqlDataAdapter consulta;
        //usamos un command para actualizar o insertar 
        private MySqlCommand comando;
        //usamos una tabla temporal
        private DataTable tabla;

        public string Nombre_servicio { get => nombre_servicio; set => nombre_servicio = value; }
        public int Id_servicio { get => id_servicio; set => id_servicio = value; }

        public DataTable CargarDataGrid()
        {
            tabla = new DataTable();
            try
            {
                cls_Conexion conexionBD = new cls_Conexion();
                using (var conexion = conexionBD.AbrirConexion())
                {
                    string sql = "SELECT id_servicio AS Clave, servicio AS 'Servicio' from tbl_servicios;";
                    using (consulta = new MySqlDataAdapter(sql, conexion))
                    {
                        consulta.Fill(tabla);
                    }//Liberar la consulta
                }//Liberarla conexion
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la conexion " + ex.Message);
            }
            return tabla;

        }
        public DataTable Consultar()
        {
            tabla = new DataTable();
            try
            {
                cls_Conexion conexionBD = new cls_Conexion();
                using (var conexion = conexionBD.AbrirConexion())
                {
                    string sql = "SELECT id_servicio AS Clave, servicio AS 'Servicio' from tbl_servicios WHERE id_servicio LIKE @id_servicio;";
                    using (var consultar = new MySqlCommand(sql, conexion))
                    {
                        consultar.Parameters.AddWithValue("@id_servicio", "%" + id_servicio + "%");
                        using (consulta = new MySqlDataAdapter(consultar))
                        {
                            consulta.Fill(tabla);
                        }//Liberar el adaptador
                    }//Liberar la consulta
                }//Liberar la conexion
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la conexion de la base de datos " + ex.Message);
            }
            return tabla;
        }
        public DataTable Buscar(string texto)
        {
            DataTable tabla = new DataTable();

            cls_Conexion conexionBD = new cls_Conexion();

            using (MySqlConnection conexion = conexionBD.AbrirConexion())
            {
                string sql = @"
            SELECT 
                id_servicio,
                servicio
            FROM tbl_servicios
            WHERE CAST(id_servicio AS CHAR) LIKE @busqueda
               OR servicio LIKE @busqueda
            ORDER BY id_servicio;";

                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(
                        "@busqueda",
                        MySqlDbType.VarChar
                    ).Value = "%" + texto + "%";

                    using (MySqlDataAdapter adaptador =
                           new MySqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }

            return tabla;
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

            }
        }

        public string Eliminar()
        {
            string msg = "";
            try
            {
                cls_Conexion conexionBD = new cls_Conexion();
                using (var conexion = conexionBD.AbrirConexion())
                {
                    string sql = "DELETE FROM tbl_servicios WHERE id_servicio = @id_servicio;";
                    using (comando = new MySqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue("@id_servicio", id_servicio);
                        int filasAfectadas = comando.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            msg = "Datos eliminados correctamente";
                        }
                        else
                        {
                            msg = "Los datos no se pudieron eliminar";
                        }
                    }//liberar las conexiones
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
            return msg;
        }


        public string GuardarActualizar(int TipoOperacion)
        {

            string msg = "";
            try
            {
                cls_Conexion conexionBD = new cls_Conexion();
                using (var conexion = conexionBD.AbrirConexion())
                {
                    switch (TipoOperacion)
                    {
                        case 0://insertarNEW
                            string sqlN = "INSERT INTO tbl_servicios(servicio) VALUES (@servicio);";
                            using (comando = new MySqlCommand(sqlN, conexion))
                            {
                                comando.Parameters.AddWithValue("servicio", nombre_servicio);

                                int filasAfectadas = comando.ExecuteNonQuery();
                                if (filasAfectadas > 0)
                                {
                                    msg = "El registro se guardo correctamente";
                                }
                                else
                                {
                                    msg = "Error, No se guardaron los datos";
                                }
                            }//Liberar la operacion de insercion
                            break;
                        case 1://ActualizarOLD
                            string sqlA = "UPDATE tbl_servicios C SET C.servicio = @servicio WHERE C.id_servicio = @id_servicio;";
                            using (comando = new MySqlCommand(sqlA, conexion))
                            {
                                comando.Parameters.AddWithValue("id_servicio", id_servicio);
                                comando.Parameters.AddWithValue("servicio", nombre_servicio);

                                int filasAfectadas = comando.ExecuteNonQuery();
                                if (filasAfectadas > 0)
                                {
                                    msg = "El registro se actualizo correctamente";
                                }
                                else
                                {
                                    msg = "Error, No se actualizaron los datos";
                                }
                            }//Liberar la operacion de actualizacion
                            break;
                    }
                }//Libera la conexion
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
            return msg;

        }
    }
}
