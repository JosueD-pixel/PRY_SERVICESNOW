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
    internal class cls_reservas
    {
        private MySqlDataAdapter adaptador;
        private DataTable tabla;

        // CARGAR SALAS
        public void CargarSalas(ComboBox combo)
        {
            tabla = new DataTable();

            try
            {
                cls_Conexion conexionBD = new cls_Conexion();
                using (var conexion = conexionBD.AbrirConexion())
                {
                    string sql = "SELECT id_sala, nombre FROM tbl_salas ORDER BY nombre;";

                    adaptador = new MySqlDataAdapter(sql, conexion);
                    adaptador.Fill(tabla);
                }

                combo.DataSource = tabla;
                combo.DisplayMember = "nombre";  
                combo.ValueMember = "id_sala";    
                combo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar salas: " + ex.Message);
            }
        }

        // CARGAR TRABAJADORES
        public void CargarTrabajadores(ComboBox combo)
        {
            tabla = new DataTable();

            try
            {
                cls_Conexion conexionBD = new cls_Conexion();
                using (var conexion = conexionBD.AbrirConexion())
                {
                    string sql = "SELECT clave_trabajador, nombre FROM tbl_trabajadores ORDER BY nombre;";

                    adaptador = new MySqlDataAdapter(sql, conexion);
                    adaptador.Fill(tabla);
                }

                combo.DataSource = tabla;
                combo.DisplayMember = "nombre";
                combo.ValueMember = "clave_trabajador";
                combo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar trabajadores: " + ex.Message);
            }
        }

        public DataTable GenerarHorarioSemana()
        {
            DataTable tabla = new DataTable();

            // Columnas
            tabla.Columns.Add("Hora");
            tabla.Columns.Add("Lunes");
            tabla.Columns.Add("Martes");
            tabla.Columns.Add("Miércoles");
            tabla.Columns.Add("Jueves");
            tabla.Columns.Add("Viernes");

            // Rango de horas
            for (int hora = 8; hora <= 20; hora++)
            {
                DataRow fila = tabla.NewRow();

                fila["Hora"] = hora.ToString("00") + ":00";

                fila["Lunes"] = "Disponible";
                fila["Martes"] = "Disponible";
                fila["Miércoles"] = "Disponible";
                fila["Jueves"] = "Disponible";
                fila["Viernes"] = "Disponible";

                tabla.Rows.Add(fila);
            }

            return tabla;
        }
    }
}
