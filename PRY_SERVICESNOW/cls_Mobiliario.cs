using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace PRY_SERVICESNOW
{
    internal class cls_Mobiliario
    {
        private string nombre_mobiliario;
        private string descripcion_mbo;
        private string cantidad;

        private int id_mobiliario;
        

        private MySqlDataAdapter consulta;
        //usamos un command para actualizar o insertar 
        private MySqlCommand comando;
        //usamos una tabla temporal
        private DataTable tabla;

        public string Nombre_mobiliario { get => nombre_mobiliario; set => nombre_mobiliario = value; }
        public int Id_mobiliario { get => id_mobiliario; set => id_mobiliario = value; }
        public string Descripcion_mbo { get => descripcion_mbo; set => descripcion_mbo = value; }
        public string Cantidad { get => cantidad; set => cantidad = value; }

        public DataTable CargarDataGrid()
        {
            tabla = new DataTable();
            try
            {
                cls_Conexion conexionBD = new cls_Conexion();
                using (var conexion = conexionBD.AbrirConexion())
                {
                    string sql = "SELECT id_mobiliario AS Clave, nombre AS 'Nombre', descripcion AS 'Descripción', cantidad AS Cantidad from tbl_mobiliario;";
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
                    string sql = "SELECT id_mobiliario AS Clave, nombre AS 'Nombre', descripcion AS 'Descripción', cantidad AS Cantidad from tbl_mobiliario WHERE id_mobiliario LIKE @id_mobiliario;";
                    using (var consultar = new MySqlCommand(sql, conexion))
                    {
                        consultar.Parameters.AddWithValue("@id_mobiliario", "%" + id_mobiliario + "%");
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
         id_mobiliario AS Clave,
         nombre AS Nombre,
         descripcion AS Descripción,
         cantidad AS Cantidad
     FROM tbl_mobiliario
     WHERE CAST(id_mobiliario AS CHAR) LIKE @busqueda
        OR nombre LIKE @busqueda
     ORDER BY id_mobiliario;";

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
                    string sql = "DELETE FROM tbl_mobiliario WHERE id_mobiliario = @id_mobiliario;";
                    using (comando = new MySqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue("@id_mobiliario", id_mobiliario);
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
                            string sqlN = "INSERT INTO tbl_mobiliario(nombre, descripcion, cantidad) VALUES (@nombre, @descripcion, @cantidad);";
                            using (comando = new MySqlCommand(sqlN, conexion))
                            {
                                comando.Parameters.AddWithValue("nombre", nombre_mobiliario);
                                comando.Parameters.AddWithValue("descripcion", descripcion_mbo);
                                comando.Parameters.AddWithValue("cantidad", cantidad);

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
                            string sqlA = "UPDATE tbl_mobiliario C SET C.nombre = @nombre, C.descripcion = @descripcion, C.cantidad = @cantidad WHERE C.id_mobiliario = @id_mobiliario;";
                            using (comando = new MySqlCommand(sqlA, conexion))
                            {
                                comando.Parameters.AddWithValue("id_mobiliario", id_mobiliario);
                                comando.Parameters.AddWithValue("nombre", nombre_mobiliario);
                                comando.Parameters.AddWithValue("descripcion", descripcion_mbo);
                                comando.Parameters.AddWithValue("cantidad", cantidad);

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
