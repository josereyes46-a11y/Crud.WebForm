using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Crud.DataLayer
{
    public class AutentificacionUsuarioDL
    {
        private readonly string connectionString =
            "server=localhost;port=3306;database=ferreteria;uid=root;pwd=Chalino9;";

        public bool validarLogin(string NombreUsuario, string Contrasena)
        {
            if (NombreUsuario == null || Contrasena == null
                || NombreUsuario == "" || Contrasena == "")
            {
                throw new Exception("Debe ingresar un nombre de usuario y contraseña");
            }
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM usuario WHERE nombre_usuario=@user AND contrasena=@pass";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", NombreUsuario);
                cmd.Parameters.AddWithValue("@pass", Contrasena);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }

        public bool validarRegistroExistente(int IdUsuario, string NombreUsuario)
        {
            if (IdUsuario <= 0 || string.IsNullOrWhiteSpace(NombreUsuario))
                throw new Exception("Debe ingresar un ID válido y un nombre de usuario.");

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM usuario WHERE id_usuario=@id OR nombre_usuario=@user";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", IdUsuario);
                cmd.Parameters.AddWithValue("@user", NombreUsuario);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0; 
            }
        }

        public string ObtenerRolUsuario(string user, string pass)
        {
            string rol = string.Empty;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"SELECT r.nombre_rol
                         FROM usuario u
                         INNER JOIN roles r ON u.id_usuario = r.id_usuario
                         WHERE u.nombre_usuario = @user AND u.contrasena = @pass";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", pass);

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    rol = result.ToString();
                }
            }

            return rol;
        }


    }
}
