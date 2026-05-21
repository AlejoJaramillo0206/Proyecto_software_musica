using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;

namespace asp_Servicios_TiendaMusica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClientesController : ControllerBase
    {
        private IClientesAplicacion? iClientesAplicacion;

        public ClientesController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iClientesAplicacion = new ClientesAplicacion(conexion);
        }

        [HttpGet]
        public List<Clientes> Consultar()
        {
            if (this.iClientesAplicacion == null)
                throw new Exception("No implementado");
            return this.iClientesAplicacion!.Obtener();
        }

        [HttpGet]
        public Clientes ConsultarPorId(int id)
        {
            if (this.iClientesAplicacion == null)
                throw new Exception("No implementado");
            return this.iClientesAplicacion!.Obtener(id);
        }

        [HttpPost]
        public void Guardar(Clientes cliente)
        {
            if (this.iClientesAplicacion == null)
                throw new Exception("No implementado");
            this.iClientesAplicacion!.Guardar(cliente);
        }

        [HttpPut]
        public void Editar(Clientes cliente)
        {
            if (this.iClientesAplicacion == null)
                throw new Exception("No implementado");
            this.iClientesAplicacion!.Editar(cliente);
        }

        [HttpDelete]
        public void Eliminar(int id)
        {
            if (this.iClientesAplicacion == null)
                throw new Exception("No implementado");
            this.iClientesAplicacion!.Eliminar(id);
        }
    }
}