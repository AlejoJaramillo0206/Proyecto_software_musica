
using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;

namespace lib_servicios_TiendaMusica.Modelos
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class InstrumentosCuerdasController : ControllerBase
    {
        private IInstrumentosCuerdasAplicacion? iInstrumentosCuerdasAplicacion;

        public InstrumentosCuerdasController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iInstrumentosCuerdasAplicacion = new InstrumentosCuerdasAplicacion(conexion);
        }

        [HttpGet]
        public List<InstrumentosCuerdas> Consultar()
        {
            if (this.iInstrumentosCuerdasAplicacion == null)
                throw new Exception("No implementado");
            return this.iInstrumentosCuerdasAplicacion!.Obtener();
        }

        [HttpGet]
        public InstrumentosCuerdas ConsultarPorId(int id)
        {
            if (this.iInstrumentosCuerdasAplicacion == null)
                throw new Exception("No implementado");
            return this.iInstrumentosCuerdasAplicacion!.Obtener(id);
        }

        [HttpPost]
        public void Guardar(InstrumentosCuerdas instrumento)
        {
            if (this.iInstrumentosCuerdasAplicacion == null)
                throw new Exception("No implementado");
            this.iInstrumentosCuerdasAplicacion!.Guardar(instrumento);
        }

        [HttpPut]
        public void Editar(InstrumentosCuerdas instrumento)
        {
            if (this.iInstrumentosCuerdasAplicacion == null)
                throw new Exception("No implementado");
            this.iInstrumentosCuerdasAplicacion!.Editar(instrumento);
        }

        [HttpDelete]
        public void Eliminar(int id)
        {
            if (this.iInstrumentosCuerdasAplicacion == null)
                throw new Exception("No implementado");
            this.iInstrumentosCuerdasAplicacion!.Eliminar(id);
        }
    }
}
