using Crud.DataLayer;
using System;

namespace Crud.BusinessLayer
{
    public class AutentificacionUsuarioBL
    {
        private AutentificacionUsuarioDL autentificacionUsuarioDL = new AutentificacionUsuarioDL();

        public bool validarCampos(string NombreUsuario, string Contrasena)
        {
            if (NombreUsuario == null || Contrasena == null
                || NombreUsuario == "" || Contrasena == "")
            {
                throw new Exception("Campos vacios");
            }
            return true;
        }

        public bool autentificarUsuario(string NombreUsuario, string Contrasena)
        {
            if (!validarCampos(NombreUsuario, Contrasena)) 
            {
                  return false; 
            }

            return autentificacionUsuarioDL.validarLogin(NombreUsuario.Trim(), Contrasena.Trim());
        }

        public bool verificarDuplicidad(int IdUsuario, string NombreUsuario)
        {
            return autentificacionUsuarioDL.validarRegistroExistente(IdUsuario, NombreUsuario.Trim());
        }
    }
}
