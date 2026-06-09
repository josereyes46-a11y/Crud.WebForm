using Crud.EntityLayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Crud.DataLayer
{
    public class InventarioDL
    {
        public void obtenerInventario()
        {
            List<Producto> productos = new List<Producto>();
            using (MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;database=ferreteria;uid=root;pwd=Chalino9;"))
            {
                string query = "SELECT clave_producto, nombre, categoria, descripcion, cantidad FROM producto";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Producto producto = new Producto
                    {
                        ClaveProducto = reader.GetInt32("clave_producto"),
                        Nombre = reader.GetString("nombre"),
                        Categoria = reader.GetString("categoria"),
                        Descripcion = reader.GetString("descripcion"),
                        Cantidad = reader.GetInt32("cantidad")
                    };
                    productos.Add(producto);
                }
            }
        }
    }
}
