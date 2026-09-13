using Crud.BusinessLayer;
using Crud.DataLayer;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.Services.Description;
using System.Web.UI;
using System.Windows.Forms;


namespace Crud.WebForm
{
    public partial class Usuario : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
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

            string id = txtId.Text;
            string nombre = txtNombre.Text;
            string apellidoP = txtApellidoP.Text;
            string apellidoM = txtApellidoM.Text;
            string usuario = txtUsuario.Text;
            string pass = txtPass.Text;

            if (id == null || nombre == null || apellidoP == null || apellidoM == null || usuario == null || pass == null
                || id == "" || apellidoP == "" || apellidoM == "" || usuario == "" || pass == "")
            {
                lblFallo.Text = "Debe llenar todos los campos para registrar un usuario";
                return;
            }

            
            try
            {
                UsuarioBL usuarioBL = new UsuarioBL();

                usuarioBL.validarNombre(nombre, apellidoP, apellidoM);
                usuarioBL.validarContrasena(pass);
                usuarioBL.validarID(int.Parse(id));
                usuarioBL.validarCampos(int.Parse(id), nombre, apellidoP, apellidoM, pass);
                usuarioBL.validarUnicoUsuario(int.Parse(id), usuario);

                UsuarioDL usuarioDL = new UsuarioDL();
                usuarioDL.altaUsuario(int.Parse(id), nombre, apellidoP, apellidoM, usuario, pass);
                
                txtId.Text = "";
                txtNombre.Text = "";
                txtApellidoP.Text = "";
                txtApellidoM.Text = "";
                txtUsuario.Text = "";
                txtPass.Text = "";

                CargarUsuarios();
                

                lblExito.Text = "Usuario registrado correctamente";
            }
            catch (Exception ex)
            {
                txtId.Text = "";
                txtNombre.Text = "";
                txtApellidoP.Text = "";
                txtApellidoM.Text = "";
                txtUsuario.Text = "";
                txtPass.Text = "";
                lblFallo.Text = ex.Message;
            }


        }
        protected void btnBaja_Click(object sender, EventArgs e)
        {
            LimpiarMensajes();

            string id = txtId.Text;

            if (id == null || id == "")
            {
                lblFallo.Text = "Debe ingresar un ID para eliminar un usuario";
                return;
            }
            try
            {
                UsuarioDL usuarioDL = new UsuarioDL();
                DialogResult resultado = MessageBox.Show(
                "¿Está seguro de eliminar el usuario con ID: " + id + "?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                
                if (resultado == DialogResult.Yes)
                {
                    usuarioDL.bajaUsuario(int.Parse(id));
                    txtId.Text = "";
                    CargarUsuarios();

                    lblExito.Text = "Usuario eliminado correctamente";
                }
                else
                {
                    txtId.Text = "";
                    lblFallo.Text = "Operación cancelada por el usuario";
                }

            }
            catch (Exception)
            {
                lblFallo.Text = "No se encuentra el ID registrado";
            }

        }
        protected void btnConsulta_Click(object sender, EventArgs e)
        {
            LimpiarMensajes();

            if (txtId.Text == null || txtId.Text == "")
            {
                lblFallo.Text = "Debe ingresar un ID para consultar un usuario";
                return;
            }

            try
            {
                int id = int.Parse(txtId.Text);
                UsuarioDL usuarioDL = new UsuarioDL();
                Crud.DataLayer.Usuario usuario = usuarioDL.consultaUsuario(id);

                if (usuario != null)
                {
                    
                    lblExito.Text = "Consulta: " + Environment.NewLine

                                      + "Nombre: " + usuario.Nombre + " " + Environment.NewLine
                                      + "Apellido Paterno: " + usuario.ApellidoPaterno + " " + Environment.NewLine
                                      + "Apellido Materno: " + usuario.ApellidoMaterno + " " + Environment.NewLine
                                      + "Nombre de Usuario: " + usuario.NombreUsuario + " ";                
                }
                else
                {
                    lblFallo.Text = "No se encuentra el usuario registrado";
                }
            }
            catch (Exception ex)
            {
                lblFallo.Text = "No se ha encontrado el ID" + ex; 
            }
        }



        protected void btnModificacion_Click(object sender, EventArgs e)
        {
            LimpiarMensajes();

            string id = txtId.Text;
            string nombre = txtNombre.Text;
            string apellidoP = txtApellidoP.Text;
            string apellidoM = txtApellidoM.Text;
            string usuario = txtUsuario.Text;
            string pass = txtPass.Text;

            if (id == null || nombre == null || apellidoP == null || apellidoM == null || usuario == null || pass == null
               || id == "" || nombre == "" || apellidoP == "" || apellidoM == "" || usuario == "" || pass == "")
            {
                lblFallo.Text = "Debe llenar todos los campos para modificar un usuario";
                return;
            }

            try
            {
                UsuarioBL usuarioBL = new UsuarioBL();

                usuarioBL.validarCampos(int.Parse(id), nombre, apellidoP, apellidoM, pass);

                UsuarioDL usuarioDL = new UsuarioDL();
                usuarioDL.modificacionUsuario(int.Parse(id), nombre, apellidoP, apellidoM, usuario, pass);

                txtId.Text = "";
                txtNombre.Text = "";
                txtApellidoP.Text = "";
                txtApellidoM.Text = "";
                txtUsuario.Text = "";
                txtPass.Text = "";

                CargarUsuarios();

                lblExito.Text = "Usuario modificado correctamente";
            }
            catch (Exception ex)
            {
                lblFallo.Text = ex.Message;
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/vistas/Modulos/Modulos.aspx");
        }

        private void CargarUsuarios()
        {
            UsuarioDL usuarioDL = new UsuarioDL();
            gvUsuarios.DataSource = usuarioDL.obtenerTodosUsuarios();
            gvUsuarios.DataBind();
        }
        
        

    }
}
