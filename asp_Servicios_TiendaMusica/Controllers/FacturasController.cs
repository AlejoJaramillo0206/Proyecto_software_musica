
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
        public class FacturasController : ControllerBase
        {
            private IFacturasAplicacion? iFacturasAplicacion;

            public FacturasController()
            {
                IConexion conexion = new Conexion();
                conexion.string_conexion = Configuraciones.obtener("conexion");
                this.iFacturasAplicacion = new FacturasAplicacion(conexion);
            }

            [HttpGet]
            public List<Facturas> Consultar()
            {
                if (this.iFacturasAplicacion == null)
                    throw new Exception("No implementado");
                return this.iFacturasAplicacion!.Obtener();
            }

            [HttpGet]
            public Facturas ConsultarPorId(int id)
            {
                if (this.iFacturasAplicacion == null)
                    throw new Exception("No implementado");
                return this.iFacturasAplicacion!.Obtener(id);
            }

            [HttpPost]
            public void Guardar(Facturas factura)
            {
                if (this.iFacturasAplicacion == null)
                    throw new Exception("No implementado");
                this.iFacturasAplicacion!.Guardar(factura);
            }
        }
    }
}
