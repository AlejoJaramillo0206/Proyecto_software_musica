

using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_servicios_TiendaMusica.Modelos
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PagosController : ControllerBase
    {
        private IPagosAplicacion? iPagosAplicacion;

        public PagosController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iPagosAplicacion = new PagosAplicacion(conexion);
        }

        [HttpGet]
        public List<Pagos> Consultar()
        {
            if (this.iPagosAplicacion == null)
                throw new Exception("No implementado");
            return this.iPagosAplicacion!.Obtener();
        }

        [HttpGet]
        public List<Pagos> ConsultarPorFactura(int facturaId)
        {
            if (this.iPagosAplicacion == null)
                throw new Exception("No implementado");
            return this.iPagosAplicacion!.ObtenerPorFactura(facturaId);
        }

        [HttpPost]
        public void Guardar(Pagos pago)
        {
            if (this.iPagosAplicacion == null)
                throw new Exception("No implementado");
            this.iPagosAplicacion!.Guardar(pago);
        }
    }
}
