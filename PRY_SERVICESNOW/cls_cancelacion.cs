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
    internal class cls_cancelacion
    {

        public DataTable CargarReservasActivas()
        {
            DataTable tabla = new DataTable();

            try
            {
                cls_Conexion conexionBD = new cls_Conexion();

                using (var conexion = conexionBD.AbrirConexion())
                {
                    string sql = @"
                SELECT 
                    R.id_reserva,
                    S.nombre AS Sala,
                    T.nombre AS Trabajador,
                    R.fecha_uso,
                    R.hora_inicio,
                    R.hora_fin,
                    R.motivo
                FROM tbl_reservas R
                INNER JOIN tbl_salas S ON R.id_sala = S.id_sala
                INNER JOIN tbl_trabajadores T ON R.clave_trabajador = T.clave_trabajador
                WHERE R.estado = 1
                ORDER BY R.fecha_uso, R.hora_inicio;
            ";

                    MySqlDataAdapter adaptador = new MySqlDataAdapter(sql, conexion);
                    adaptador.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reservas: " + ex.Message);
            }

            return tabla;
        }



    }
}
