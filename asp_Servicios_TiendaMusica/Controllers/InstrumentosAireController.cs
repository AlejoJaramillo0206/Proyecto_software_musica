

using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;

namespace lib_servicios_TiendaMusica.Modelos
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class InstrumentosAireController : ControllerBase
    {
        private IInstrumentosAireAplicacion? iInstrumentosAireAplicacion;

        public InstrumentosAireController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iInstrumentosAireAplicacion = new InstrumentosAireAplicacion(conexion);
        }

        [HttpGet]
        public List<InstrumentosAire> Consultar()
        {
            if (this.iInstrumentosAireAplicacion == null)
                throw new Exception("No implementado");
            return this.iInstrumentosAireAplicacion!.Obtener();
        }

        [HttpGet]
        public InstrumentosAire ConsultarPorId(int id)
        {
            if (this.iInstrumentosAireAplicacion == null)
                throw new Exception("No implementado");
            return this.iInstrumentosAireAplicacion!.Obtener(id);
        }

        [HttpPost]
        public InstrumentosAire Guardar(InstrumentosAire instrumento)
        {
            if (this.iInstrumentosAireAplicacion == null)
                throw new Exception("No implementado");
            return this.iInstrumentosAireAplicacion!.Guardar(instrumento);
        }

        [HttpPut]
        public InstrumentosAire Editar(InstrumentosAire instrumento)
        {
            if (this.iInstrumentosAireAplicacion == null)
                throw new Exception("No implementado");
            return this.iInstrumentosAireAplicacion!.Editar(instrumento);
        }

        [HttpDelete]
        public bool Eliminar(int id)
        {
            if (this.iInstrumentosAireAplicacion == null)
                throw new Exception("No implementado");
            return this.iInstrumentosAireAplicacion!.Eliminar(id);
        }
    }
}
