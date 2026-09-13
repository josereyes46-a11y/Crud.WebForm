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
    public partial class Productos : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
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

            string claveProducto = txtClave.Text;
            string nombre = txtNombre.Text;
            string categoria = txtCategoria.Text;
            string cantidad = txtCantidad.Text;
            string descripcion = txtDescripcion.Text;

            if (claveProducto == null || nombre == null || categoria == null || cantidad == null || descripcion == null
                || claveProducto == "" || nombre == "" || categoria == "" || cantidad == "" || descripcion == "")
            {
                lblFallo.Text = "Debe llenar todos los campos para registrar un producto";
                return;
            }

            try
            {
                ProductoBL productoBL = new ProductoBL();
                productoBL.validarNombre(nombre);
                productoBL.validarClaveProducto(int.Parse(claveProducto));
                productoBL.validarCantidad(int.Parse(cantidad));
                productoBL.validarRegistroProducto(int.Parse(claveProducto), nombre, esModificacion: true); productoBL.validarCampos(nombre, int.Parse(cantidad), int.Parse(claveProducto), categoria, descripcion);

                ProductoDL productoDL = new ProductoDL();
                productoDL.altaProducto(int.Parse(claveProducto), nombre, categoria, descripcion, int.Parse(cantidad));

                txtClave.Text = "";
                txtNombre.Text = "";
                txtCategoria.Text = "";
                txtCantidad.Text = "";
                txtDescripcion.Text = "";

                CargarProductos();

                lblExito.Text = "Producto registrado correctamente";
            }
            catch (Exception ex)
            {
                txtClave.Text = "";
                txtNombre.Text = "";
                txtCategoria.Text = "";
                txtCantidad.Text = "";
                txtDescripcion.Text = "";

                lblFallo.Text = ex.Message;
            }


        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            LimpiarMensajes();

            string claveProducto = txtClave.Text;
            if (claveProducto == null || claveProducto == "")
            {
                lblFallo.Text = "Debe ingresar la clave del producto para eliminarlo";
                return;
            }
            try
            {
                ProductoDL productoDL = new ProductoDL();
                DialogResult resultado = MessageBox.Show(
                "¿Está seguro de eliminar el producto con clave: " + claveProducto + "?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    productoDL.bajaProducto(int.Parse(claveProducto));
                    txtClave.Text = "";
                    CargarProductos();

                    lblExito.Text = "Producto eliminado correctamente";
                }
                else
                {
                    txtClave.Text = "";
                    lblExito.Text = "Operación cancelada por el usuario";
                }
            }
            catch (Exception ex)
            {
                txtClave.Text = "";
                txtNombre.Text = "";
                txtCategoria.Text = "";
                txtCantidad.Text = "";
                txtDescripcion.Text = "";
                lblFallo.Text = ex.Message;
            }
        }

        protected void btnConsulta_Click(object sender, EventArgs e)
        {
            LimpiarMensajes();
        
            if (txtClave.Text == null || txtClave.Text == "")
            {
                lblFallo.Text = "Debe ingresar la clave del producto para consultarlo";
                return;
            }

            try
            {
                int claveProducto = int.Parse(txtClave.Text);
                ProductoDL productoDL = new ProductoDL();
                Crud.DataLayer.Producto producto = productoDL.consultaProducto(claveProducto);
                if (producto != null)
                {

                    lblExito.Text = "Consulta: " + Environment.NewLine

                                      + "Nombre: " + producto.Nombre + " " + Environment.NewLine
                                      + "Categoría: " + producto.Categoria + " " + Environment.NewLine
                                      + "Cantidad: " + producto.Cantidad + " " + Environment.NewLine
                                      + "Descripción: " + producto.Descripcion + " ";
                }
                else
                {
                    lblFallo.Text = "No se encuentra el producto registrado";
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

            string claveProducto = txtClave.Text;
            string nombre = txtNombre.Text;
            string categoria = txtCategoria.Text;
            string cantidad = txtCantidad.Text;
            string descripcion = txtDescripcion.Text;

            if (claveProducto == null || nombre == null || categoria == null || cantidad == null || descripcion == null
                || claveProducto == "" || nombre == "" || categoria == "" || cantidad == "" || descripcion == "")
            {
                lblFallo.Text = "Debe llenar todos los campos para modificar un producto";
                return;
            }

            try
            {
                ProductoBL productoBL = new ProductoBL();
                productoBL.validarCampos(nombre, int.Parse(cantidad), int.Parse(claveProducto), categoria, descripcion, esModificacion: true);

                ProductoDL productoDL = new ProductoDL();
                productoDL.modificacionProducto(int.Parse(claveProducto), nombre, categoria, descripcion, int.Parse(cantidad));

                txtClave.Text = "";
                txtNombre.Text = "";
                txtCategoria.Text = "";
                txtCantidad.Text = "";
                txtDescripcion.Text = "";

                CargarProductos();
                lblExito.Text = "Producto modificado correctamente";
            }
            catch (Exception ex)
            {
                txtClave.Text = "";
                txtNombre.Text = "";
                txtCategoria.Text = "";
                txtCantidad.Text = "";
                txtDescripcion.Text = "";
                lblFallo.Text = ex.Message;
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/vistas/Modulos/Modulos.aspx");

        }
        private void CargarProductos()
        {
            ProductoDL productoDL = new ProductoDL();
            gvProductos.DataSource = productoDL.obtenerTodosProductos();
            gvProductos.DataBind();
        }

    }
}