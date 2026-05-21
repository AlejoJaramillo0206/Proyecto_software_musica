using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;

namespace asp_Servicios_TiendaMusica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuditoriasController : ControllerBase
    {
        private IAuditoriasAplicacion? iAuditoriasAplicacion;

        public AuditoriasController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iAuditoriasAplicacion = new AuditoriasAplicacion(conexion);
        }

        [HttpGet]
        public List<Auditorias> Consultar()
        {
            if (this.iAuditoriasAplicacion == null)
                throw new Exception("No implementado");
            return this.iAuditoriasAplicacion!.Obtener();
        }

        [HttpGet]
        public List<Auditorias> ConsultarPorEntidad(string entidad)
        {
            if (this.iAuditoriasAplicacion == null)
                throw new Exception("No implementado");
            return this.iAuditoriasAplicacion!.ObtenerPorEntidad(entidad);
        }

        [HttpGet]
        public List<Auditorias> ConsultarPorUsuario(int usuarioId)
        {
            if (this.iAuditoriasAplicacion == null)
                throw new Exception("No implementado");
            return this.iAuditoriasAplicacion!.ObtenerPorUsuario(usuarioId);
        }
    }
}