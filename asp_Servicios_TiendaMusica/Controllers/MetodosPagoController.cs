

using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;

namespace lib_servicios_TiendaMusica.Modelos
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MetodosPagoController : ControllerBase
    {
        private IMetodosPagoAplicacion? iMetodosPagoAplicacion;

        public MetodosPagoController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iMetodosPagoAplicacion = new MetodosPagoAplicacion(conexion);
        }

        [HttpGet]
        public List<MetodosPago> Consultar()
        {
            if (this.iMetodosPagoAplicacion == null)
                throw new Exception("No implementado");
            return this.iMetodosPagoAplicacion!.Obtener();
        }

        [HttpGet]
        public MetodosPago ConsultarPorId(int id)
        {
            if (this.iMetodosPagoAplicacion == null)
                throw new Exception("No implementado");
            return this.iMetodosPagoAplicacion!.Obtener(id);
        }

        [HttpPost]
        public MetodosPago Guardar(MetodosPago metodoPago)
        {
            if (this.iMetodosPagoAplicacion == null)
                throw new Exception("No implementado");
            return this.iMetodosPagoAplicacion!.Guardar(metodoPago);
        }

        [HttpPut]
        public MetodosPago Editar(MetodosPago metodoPago)
        {
            if (this.iMetodosPagoAplicacion == null)
                throw new Exception("No implementado");
            return this.iMetodosPagoAplicacion!.Editar(metodoPago);
        }

        [HttpDelete]
        public bool Eliminar(int id)
        {
            if (this.iMetodosPagoAplicacion == null)
                throw new Exception("No implementado");
            return this.iMetodosPagoAplicacion!.Eliminar(id);
        }
    }
}
