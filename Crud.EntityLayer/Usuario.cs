using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.EntityLayer
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }       
        public string ApellidoMaterno { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }

    }
}
