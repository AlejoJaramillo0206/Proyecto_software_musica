

using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;

namespace lib_servicios_TiendaMusica.Modelos
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class InstrumentosPercusionController : ControllerBase
    {
        private IInstrumentosPercusionAplicacion? iInstrumentosPercusionAplicacion;

        public InstrumentosPercusionController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iInstrumentosPercusionAplicacion = new InstrumentosPercusionAplicacion(conexion);
        }

        [HttpGet]
        public List<InstrumentosPercusion> Consultar()
        {
            if (this.iInstrumentosPercusionAplicacion == null)
                throw new Exception("No implementado");
            return this.iInstrumentosPercusionAplicacion!.Obtener();
        }

        [HttpGet]
        public InstrumentosPercusion ConsultarPorId(int id)
        {
            if (this.iInstrumentosPercusionAplicacion == null)
                throw new Exception("No implementado");
            return this.iInstrumentosPercusionAplicacion!.Obtener(id);
        }

        [HttpPost]
        public InstrumentosPercusion Guardar(InstrumentosPercusion instrumento)
        {
            if (this.iInstrumentosPercusionAplicacion == null)
                throw new Exception("No implementado");
            return this.iInstrumentosPercusionAplicacion!.Guardar(instrumento);
        }

        [HttpPut]
        public InstrumentosPercusion Editar(InstrumentosPercusion instrumento)
        {
            if (this.iInstrumentosPercusionAplicacion == null)
                throw new Exception("No implementado");
            return this.iInstrumentosPercusionAplicacion!.Editar(instrumento);
        }

        [HttpDelete]
        public bool Eliminar(int id)
        {
            if (this.iInstrumentosPercusionAplicacion == null)
                throw new Exception("No implementado");
            return this.iInstrumentosPercusionAplicacion!.Eliminar(id);
        }
    }
}
