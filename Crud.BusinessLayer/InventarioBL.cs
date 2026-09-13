using Crud.EntityLayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Crud.BusinessLayer
{
    public class InventarioBL
    {
        private string connectionString = "Server=localhost;Database=ferreteria;Uid=root;Pwd=Chalino9;";

        public List<Producto> mostrarInventario()
        {
            List<Producto> inventario = new List<Producto>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT nombre, categoria, cantidad FROM producto";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        inventario.Add(new Producto
                        {
                            Nombre = reader["nombre"].ToString(),
                            Categoria = reader["categoria"].ToString(),
                            Cantidad = Convert.ToInt32(reader["cantidad"])
                        });
                    }
                }
            }

            return inventario;
        }

        public List<Inventario> mostrarEntradas()
        {
            List<Inventario> entradas = new List<Inventario>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT cantidad FROM producto";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        entradas.Add(new Inventario
                        {
                            Cantidad = Convert.ToInt32(reader["cantidad"])
                        });
                    }
                }
            }

            return entradas;
        }

        public List<Inventario> mostrarSalidas()
        {
            List<Inventario> salidas = new List<Inventario>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT cantidad FROM producto";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        salidas.Add(new Inventario
                        {
                            Cantidad = Convert.ToInt32(reader["cantidad"])
                        });
                    }
                }
            }

            return salidas;
        }
    }
}
