using Crud.BusinessLayer;
using Crud.DataLayer;
using Crud.EntityLayer;
using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Web.UI;
using System.Windows.Forms;

namespace Crud.WebForm
{
    public partial class Roles : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
                if (!IsPostBack)
                {
                    CargarRoles();
                    UsuarioDL usuarioDL = new UsuarioDL();
                    ddlUsuario.DataSource = usuarioDL.obtenerTodosUsuarios();
                    ddlUsuario.DataTextField = "Nombre";   
                    ddlUsuario.DataValueField = "IdUsuario";
                    ddlUsuario.DataBind();
                }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int idRol))
            {
                lblMensaje.Text = "Debe ingresar un ID de rol válido";
                return;
            }

            string nombreRol = ddlRol.SelectedValue;

            try
            {
                int idUsuario = int.Parse(ddlUsuario.SelectedValue);

                UsuarioDL usuarioDL = new UsuarioDL();
                if (!usuarioDL.ExisteUsuario(idUsuario))
                {
                    lblMensaje.Text = "No se puede asignar rol: el usuario no está registrado.";
                    return;
                }

                RolesBL rolesBL = new RolesBL();
                rolesBL.validarNombreRol(nombreRol);
                rolesBL.validarRolAsignacion(nombreRol);
                rolesBL.validarUnicoRol(nombreRol, idUsuario);

                RolesDL rolesDL = new RolesDL();
                rolesDL.altaRol(idRol, idUsuario, nombreRol);

                CargarRoles();
                lblMensaje.Text = "Rol registrado correctamente.";
            }
            catch (Exception)
            {
                lblMensaje.Text = "No se pueden repetir roles";
            }
        }
      
        protected void btnBaja_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int idRol))
            {
                lblMensaje.Text = "Debe ingresar un ID válido";
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de eliminar el rol con ID: " + idRol + "?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    RolesDL rolesDL = new RolesDL();
                    rolesDL.bajaRol(idRol);

                    CargarRoles();
                    lblMensaje.Text = "Rol eliminado exitosamente.";
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error al eliminar el rol: " + ex.Message;
                }
            }
            else
            {
                lblMensaje.Text = "Operación cancelada por el usuario.";
            }
        }

        protected void btnConsulta_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int idRol))
            {
                lblMensaje.Text = "Debe ingresar un ID válido";
                return;
            }

            try
            {
                Crud.EntityLayer.Roles rol = new RolesDL().consultaRol(idRol);

                if (rol != null)
                {
                    ddlRol.SelectedValue = rol.NombreRol;
                    lblMensaje.Text = $"Rol encontrado. Usuario asignado: {rol.NombreRol}" +
                                      $", ID: {rol.IdUsuario}";
                }
                else
                {
                    lblMensaje.Text = "No se encontró un rol con el ID proporcionado.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int idRol))
            {
                lblMensaje.Text = "Debe ingresar un ID de rol válido";
                return;
            }

            string nombreRol = ddlRol.SelectedValue;

            try
            {
                RolesBL rolesBL = new RolesBL();
                rolesBL.validarNombreRol(nombreRol);
                rolesBL.validarRolAsignacion(nombreRol);

                int idUsuario = 1; 

                RolesDL rolesDL = new RolesDL();
                rolesDL.modificacionRol(idRol, idUsuario, nombreRol);

                CargarRoles();
                lblMensaje.Text = "Rol modificado correctamente.";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/vistas/Modulos/Modulos.aspx");
        }

        private void CargarRoles()
        {
            RolesDL rolesDL = new RolesDL();
            gvRoles.DataSource = rolesDL.obtenerTodosRoles();
            gvRoles.DataBind();
        }
    }
}
