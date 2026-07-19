using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRY_SERVICESNOW
{
    internal class clsTrabajadores
    {
        // Atributos privados

        private string clave_trabajador;
        private string nombre;
        private string apellidoP;
        private string apellidoM;
        private string telefono;
        private string correo;
        private string cp;
        private string calle;
        private string colonia;

        private string contrasena;
        private int estado;
        private int idPuesto;

        // Adaptadores
        private MySqlDataAdapter adaptador;
        private MySqlCommand comando;
        private DataTable tabla;

        public string Clave_trabajador { get => clave_trabajador; set => clave_trabajador = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string ApellidoP { get => apellidoP; set => apellidoP = value; }
        public string ApellidoM { get => apellidoM; set => apellidoM = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Cp { get => cp; set => cp = value; }
        public string Calle { get => calle; set => calle = value; }
        public string Colonia { get => colonia; set => colonia = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public int Estado { get => estado; set => estado = value; }
        public int IdPuesto { get => idPuesto; set => idPuesto = value; }

        // Cargar todos los trabajadores
        public DataTable CargarDataGrid()
        {
            tabla = new DataTable();

            try
            {
                cls_Conexion conexionBD = new cls_Conexion();
                using (var conexion = conexionBD.AbrirConexion())
                {
                    string sql = @"SELECT 
                            t.clave_trabajador AS Clave,
                            t.nombre AS Nombre,
                            t.apellidoP AS Paterno,
                            t.apellidoM AS Materno,
                            t.telefono AS Telefono,
                            t.correo AS Correo,
                            t.codigo_postal AS CP,
                            t.calle AS Calle,
                            t.colonia AS Colonia,
                            t.estado AS Estado,
                            p.id_puesto AS IdPuesto,
                            p.puesto AS Puesto,
                            t.password AS Password
                        FROM tbl_trabajadores t
                        INNER JOIN tbl_puesto p ON t.id_puesto = p.id_puesto;";

                    adaptador = new MySqlDataAdapter(sql, conexion);
                    adaptador.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar trabajadores: " + ex.Message);
            }

            return tabla;
        }

        // Buscar trabajadores
        public DataTable Consultar(string dato)
        {
            tabla = new DataTable();

            try
            {
                cls_Conexion conexionBD = new cls_Conexion();
                using (var conexion = conexionBD.AbrirConexion())
                {
                    string sql = @"SELECT 
                                  clave_trabajador AS Clave,
                                  nombre AS Nombre,
                                  apellidoP AS Paterno,
                                  apellidoM AS Materno,
                                  telefono AS Telefono,
                                  correo AS Correo,
                                  codigo_postal AS CP,
                                  calle AS Calle,
                                  colonia AS Colonia,
                                  estado AS Estado,
                                  id_puesto AS Puesto,
                                  password AS Password
                             FROM Tbl_trabajadores
                            WHERE clave_trabajador LIKE @dato
                                  OR nombre LIKE @dato
                                  OR apellidoP LIKE @dato
                                  OR apellidoM LIKE @dato
                                  OR correo LIKE @dato
                                  OR telefono LIKE @dato;";
                    comando = new MySqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@dato", "%" + dato + "%");

                    adaptador = new MySqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar trabajadores: " + ex.Message);
            }

            return tabla;
        }

        // Eliminar trabajador
        public string Eliminar()
        {
            string msg = "";

            try
            {
                cls_Conexion conexionBD = new cls_Conexion();
                using (var conexion = conexionBD.AbrirConexion())
                {
                    string sql = "DELETE FROM tbl_trabajadores WHERE clave_trabajador = @clave;";
                    comando = new MySqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@clave", Clave_trabajador);

                    int filas = comando.ExecuteNonQuery();
                    msg = filas > 0 ? "Trabajador eliminado correctamente" : "No se pudo eliminar el trabajador";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar trabajador: " + ex.Message);
            }

            return msg;
        }

        // Guardar o actualizar
        public string GuardarActualizar(int tipo)
        {
            string msg = "";

            try
            {
                cls_Conexion conexionBD = new cls_Conexion();
                using (var conexion = conexionBD.AbrirConexion())
                {
                    if (tipo == 0) // INSERTAR
                    {
                        string sql = @"INSERT INTO tbl_trabajadores
                            (clave_trabajador, nombre, apellidoP, apellidoM,
                             telefono, correo, password, codigo_postal, calle, colonia,
                             estado, id_puesto)
                            VALUES
                            (@clave, @nombre, @ap, @am, @tel, @correo, @pass,
                             @cp, @calle, @colonia, @estado, @puesto);";

                        comando = new MySqlCommand(sql, conexion);
                    }
                    else // ACTUALIZAR
                    {
                        string sql = @"UPDATE tbl_trabajadores SET
                            nombre = @nombre,
                            apellidoP = @ap,
                            apellidoM = @am,
                            telefono = @tel,
                            correo = @correo,
                            password = @pass,
                            codigo_postal = @cp,
                            calle = @calle,
                            colonia = @colonia,
                            estado = @estado,
                            id_puesto = @puesto
                            WHERE clave_trabajador = @clave;";

                        comando = new MySqlCommand(sql, conexion);
                    }

                    comando.Parameters.AddWithValue("@clave", Clave_trabajador);
                    comando.Parameters.AddWithValue("@nombre", Nombre);
                    comando.Parameters.AddWithValue("@ap", ApellidoP);
                    comando.Parameters.AddWithValue("@am", ApellidoM);
                    comando.Parameters.AddWithValue("@tel", Telefono);
                    comando.Parameters.AddWithValue("@correo", Correo);
                    comando.Parameters.AddWithValue("@pass", Contrasena);
                    comando.Parameters.AddWithValue("@cp", Cp);
                    comando.Parameters.AddWithValue("@calle", Calle);
                    comando.Parameters.AddWithValue("@colonia", Colonia);
                    comando.Parameters.AddWithValue("@estado", Estado);
                    comando.Parameters.AddWithValue("@puesto", IdPuesto);

                    int filas = comando.ExecuteNonQuery();
                    msg = filas > 0 ? "Operación realizada correctamente" : "No se pudo completar la operación";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en GuardarActualizar: " + ex.Message);
            }

            return msg;
        }

        // Limpiar panel
        public void LimpiarPanel(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is TextBox txt)
                    txt.Clear();

                if (control is ComboBox cmb)
                    cmb.SelectedIndex = 0;

                if (control is CheckBox chk)
                    chk.Checked = false;
            }
        }

    }
}
