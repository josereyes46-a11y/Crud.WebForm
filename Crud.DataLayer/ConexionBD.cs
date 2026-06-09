using System;
using MySql.Data.MySqlClient;

namespace Crud.DataLayer
{
    public class ConexionBD
    {
        public string connectionString = "Server=localhost;Port=3306;Database=ferreteria;Uid=root;Pwd=Chalino9;";

        public MySqlConnection ObtenerConexion()
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(connectionString);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message);
            }
        }
    }
}
