using System;

namespace Crud.WebForm
{
    public partial class Modulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rol = Session["Rol"]?.ToString();

            if (rol == "Administrador")
            {
                btnUsuarios.Visible = true;
                btnRoles.Visible = true;
                btnProductos.Visible = true;
                btnCatalogo.Visible = true;
                btnInventario.Visible = true;
            }
            else if (rol == "Empleado")
            {
                btnUsuarios.Visible = false;
                btnRoles.Visible = false;
                btnProductos.Visible = true;
                btnCatalogo.Visible = true;
                btnInventario.Visible = true;
            }
            else
            {
                lblMensaje.Text = "Rol no reconocido.";
            }
        }

        protected void btnUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/vistas/Usuario/Usuario.aspx");
        }

        protected void btnRoles_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/vistas/Roles/Roles.aspx");
        }

        protected void btnProductos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/vistas/Productos/Productos.aspx");
        }

        protected void btnCatalogo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/vistas/CatalogoProductos/CatalogoProductos.aspx");
        }

        protected void btnInventario_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/vistas/GestionInventario/GestionInventario.aspx");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/vistas/Login/Login.aspx");
        }
    }
}
