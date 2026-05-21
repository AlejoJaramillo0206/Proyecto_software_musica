
using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;

namespace lib_servicios_TiendaMusica.Modelos
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BaflesController : ControllerBase
    {
        private IBaflesAplicacion? iBaflesAplicacion;

        public BaflesController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iBaflesAplicacion = new BaflesAplicacion(conexion);
        }

        [HttpGet]
        public List<Bafles> Consultar()
        {
            if (this.iBaflesAplicacion == null)
                throw new Exception("No implementado");
            return this.iBaflesAplicacion!.Obtener();
        }

        [HttpGet]
        public Bafles ConsultarPorId(int id)
        {
            if (this.iBaflesAplicacion == null)
                throw new Exception("No implementado");
            return this.iBaflesAplicacion!.Obtener(id);
        }

        [HttpPost]
        public void Guardar(Bafles bafl)
        {
            if (this.iBaflesAplicacion == null)
                throw new Exception("No implementado");
            this.iBaflesAplicacion!.Guardar(bafl);
        }

        [HttpPut]
        public void Editar(Bafles bafl)
        {
            if (this.iBaflesAplicacion == null)
                throw new Exception("No implementado");
            this.iBaflesAplicacion!.Editar(bafl);
        }

        [HttpDelete]
        public void Eliminar(int id)
        {
            if (this.iBaflesAplicacion == null)
                throw new Exception("No implementado");
            this.iBaflesAplicacion!.Eliminar(id);
        }
    }
}
