using Crud.DataLayer;
using Crud.EntityLayer;
using System;

namespace Crud.BusinessLayer
{
    public class RolesBL
    {
        private RolesDL rolesDL = new RolesDL();

        public bool validarNombreRol(string NombreRol)
        {
            if (string.IsNullOrWhiteSpace(NombreRol))
                throw new Exception("El nombre del rol no puede ser nulo ni estar vacío");
            if (NombreRol.Length > 20)
                throw new Exception("El nombre del rol no puede tener más de 20 caracteres");
            return true;
        }

        public bool validarRolAsignacion(string NombreRol)
        {
            if (NombreRol != "Administrador" && NombreRol != "Empleado")
                throw new Exception("El nombre del rol debe ser 'Administrador' o 'Empleado'");
            return true;
        }

        public bool validarUnicoRol(string NombreRol, int IdUsuario)
        {
            Roles rolExistente = rolesDL.consultaRol(NombreRol, IdUsuario);
            if (rolExistente != null)
                throw new Exception("El usuario ya tiene asignado el rol " + NombreRol);
            return true;
        }

        public bool validarCampos(int IdUsuario, string NombreRol)
        {
            if (IdUsuario <= 0)
                throw new Exception("El ID de usuario no puede ser 0 o negativo");
            if (string.IsNullOrWhiteSpace(NombreRol))
                throw new Exception("El nombre del rol no puede ser nulo ni estar vacío");
            if (NombreRol.Length > 20)
                throw new Exception("El nombre del rol no puede tener más de 20 caracteres");
            return true;
        }
    }
}

