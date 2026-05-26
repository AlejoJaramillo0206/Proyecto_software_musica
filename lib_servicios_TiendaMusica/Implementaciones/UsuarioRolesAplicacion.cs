using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class UsuarioRolesAplicacion : IUsuarioRolesAplicacion
    {
        private readonly IConexion _conexion;

        public UsuarioRolesAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

  
        public List<UsuarioRoles> ObtenerPorUsuario(int usuarioId) =>
            _conexion.UsuarioRoles!
                .Where(ur => ur.UsuarioId == usuarioId)
                .ToList();

        public UsuarioRoles Guardar(UsuarioRoles usuarioRol)
        {
            _conexion.UsuarioRoles!.Add(usuarioRol);
            _conexion.SaveChanges();
            return usuarioRol;

        }
        public List<UsuarioRoles> Obtener() =>
            _conexion.UsuarioRoles!.ToList();


        public bool Eliminar(int usuarioId, int rolId)
        {
            var usuarioRol = _conexion.UsuarioRoles!
           .FirstOrDefault(ur => ur.UsuarioId == usuarioId && ur.RolId == rolId);

           
            if (usuarioRol == null) return false;

            _conexion.UsuarioRoles!.Remove(usuarioRol);
            _conexion.SaveChanges();

            return true;
        }
    }
}
