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
    internal class cls_AsignarMobiliarios
    {
        private int id_asignacionM;
        private int id_mobiliario;
        private int id_sala;
        private int cantidad_pasada;
        private string folio;

        private MySqlDataAdapter consulta;
        private MySqlCommand comando;
        private DataTable tabla;

        public int Id_AsignacionM { get => id_asignacionM; set => id_asignacionM = value; }
        public int Id_mobiliario { get => id_mobiliario; set => id_mobiliario = value; }
        public int Id_sala { get => id_sala; set => id_sala = value; }
        public int Cantidad_pasada { get => cantidad_pasada; set => cantidad_pasada = value; }
        public string Folio { get => folio; set => folio = value; }

        public DataTable CargarSalas()
        {
            tabla = new DataTable();
            cls_Conexion conexionBD = new cls_Conexion();

            using (var conexion = conexionBD.AbrirConexion())
            {
                string sql = "SELECT id_sala, nombre FROM tbl_salas WHERE estado = 1";
                using (consulta = new MySqlDataAdapter(sql, conexion))
                {
                    consulta.Fill(tabla);
                }
            }
            return tabla;
        }

        public DataTable CargarMobiliario()
        {
            tabla = new DataTable();
            cls_Conexion conexionBD = new cls_Conexion();

            using (var conexion = conexionBD.AbrirConexion())
            {
                string sql = "SELECT id_mobiliario, nombre FROM tbl_mobiliario";
                using (consulta = new MySqlDataAdapter(sql, conexion))
                {
                    consulta.Fill(tabla);
                }
            }
            return tabla;
        }

        public DataTable CargarDataGrid()
        {
            tabla = new DataTable();
            cls_Conexion conexionBD = new cls_Conexion();

            using (var conexion = conexionBD.AbrirConexion())
            {
                string sql = @"
        SELECT 
            s.nombre AS Sala,
            m.nombre AS Mobiliario,
            a.cantidad_pasada AS Cantidad,
            a.folio AS Folio
        FROM tbl_asignacion_mobiliario a
        INNER JOIN tbl_salas s ON a.id_sala = s.id_sala
        INNER JOIN tbl_mobiliario m ON a.id_mobiliario = m.id_mobiliario;
        ";

                using (consulta = new MySqlDataAdapter(sql, conexion))
                {
                    consulta.Fill(tabla);
                }
            }
            return tabla;
        }

        public bool ValidarAsignacion(int idSala, int idMobiliario, int cantidadNueva)
        {
            int capacidadSala = ObtenerCapacidadSala(idSala);
            int cantidadActualEnSala = ObtenerCantidadAsignada(idSala, idMobiliario);
            int disponible = ObtenerCantidadDisponible(idMobiliario);

            if (cantidadActualEnSala + cantidadNueva > capacidadSala)
            {
                MessageBox.Show("La cantidad supera la capacidad de la sala.");
                return false;
            }

            if (cantidadNueva > disponible)
            {
                MessageBox.Show("No hay suficiente mobiliario disponible.");
                return false;
            }

            return true;
        }

        private int ObtenerCapacidadSala(int idSala)
        {
            int capacidad = 0;
            cls_Conexion conexionBD = new cls_Conexion();

            using (var conexion = conexionBD.AbrirConexion())
            {
                string sql = "SELECT capacidad FROM tbl_salas WHERE id_sala = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", idSala);
                    capacidad = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return capacidad;
        }

        private int ObtenerCantidadAsignada(int idSala, int idMobiliario)
        {
            int cantidad = 0;
            cls_Conexion conexionBD = new cls_Conexion();

            using (var conexion = conexionBD.AbrirConexion())
            {
                string sql = @"SELECT IFNULL(SUM(cantidad_pasada), 0)
                        FROM tbl_asignacion_mobiliario
                        WHERE id_sala = @sala AND id_mobiliario = @mob";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@sala", idSala);
                    cmd.Parameters.AddWithValue("@mob", idMobiliario);
                    cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return cantidad;
        }

        public int ObtenerCantidadAsignada(int id_mobiliario)
        {
            int total = 0;
            cls_Conexion conexionBD = new cls_Conexion();

            using (var conexion = conexionBD.AbrirConexion())
            {
                string sql = @"SELECT IFNULL(SUM(cantidad_pasada), 0)
                        FROM tbl_asignacion_mobiliario
                        WHERE id_mobiliario = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", id_mobiliario);
                    total = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return total;
        }

        public int ObtenerInventario(int id_mobiliario)
        {
            int cantidad = 0;
            cls_Conexion conexionBD = new cls_Conexion();

            using (var conexion = conexionBD.AbrirConexion())
            {
                string sql = @"SELECT cantidad FROM tbl_mobiliario WHERE id_mobiliario = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", id_mobiliario);
                    cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return cantidad;
        }

        public int ObtenerCantidadDisponible(int id_mobiliario)
        {
            int inventario = ObtenerInventario(id_mobiliario);
            int asignado = ObtenerCantidadAsignada(id_mobiliario);
            return inventario - asignado;
        }

        public string GuardarAsignacion()
        {
            string msg = "";
            cls_Conexion conexionBD = new cls_Conexion();

            using (var conexion = conexionBD.AbrirConexion())
            {
                string sql = @"
         INSERT INTO tbl_asignacion_mobiliario(id_mobiliario, id_sala, cantidad_pasada, folio)
         VALUES (@id_mobiliario, @id_sala, @cantidad_pasada, @folio);
         ";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@id_mobiliario", Id_mobiliario);
                    cmd.Parameters.AddWithValue("@id_sala", Id_sala);
                    cmd.Parameters.AddWithValue("@cantidad_pasada", Cantidad_pasada);
                    cmd.Parameters.AddWithValue("@folio", GenerarFolio());


                    int filas = cmd.ExecuteNonQuery();
                    msg = filas > 0 ? "Asignación registrada correctamente" : "No se pudo registrar la asignación";
                }
            }
            return msg;
        }

        public bool ModificarCantidad()
        {
            cls_Conexion conexionBD = new cls_Conexion();

            using (var conexion = conexionBD.AbrirConexion())
            {
                string sql = @"UPDATE tbl_asignacion_mobiliario 
                        SET cantidad_pasada = @cantidad
                        WHERE id_asignacionM = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@cantidad", Cantidad_pasada);
                    cmd.Parameters.AddWithValue("@id", Id_AsignacionM);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Eliminar()
        {
            cls_Conexion conexionBD = new cls_Conexion();

            using (var conexion = conexionBD.AbrirConexion())
            {
                string sql = @"DELETE FROM tbl_asignacion_mobiliario 
                        WHERE id_asignacionM = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", Id_AsignacionM);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public DataTable Buscar(string filtro)
        {
            tabla = new DataTable();
            cls_Conexion conexionBD = new cls_Conexion();

            using (var conexion = conexionBD.AbrirConexion())
            {
                string sql = @"
     SELECT 
         a.id_asignacionM,
         a.id_mobiliario,
         a.id_sala,
         a.cantidad_pasada,
         s.nombre AS Sala,
         m.nombre AS Mobiliario,
         a.folio
     FROM tbl_asignacion_mobiliario a
     INNER JOIN tbl_salas s ON a.id_sala = s.id_sala
     INNER JOIN tbl_mobiliario m ON a.id_mobiliario = m.id_mobiliario
     WHERE 
         a.id_asignacionM LIKE @filtro
         OR s.nombre LIKE @filtro
         OR m.nombre LIKE @filtro
     ORDER BY a.id_asignacionM ASC;
 ";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(tabla);
                    }
                }
            }

            return tabla;
        }

        public string GenerarFolio()
        {
            cls_Conexion conexionBD = new cls_Conexion();
            int ultimoFolio = 0;

            using (var conexion = conexionBD.AbrirConexion())
            {
                string sql = "SELECT IFNULL(MAX(id_asignacionM), 0) FROM tbl_asignacion_mobiliario";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexion))
                {
                    ultimoFolio = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            // Incrementa el folio
            ultimoFolio++;

            // Formato: FOL-001
            return "FOL-" + ultimoFolio.ToString("000");
        }

    }
}
