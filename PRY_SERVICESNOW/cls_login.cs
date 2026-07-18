using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRY_SERVICESNOW
{
    internal class cls_login
    {
        private string clave;
        private string password;

        public string Clave { get => clave; set => clave = value; }
        public string Password { get => password; set => password = value; }

        private static int rol;
        public string nombreRol;

        // Atributos estáticos
        private static bool esAdministrador;
        private static bool esRecepcionista;
        private static bool esTrabajador;

        public static string UsuarioActual;

        // Propiedades estáticas
        public static bool EsAdministrador { get => esAdministrador; }
        public static bool EsRecepcionista { get => esRecepcionista; }
        public static bool EsTrabajador { get => esTrabajador; }
        public static int Rol { get => rol; set => rol = value; }

        public bool ValidarAcceso()
        {
            try
            {
                cls_Conexion conexionBD = new cls_Conexion();

                using (var conexion = conexionBD.AbrirConexion())
                {
                    string sql = "SELECT id_puesto FROM tbl_trabajadores " +
                                 "WHERE clave_trabajador = @clave AND password = @password;";

                    using (var consulta = new MySqlCommand(sql, conexion))
                    {
                        consulta.Parameters.AddWithValue("@clave", clave);
                        consulta.Parameters.AddWithValue("@password", password);

                        using (var resultado = consulta.ExecuteReader())
                        {
                            if (resultado.Read())
                            {
                                rol = resultado.GetInt32("id_puesto");

                                switch (rol)
                                {
                                    case 1:
                                        nombreRol = "Administrador";
                                        break;

                                    case 2:
                                        nombreRol = "Recepcionista";
                                        break;

                                    case 3:
                                        nombreRol = "Trabajador";
                                        break;

                                    default:
                                        nombreRol = "Desconocido";
                                        break;
                                }

                                UsuarioActual = clave;
                                AsignarPermisos();

                                // Si no tiene permisos para entrar al sistema
                                if (!esAdministrador && !esRecepcionista && !esTrabajador)
                                {
                                    throw new Exception($"El perfil {nombreRol} no tiene permisos para acceder");
                                }

                                return true;
                            }
                            else
                            {
                                throw new Exception("Usuario o contraseña incorrectos");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void AsignarPermisos()
        {
            switch (nombreRol)
            {
                case "Administrador":
                    esAdministrador = true;
                    esRecepcionista = false;
                    esTrabajador = false;
                    break;

                case "Recepcionista":
                    esAdministrador = false;
                    esRecepcionista = true;
                    esTrabajador = false;
                    break;

                case "Trabajador":
                    esAdministrador = false;
                    esRecepcionista = false;
                    esTrabajador = true;
                    break;

                default:
                    esAdministrador = false;
                    esRecepcionista = false;
                    esTrabajador = false;
                    break;
            }
        }

    }
}
