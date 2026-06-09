using System;
using Crud.DataLayer;

namespace Crud.WebForm
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    using (var conexion = new ConexionBD().ObtenerConexion())
                    {
                        
                        //Response.Write("Se ha conectado a la base de datos");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("No se conecto a la base de datos " + ex.Message);
                }
            }
        }

        
    }
}
