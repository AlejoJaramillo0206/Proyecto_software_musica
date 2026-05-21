

using System.ComponentModel.DataAnnotations.Schema;

namespace lib_servicios_TiendaMusica.Modelos
{
    using lib_servicios_TiendaMusica.Implementaciones;
    using lib_servicios_TiendaMusica.Interfaces;
    using lib_servicios_TiendaMusica.Modelos;
    using lib_servicios_TiendaMusica.Nucleo;
    using Microsoft.AspNetCore.Mvc;

    namespace asp_Servicios_TiendaMusica.Controllers
    {
        [ApiController]
        [Route("[controller]/[action]")]
        public class DetalleFacturasController : ControllerBase
        {
            private IDetalleFacturasAplicacion? iDetalleFacturasAplicacion;

            public DetalleFacturasController()
            {
                IConexion conexion = new Conexion();
                conexion.string_conexion = Configuraciones.obtener("conexion");
                this.iDetalleFacturasAplicacion = new DetalleFacturasAplicacion(conexion);
            }

            [HttpGet]
            public List<DetalleFacturas> Consultar()
            {
                if (this.iDetalleFacturasAplicacion == null)
                    throw new Exception("No implementado");
                return this.iDetalleFacturasAplicacion!.Obtener();
            }

            [HttpGet]
            public List<DetalleFacturas> ConsultarPorFactura(int facturaId)
            {
                if (this.iDetalleFacturasAplicacion == null)
                    throw new Exception("No implementado");
                return this.iDetalleFacturasAplicacion!.ObtenerPorFactura(facturaId);
            }

            [HttpPost]
            public void Guardar(DetalleFacturas detalle)
            {
                if (this.iDetalleFacturasAplicacion == null)
                    throw new Exception("No implementado");
                this.iDetalleFacturasAplicacion!.Guardar(detalle);
            }
        }
    }
}
