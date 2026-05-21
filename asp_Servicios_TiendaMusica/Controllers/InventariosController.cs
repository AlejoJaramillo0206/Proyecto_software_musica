

using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_servicios_TiendaMusica.Modelos
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class InventariosController : ControllerBase
    {
        private IInventariosAplicacion? iInventariosAplicacion;

        public InventariosController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iInventariosAplicacion = new InventariosAplicacion(conexion);
        }

        [HttpGet]
        public List<Inventarios> Consultar()
        {
            if (this.iInventariosAplicacion == null)
                throw new Exception("No implementado");
            return this.iInventariosAplicacion!.Obtener();
        }

        [HttpGet]
        public Inventarios ConsultarPorId(int id)
        {
            if (this.iInventariosAplicacion == null)
                throw new Exception("No implementado");
            return this.iInventariosAplicacion!.Obtener(id);
        }

        [HttpGet]
        public Inventarios ConsultarPorProducto(int productoId)
        {
            if (this.iInventariosAplicacion == null)
                throw new Exception("No implementado");
            return this.iInventariosAplicacion!.ObtenerPorProducto(productoId);
        }

        [HttpPost]
        public void Guardar(Inventarios inventario)
        {
            if (this.iInventariosAplicacion == null)
                throw new Exception("No implementado");
            this.iInventariosAplicacion!.Guardar(inventario);
        }

        [HttpPut]
        public void Editar(Inventarios inventario)
        {
            if (this.iInventariosAplicacion == null)
                throw new Exception("No implementado");
            this.iInventariosAplicacion!.Editar(inventario);
        }

        [HttpDelete]
        public void Eliminar(int id)
        {
            if (this.iInventariosAplicacion == null)
                throw new Exception("No implementado");
            this.iInventariosAplicacion!.Eliminar(id);
        }
    }
}
