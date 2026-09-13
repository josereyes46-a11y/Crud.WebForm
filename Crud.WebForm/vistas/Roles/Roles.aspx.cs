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

        private void LimpiarMensajes()
        {
            lblFallo.Text = "";
            lblExito.Text = "";
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            LimpiarMensajes();

            if (!int.TryParse(txtId.Text, out int idRol))
            {
                lblFallo.Text = "Debe ingresar un ID de rol válido";
                return;
            }

            string nombreRol = ddlRol.SelectedValue;

            try
            {
                int idUsuario = int.Parse(ddlUsuario.SelectedValue);

                UsuarioDL usuarioDL = new UsuarioDL();
                if (!usuarioDL.ExisteUsuario(idUsuario))
                {
                    lblFallo.Text = "No se puede asignar rol: el usuario no está registrado.";
                    return;
                }

                RolesBL rolesBL = new RolesBL();
                rolesBL.validarNombreRol(nombreRol);
                rolesBL.validarRolAsignacion(nombreRol);
                rolesBL.validarUnicoRol(nombreRol, idUsuario);

                RolesDL rolesDL = new RolesDL();
                rolesDL.altaRol(idRol, idUsuario, nombreRol);

                CargarRoles();
                lblExito.Text = "Rol registrado correctamente.";
            }
            catch (Exception)
            {
                lblFallo.Text = "No se pueden repetir roles";
            }
        }
      
        protected void btnBaja_Click(object sender, EventArgs e)
        {
            LimpiarMensajes();

            if (!int.TryParse(txtId.Text, out int idRol))
            {
                lblFallo.Text = "Debe ingresar un ID válido";
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
                    lblExito.Text = "Rol eliminado exitosamente.";
                }
                catch (Exception ex)
                {
                    lblFallo.Text = "Error al eliminar el rol: " + ex.Message;
                }
            }
            else
            {
                lblExito.Text = "Operación cancelada por el usuario.";
            }
        }

        protected void btnConsulta_Click(object sender, EventArgs e)
        {
            LimpiarMensajes();

            if (!int.TryParse(txtId.Text, out int idRol))
            {
                lblFallo.Text = "Debe ingresar un ID válido";
                return;
            }

            try
            {
                Crud.EntityLayer.Roles rol = new RolesDL().consultaRol(idRol);

                if (rol != null)
                {
                    ddlRol.SelectedValue = rol.NombreRol;
                    lblExito.Text = $"Rol encontrado. Usuario asignado: {rol.NombreRol}" +
                                      $", ID: {rol.IdUsuario}";
                }
                else
                {
                    lblFallo.Text = "No se encontró un rol con el ID proporcionado.";
                }
            }
            catch (Exception ex)
            {
                lblFallo.Text = ex.Message;
            }
        }

        protected void btnModificacion_Click(object sender, EventArgs e)
        {
            LimpiarMensajes();

            if (!int.TryParse(txtId.Text, out int idRol))
            {
                lblFallo.Text = "Debe ingresar un ID de rol válido";
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
                lblExito.Text = "Rol modificado correctamente.";
            }
            catch (Exception ex)
            {
                lblFallo.Text = "Error: " + ex.Message;
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
