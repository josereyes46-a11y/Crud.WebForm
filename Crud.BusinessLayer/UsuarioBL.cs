using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud.DataLayer;



namespace Crud.BusinessLayer
{
    public class UsuarioBL
    {
        private UsuarioDL usuarioDL = new UsuarioDL();

        public bool validarNombre(string Nombre, string ApellidoPaterno, string ApellidoMaterno)
        {
            if (Nombre == null && ApellidoPaterno == null && ApellidoMaterno == null
               || Nombre == "" && ApellidoPaterno == "" && ApellidoMaterno == "")
            {
                throw new Exception("El nombre no puede estar vacío");
            }

            else if (Nombre.Length > 50 || ApellidoPaterno.Length > 50 || ApellidoMaterno.Length > 50)
            {
                throw new Exception("El nombre o apellido es demasiado largo");
            }

            else if (!System.Text.RegularExpressions.Regex.IsMatch(Nombre, @"^[A-Za-z\s]+$") ||
             !System.Text.RegularExpressions.Regex.IsMatch(ApellidoPaterno, @"^[A-Za-z\s]+$") ||
             !System.Text.RegularExpressions.Regex.IsMatch(ApellidoMaterno, @"^[A-Za-z\s]+$"))
            {
                throw new Exception("El nombre o apellido no puede contener números ni caracteres especiales");
            }

            else
            {
                return true;
            }
        }

        public bool validarContrasena(string Contrasena)
        {
            if (Contrasena == null || Contrasena == "")
            {
                throw new Exception("La contraseña no puede ser nula ni estar vacia");
            }

            if (Contrasena.Length > 12)
            {
                throw new Exception("La contraseña no puede tener más de 12 caracteres");
            }
            else
            {
                return true;
            }
        }

        public bool validarCampos(int IdUsuario, string Nombre, string ApellidoPaterno, string ApellidoMaterno, string Contrasena)
        {
            if (IdUsuario == 0)
            {
                throw new Exception("El ID de usuario no puede ser 0");
            }
            else 
            {
                validarNombre(Nombre, ApellidoPaterno, ApellidoMaterno);
                validarContrasena(Contrasena);
                return true;
            }
  
        }

        public bool validarID(int IdUsuario)
        {
            if (IdUsuario <= 0)
            {
                throw new Exception("El ID de usuario debe ser un número positivo");
            }
            else 
            { 
            return true;
            }
        }

        public bool validarUnicoUsuario( int IdUsuario, string NombreUsuario)
        {
            if (IdUsuario <= 0 || string.IsNullOrWhiteSpace(NombreUsuario))
            {
                throw new Exception("Debe ingresar un ID válido y un nombre de usuario.");
            }

            else
            {
                AutentificacionUsuarioDL aprobacion = new AutentificacionUsuarioDL();
                bool esUnico = !aprobacion.validarRegistroExistente(IdUsuario, NombreUsuario.Trim());

                if (!esUnico)
                {
                    throw new Exception("El ID de usuario ya se encuentra registrado.");
                }
                else
                {
                    return true;
                }
            }
            
        }
    }
}
