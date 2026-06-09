using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud.DataLayer;
using Crud.EntityLayer;


namespace Crud.BusinessLayer
{
    public class CatalogoProductoBL
    {
        private readonly CatalogoProductoDL catalogoDL;

        public CatalogoProductoBL()
        {
            catalogoDL = new CatalogoProductoDL();
        }


        public List<DataLayer.Producto> mostrarCatalogo()
        {
            return catalogoDL.obtenerCatalogo()
                             .Where(p => p.Estado)
                             .ToList();
        }


        public List<DataLayer.Producto> busquedaCategoria(string categoria)
        {
            return catalogoDL.obtenerCatalogo()
                             .Where(p => p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
                             .ToList();
        }

        public List<DataLayer.Producto> busquedaNombre(string nombre)
        {
            return catalogoDL.obtenerCatalogo()
                             .Where(p => p.Nombre.IndexOf(nombre, StringComparison.OrdinalIgnoreCase) >= 0)
                             .ToList();
        }

        public List<DataLayer.Producto> ordenarCantidad(bool cantidad)
        {
            var productos = catalogoDL.obtenerCatalogo().Where(p => p.Estado);
            return cantidad
                ? productos.OrderBy(p => p.Cantidad).ToList()
                : productos.OrderByDescending(p => p.Cantidad).ToList();
        }

    }
}
