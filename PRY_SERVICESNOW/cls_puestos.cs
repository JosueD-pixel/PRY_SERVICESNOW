using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRY_SERVICESNOW
{
    internal class cls_puestos
    {
        public int IdPuesto { get; set; }
        public string NombrePuesto { get; set; }

        // Consultar todos los puestos
        public DataTable ConsultarTodos()
        {
            DataTable tabla = new DataTable();

            try
            {
                cls_Conexion conexionBD = new cls_Conexion();

                using (var conexion = conexionBD.AbrirConexion())
                {
                    string sql = "SELECT id_puesto, puesto FROM tbl_puesto;";

                    using (var comando = new MySqlCommand(sql, conexion))
                    using (var adaptador = new MySqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar puestos: " + ex.Message);
            }

            return tabla;
        }

        // Insertar nuevo puesto
        public string InsertarPuesto(string nombrePuesto)
        {
            string msg = "";

            try
            {
                cls_Conexion conexionBD = new cls_Conexion();
                using (var conexion = conexionBD.AbrirConexion())
                {
                    // Verificar si existe
                    string sqlExiste = "SELECT COUNT(*) FROM tbl_puesto WHERE puesto = @nombre;";
                    using (var cmdExiste = new MySqlCommand(sqlExiste, conexion))
                    {
                        cmdExiste.Parameters.AddWithValue("@nombre", nombrePuesto);
                        int existe = Convert.ToInt32(cmdExiste.ExecuteScalar());

                        if (existe > 0)
                        {
                            return "El puesto ya existe.";
                        }
                    }

                    // Insertar
                    string sqlInsert = "INSERT INTO tbl_puesto(puesto) VALUES(@nombre);";
                    using (var cmdInsert = new MySqlCommand(sqlInsert, conexion))
                    {
                        cmdInsert.Parameters.AddWithValue("@nombre", nombrePuesto);
                        int filas = cmdInsert.ExecuteNonQuery();

                        msg = filas > 0 ? "Puesto agregado correctamente." : "No se pudo agregar el puesto.";
                    }
                }
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message;
            }

            return msg;
        }

    }
}
