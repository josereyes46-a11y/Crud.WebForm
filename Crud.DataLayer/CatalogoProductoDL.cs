using Crud.EntityLayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.DataLayer
{
    public class CatalogoProductoDL
    {
        private string connectionString = "Server=localhost;Database=ferreteria;Uid=root;Pwd=Chalino9;";

        public List<Producto> obtenerCatalogo()
        {
            List<Producto> productos = new List<Producto>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT Nombre, Categoria, Cantidad FROM producto";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        productos.Add(new Producto
                        {
                            Nombre = reader.GetString("Nombre"),
                            Categoria = reader.GetString("Categoria"),
                            Cantidad = reader.GetInt32("Cantidad")

                        });
                    }
                }
            }
            return productos;
        }

        public List<Producto> obtenerNombre()
        {
            List<Producto> nombre = new List<Producto>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT Nombre FROM producto";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        nombre.Add(new Producto
                        {
                            Nombre = reader.GetString("Nombre"),
                        });
                    }
                }
            }
            return nombre;
        }

        public List<Producto> obtenerCategoria()
        {
            List<Producto> categoria = new List<Producto>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT Categoria FROM producto";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categoria.Add(new Producto
                        {
                            Categoria = reader.GetString("Categoria"),

                        });
                    }
                }
            }
            return categoria;

        }

        public List<Producto> obtenerCantidad()
        {
            List<Producto> cantidad = new List<Producto>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT Cantidad FROM producto";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cantidad.Add(new Producto
                        {
                            Cantidad = reader.GetInt32("Cantidad")

                        });
                    }
                }
            }
            return cantidad;

        }
    }

}
