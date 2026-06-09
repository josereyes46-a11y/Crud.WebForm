using System;
using Crud.DataLayer;
using Microsoft.Ajax.Utilities;

namespace Crud.WebForm
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;

            if (user == null && pass == null
                && user == "" && pass == "")
            {
                lblError.Text = "Debe ingresar un nombre de usuario y contraseña";
                return;
            }
            else if (user == null || user == "" )
            {
                lblError.Text = "Debe ingresar un nombre de usuario";
                return;
            }
            else if (pass == null || pass == "")
            {
                lblError.Text = "Debe ingresar una contraseña";
                return;
            }

            AutentificacionUsuarioDL dao = new AutentificacionUsuarioDL();
            bool valido = dao.validarLogin(user, pass);

            if (valido)
            {
                string rol = dao.ObtenerRolUsuario(user, pass); 

                Session["Usuario"] = user;
                Session["Rol"] = rol; 
                Response.Redirect("~/vistas/Modulos/Modulos.aspx");
            }
            else
            {
                lblError.Text = "Usuario o contraseña incorrectos";
            }

        }
    }
}
