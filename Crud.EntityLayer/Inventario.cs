using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.EntityLayer
{
    public class Inventario
    {
        public DateTime fecha { get; set; }
        public string TipoMovimiento { get; set; }
        public int ClaveProducto { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
    }
}
