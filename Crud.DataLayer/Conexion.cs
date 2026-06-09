using MySql.Data.MySqlClient;
using System.Configuration;

namespace Crud.DataLayer
{
    public class Conexion
    {
        public static MySqlConnection ObtenerConexion()
        {
            string cadena = ConfigurationManager.ConnectionStrings["cadenaMySQL"].ConnectionString;
            MySqlConnection conexion = new MySqlConnection(cadena);
            conexion.Open();
            return conexion;
        }
    }
}
