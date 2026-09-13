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
    public class ProductoDL
    {
        private readonly string connectionString =
            "server=localhost;port=3306;database=ferreteria;uid=root;pwd=Chalino9;";

        public void altaProducto(int ClaveProducto, string Nombre, string Categoria, string Descripcion, int Cantidad)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO producto (clave_producto, nombre, categoria, descripcion, cantidad) VALUES (@ClaveProducto, @Nombre, @Categoria, @Descripcion, @Cantidad)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClaveProducto", ClaveProducto);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Categoria", Categoria);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                conn.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void bajaProducto(int ClaveProducto)
        {

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM producto WHERE clave_producto = @ClaveProducto";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClaveProducto", ClaveProducto);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Producto consultaProducto(int ClaveProducto)
        {
            Producto producto = null;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT clave_producto, nombre, categoria, descripcion, cantidad " +
                               "FROM producto WHERE clave_producto=@ClaveProducto";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClaveProducto", ClaveProducto);

                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        producto = new Producto();
                        {

                            producto.ClaveProducto = reader.GetInt32("clave_producto");
                            producto.Nombre = reader.GetString("nombre");
                            producto.Categoria = reader.GetString("categoria");
                            producto.Descripcion = reader.GetString("descripcion");
                            producto.Cantidad = reader.GetInt32("cantidad");    
                        };
                    }
                }
            }
        
            return producto;
        }
        
        public void modificacionProducto(int ClaveProducto, string Nombre, string Categoria, string Descripcion, int Cantidad)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "UPDATE producto SET nombre = @Nombre, categoria = @Categoria, descripcion = @Descripcion, cantidad = @Cantidad WHERE clave_producto = @ClaveProducto";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClaveProducto", ClaveProducto);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Categoria", Categoria);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@Cantidad", Cantidad);

                conn.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("No se encontró ningún producto con esa clave o los datos son idénticos.");
                }
            }
        }
        public List<Producto> obtenerTodosProductos()
        {
            List<Producto> lista = new List<Producto>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT 
                                    clave_producto AS ClaveProducto,
                                    nombre AS Nombre,
                                    categoria AS Categoria,
                                    descripcion AS Descripcion,
                                    cantidad AS Cantidad
                                 FROM producto";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Producto p = new Producto
                            {
                                ClaveProducto = reader.GetInt32("ClaveProducto"),
                                Nombre = reader.GetString("Nombre"),
                                Categoria = reader.GetString("Categoria"),
                                Descripcion = reader.GetString("Descripcion"),
                                Cantidad = reader.GetInt32("Cantidad")
                            };
                            lista.Add(p);
                        }
                    }
                }
            }

            return lista;
        }
    }
}
