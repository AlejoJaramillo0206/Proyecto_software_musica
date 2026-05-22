using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Interfaces
{
    public interface IUsuarioRolesAplicacion
    {
        List<UsuarioRoles> ObtenerPorUsuario(int usuarioId);
        UsuarioRoles Guardar(UsuarioRoles usuarioRol);
        bool Eliminar(int usuarioId, int rolId);
    }
}
