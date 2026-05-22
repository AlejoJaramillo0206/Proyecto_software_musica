

using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;

namespace lib_servicios_TiendaMusica.Modelos
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccesoriosController : ControllerBase
    {
        private IAccesoriosAplicacion? iAccesoriosAplicacion;

        public AccesoriosController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iAccesoriosAplicacion = new AccesoriosAplicacion(conexion);
        }

        [HttpGet]
        public List<Accesorios> Consultar()
        {
            if (this.iAccesoriosAplicacion == null)
                throw new Exception("No implementado");
            return this.iAccesoriosAplicacion!.Obtener();
        }

        [HttpGet]
        public Accesorios ConsultarPorId(int id)
        {
            if (this.iAccesoriosAplicacion == null)
                throw new Exception("No implementado");
            return this.iAccesoriosAplicacion!.Obtener(id);
        }

        [HttpPost]
        public Accesorios Guardar(Accesorios accesorio)
        {
            if (this.iAccesoriosAplicacion == null)
                throw new Exception("No implementado");
            return this.iAccesoriosAplicacion!.Guardar(accesorio);
        }

        [HttpPut]
        public Accesorios Editar(Accesorios accesorio)
        {
            if (this.iAccesoriosAplicacion == null)
                throw new Exception("No implementado");
            return this.iAccesoriosAplicacion!.Editar(accesorio);
        }

        [HttpDelete]
        public bool Eliminar(int id)
        {
            if (this.iAccesoriosAplicacion == null)
                throw new Exception("No implementado");
            return this.iAccesoriosAplicacion!.Eliminar(id);
        }
    }
}
