using Crud.BusinessLayer;
using MySql.Data.MySqlClient;
using System;
using System.Web.UI;

namespace Crud.WebForm.vistas.GestionInventario
{
    public partial class GestionInventario : System.Web.UI.Page
    {
        private readonly InventarioBL _businessLayer = new InventarioBL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTodasLasTablas();
            }
        }

        private void CargarTodasLasTablas()
        {
            // Inventario
            gvInventario.DataSource = _businessLayer.mostrarInventario();
            gvInventario.DataBind();

            // Entradas
            gvEntradas.DataSource = _businessLayer.mostrarEntradas();
            gvEntradas.DataBind();

            // Salidas
            gvSalidas.DataSource = _businessLayer.mostrarSalidas();
            gvSalidas.DataBind();

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/vistas/Modulos/Modulos.aspx");
        }
    }
}