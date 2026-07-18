using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRY_SERVICESNOW
{
    internal class cls_Conexion
    {
        private string host = "localhost";
        private string bd = "bd_servicesnow";
        private string usuario = "root";
        private string password = "";
        private string puerto = "3306";

        private string cadenaConexion => $"server={host};database={bd};user={usuario};password={password};port={puerto}";

        public MySqlConnection AbrirConexion()
        {
            var conexion = new MySqlConnection(cadenaConexion);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar conectarse a la base de datos: " + ex.Message, ex);
            }
        }

        public void CerrarConexion(MySqlConnection conexion)
        {
            try
            {
                if (conexion != null && conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                    conexion.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar la conexión con la base de datos: " + ex.Message, ex);
            }
        }
      
     }
}
