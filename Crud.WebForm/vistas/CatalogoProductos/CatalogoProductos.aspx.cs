using Antlr.Runtime.Tree;
using Crud.BusinessLayer;
using Crud.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms.Design;

namespace Crud.WebForm
{
    public partial class CatalogoProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarCatalogo();
            }
        }


        protected void btnAplicar_Click(object sender, EventArgs e)
        {
            CatalogoProductoDL catalogoProductoDL = new CatalogoProductoDL();
            List<Producto> productos = catalogoProductoDL.obtenerCatalogo();

            // Filtro por texto
            if (!string.IsNullOrEmpty(txtBusqueda.Text))
            {
                if (ddlFiltro.SelectedValue == "Nombre")
                {
                    productos = productos
                        .Where(p => p.Nombre.IndexOf(txtBusqueda.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();
                }
                else if (ddlFiltro.SelectedValue == "Categoria")
                {
                    productos = productos
                        .Where(p => p.Categoria.IndexOf(txtBusqueda.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();
                }
                else if (ddlFiltro.SelectedValue == "Cantidad")
                {
                    if (int.TryParse(txtBusqueda.Text, out int cantidad))
                    {
                        productos = productos
                            .Where(p => p.Cantidad == cantidad)
                            .ToList();
                    }
                }
            }

            if (ddlCantidad.SelectedValue == "Menor a mayor")
            {
                productos = productos.OrderBy(p => p.Cantidad).ToList();
            }
            else if (ddlCantidad.SelectedValue == "Mayor a menor")
            {
                productos = productos.OrderByDescending(p => p.Cantidad).ToList();
            }

            gvCatalogo.DataSource = productos;
            gvCatalogo.DataBind();

            if (ddlFiltro.SelectedValue == "Nombre")
            {
                gvCatalogo.Columns[0].Visible = true;   // Nombre
                gvCatalogo.Columns[1].Visible = false;  // Categoria
                gvCatalogo.Columns[2].Visible = false;  // Cantidad
            }
            else if (ddlFiltro.SelectedValue == "Categoria")
            {
                gvCatalogo.Columns[0].Visible = false;
                gvCatalogo.Columns[1].Visible = true;
                gvCatalogo.Columns[2].Visible = false;
            }
            else if (ddlFiltro.SelectedValue == "Cantidad")
            {
                gvCatalogo.Columns[0].Visible = false;
                gvCatalogo.Columns[1].Visible = false;
                gvCatalogo.Columns[2].Visible = true;
            }
            else
            {
                gvCatalogo.Columns[0].Visible = true;
                gvCatalogo.Columns[1].Visible = true;
                gvCatalogo.Columns[2].Visible = true;
            }
        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/vistas/Modulos/Modulos.aspx");
        }

        protected void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
           txtBusqueda.Text = string.Empty;
           ddlFiltro.ClearSelection();
           ddlCantidad.ClearSelection();

           cargarCatalogo();
        }

        private void cargarCatalogo()
        {
            CatalogoProductoDL catalogoProductoDL = new CatalogoProductoDL();
            gvCatalogo.DataSource = catalogoProductoDL.obtenerCatalogo();
            gvCatalogo.DataBind();
        }

        private void cargarNombre()
        {
            CatalogoProductoDL catalogoProductoDL = new CatalogoProductoDL();
            gvCatalogo.DataSource = catalogoProductoDL.obtenerNombre();
            gvCatalogo.DataBind();
        }

        private void cargarCategoria()
        {
            CatalogoProductoDL catalogoProductoDL = new CatalogoProductoDL();
            gvCatalogo.DataSource = catalogoProductoDL.obtenerCategoria();
            gvCatalogo.DataBind();
        }

        private void cargarCantidad()
        {
            CatalogoProductoDL catalogoProductoDL = new CatalogoProductoDL();
            gvCatalogo.DataSource = catalogoProductoDL.obtenerCantidad();
            gvCatalogo.DataBind();
        }


    }
}