using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.EntityLayer
{
    public class Roles
    {
        public int IdRol { get; set; }
        public int IdUsuario { get; set; }
        public string NombreRol { get; set; }
    }
}
