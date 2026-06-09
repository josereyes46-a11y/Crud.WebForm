using Crud.EntityLayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Crud.DataLayer
{
    public class RolesDL
    {
        private readonly string connectionString =
        "server=localhost;port=3306;database=ferreteria;uid=root;pwd=Chalino9;";

        public void altaRol(int IdRol, int IdUsuario, string NombreRol)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO roles (id_rol, id_usuario, nombre_rol) VALUES (@IdRol, @IdUsuario, @NombreRol)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdRol", IdRol);
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    cmd.Parameters.AddWithValue("@NombreRol", NombreRol);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void bajaRol(int IdRol)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM roles WHERE id_rol=@IdRol";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdRol", IdRol);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Roles consultaRol(int IdRol)
        {
            Roles rol = null;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id_rol, id_usuario, nombre_rol FROM roles WHERE id_rol=@IdRol";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdRol", IdRol);

                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            rol = new Roles
                            {
                                IdRol = reader.GetInt32("id_rol"),
                                IdUsuario = reader.GetInt32("id_usuario"),
                                NombreRol = reader.GetString("nombre_rol")
                            };
                        }
                    }
                }
            }
            return rol;
        }

        public Roles consultaRol(string NombreRol, int IdUsuario)
        {
            Roles rol = null;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT id_rol, id_usuario, nombre_rol FROM roles WHERE nombre_rol=@NombreRol AND id_usuario=@IdUsuario";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NombreRol", NombreRol);
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            rol = new Roles
                            {
                                IdRol = reader.GetInt32("id_rol"),
                                IdUsuario = reader.GetInt32("id_usuario"),
                                NombreRol = reader.GetString("nombre_rol")
                            };
                        }
                    }
                }
            }
            return rol;
        }

        public void modificacionRol(int idRol, int idUsuario, string nombreRol)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE roles SET id_usuario = @usuario, nombre_rol = @rol WHERE id_rol = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", idUsuario);
                    cmd.Parameters.AddWithValue("@rol", nombreRol);
                    cmd.Parameters.AddWithValue("@id", idRol);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Roles> obtenerTodosRoles()
        {
            List<Roles> lista = new List<Roles>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id_rol, id_usuario, nombre_rol FROM roles";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Roles rol = new Roles
                            {
                        IdRol = reader.GetInt32("id_rol"),
                        IdUsuario = reader.GetInt32("id_usuario"),
                        NombreRol = reader.GetString("nombre_rol")
                    };
                    lista.Add(rol);
                }
            }
            return lista;
        }
    }
}}
}
