


using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;

namespace lib_servicios_TiendaMusica.Modelos
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GarantiasController : ControllerBase
    {
        private IGarantiasAplicacion? iGarantiasAplicacion;

        public GarantiasController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iGarantiasAplicacion = new GarantiasAplicacion(conexion);
        }

        [HttpGet]
        public List<Garantias> Consultar()
        {
            if (this.iGarantiasAplicacion == null)
                throw new Exception("No implementado");
            return this.iGarantiasAplicacion!.Obtener();
        }

        [HttpGet]
        public Garantias ConsultarPorId(int id)
        {
            if (this.iGarantiasAplicacion == null)
                throw new Exception("No implementado");
            return this.iGarantiasAplicacion!.Obtener(id);
        }

        [HttpGet]
        public List<Garantias> ConsultarPorCliente(int clienteId)
        {
            if (this.iGarantiasAplicacion == null)
                throw new Exception("No implementado");
            return this.iGarantiasAplicacion!.ObtenerPorCliente(clienteId);
        }

        [HttpPost]
        public void Guardar(Garantias garantia)
        {
            if (this.iGarantiasAplicacion == null)
                throw new Exception("No implementado");
            this.iGarantiasAplicacion!.Guardar(garantia);
        }
    }
}
