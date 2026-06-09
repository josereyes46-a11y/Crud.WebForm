using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud.DataLayer;
using Crud.EntityLayer;


namespace Crud.BusinessLayer
{
    public class ProductoBL
    {
        private ProductoDL productoDL = new ProductoDL();

        public bool validarNombre(string Nombre)
        {
            if (Nombre == null || Nombre == "")
            {
                throw new Exception("El nombre no puede estar vacío");
            }
            else if (Nombre.Length > 50)
            {
                throw new Exception("El nombre es demasiado largo");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(Nombre, @"^[A-Za-z\s]+$"))
            {
                throw new Exception("El nombre no puede contener números ni caracteres especiales");
            }
            else if (productoDL.obtenerTodosProductos().Any(p => p.Nombre == Nombre))
            {
                throw new Exception("El nombre del producto ya existe");
            }
            else
            {
                return true;
            }
        }

        public bool validarCampos(string Nombre, int Cantidad, int ClaveProducto, string Categoria, string Descripcion)
        {
            if (validarNombre(Nombre) && validarCantidad(Cantidad) && validarClaveProducto(ClaveProducto))
            {
                return true;
            }
            else if (Categoria == null || Categoria == "")
            {
                throw new Exception("La categoría no puede estar vacía");
            }
            else if (Descripcion == null || Descripcion == "")
            {
                throw new Exception("La descripción no puede estar vacía");
            }
            else
            {
                return false;
            }
        }

        public bool validarClaveProducto(int ClaveProducto)
        {
            var productos = productoDL.obtenerTodosProductos();

            if (productos.Any(p => p.ClaveProducto == ClaveProducto && p.ClaveProducto != ClaveProducto))
            {
                throw new Exception("La clave del producto ya existe");
            }

            if (ClaveProducto < 0)
            {
                throw new Exception("La clave del producto no puede ser menor a cero");

            }

            else if (ClaveProducto <= 0)
            {
                throw new Exception("La clave del producto no puede ser cero o menor");
            }

            else if (ClaveProducto % 1 != 0)
            {
                throw new Exception("La clave del producto debe ser un número entero");
            }

            else
            {
                return true;
            }
        }

        public bool validarCantidad(int Cantidad)
        {
            if (Cantidad % 1 != 0)
            {
                throw new Exception("La cantidad debe ser un número entero");
            }

            else if (Cantidad < 0 || Cantidad == null)
            {
                throw new Exception("La cantidad no puede ser negativa");
            }

            else
            {
                return true;
            }
        }

        public bool validarRegistroProducto(int ClaveProducto, string Nombre)

        {
            var productos = productoDL.obtenerTodosProductos();

            if (productos.Any(p => p.ClaveProducto == ClaveProducto))
            {
                throw new Exception("La clave del producto ya existe");
            }
            else if (productos.Any(p => p.Nombre == Nombre))
            {
                throw new Exception("El nombre del producto ya existe");
            }
            else
            {
                return true;
            }
        }
    }
}



        
    


