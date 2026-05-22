using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Modelos
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsuarioRolesController : ControllerBase
    {
        private IUsuarioRolesAplicacion? iUsuarioRolesAplicacion;

        public UsuarioRolesController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iUsuarioRolesAplicacion = new UsuarioRolesAplicacion(conexion);
        }

        [HttpGet]
        public List<UsuarioRoles> ConsultarPorUsuario(int usuarioId)
        {
            if (this.iUsuarioRolesAplicacion == null)
                throw new Exception("No implementado");
            return this.iUsuarioRolesAplicacion!.ObtenerPorUsuario(usuarioId);
        }

        [HttpPost]
        public UsuarioRoles Guardar(UsuarioRoles usuarioRol)
        {
            if (this.iUsuarioRolesAplicacion == null)
                throw new Exception("No implementado");
            return this.iUsuarioRolesAplicacion!.Guardar(usuarioRol);
        }

        [HttpDelete]
        public bool Eliminar(int usuarioId, int rolId)
        {
            if (this.iUsuarioRolesAplicacion == null)
                throw new Exception("No implementado");
            return this.iUsuarioRolesAplicacion!.Eliminar(usuarioId, rolId);
        }
    }
}
