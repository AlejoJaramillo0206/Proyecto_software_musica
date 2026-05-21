using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;

namespace asp_Servicios_TiendaMusica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductosController : ControllerBase
    {
        private IProductosAplicacion? iProductosAplicacion;

        public ProductosController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iProductosAplicacion = new ProductosAplicacion(conexion);
        }

        [HttpGet]
        public List<Productos> Consultar()
        {
            if (this.iProductosAplicacion == null)
                throw new Exception("No implementado");
            return this.iProductosAplicacion!.Obtener();
        }

        [HttpGet]
        public Productos ConsultarPorId(int id)
        {
            if (this.iProductosAplicacion == null)
                throw new Exception("No implementado");
            return this.iProductosAplicacion!.Obtener(id);
        }
    }
}
