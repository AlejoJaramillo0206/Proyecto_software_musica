using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;

namespace asp_Servicios_TiendaMusica.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonasController : ControllerBase
    {

        private IPersonasAplicacion? iPersonasAplicacion;

        public PersonasController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iPersonasAplicacion = new PersonasAplicacion(conexion);
        }

        [HttpPost]
        public Personas Guardar(Personas persona)
        {
            if (this.iPersonasAplicacion == null)
                throw new Exception("No implementado");
            return this.iPersonasAplicacion!.Guardar(persona);
        }
    }
}
