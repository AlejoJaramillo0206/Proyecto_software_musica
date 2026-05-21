using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;

namespace asp_Servicios_TiendaMusica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmpleadosController : ControllerBase
    {
        private IEmpleadosAplicacion? iEmpleadosAplicacion;

        public EmpleadosController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iEmpleadosAplicacion = new EmpleadosAplicacion(conexion);
        }

        [HttpGet]
        public List<Empleados> Consultar()
        {
            if (this.iEmpleadosAplicacion == null)
                throw new Exception("No implementado");
            return this.iEmpleadosAplicacion!.Obtener();
        }

        [HttpGet]
        public Empleados ConsultarPorId(int id)
        {
            if (this.iEmpleadosAplicacion == null)
                throw new Exception("No implementado");
            return this.iEmpleadosAplicacion!.Obtener(id);
        }

        [HttpPost]
        public void Guardar(Empleados empleado)
        {
            if (this.iEmpleadosAplicacion == null)
                throw new Exception("No implementado");
            this.iEmpleadosAplicacion!.Guardar(empleado);
        }

        [HttpPut]
        public void Editar(Empleados empleado)
        {
            if (this.iEmpleadosAplicacion == null)
                throw new Exception("No implementado");
            this.iEmpleadosAplicacion!.Editar(empleado);
        }

        [HttpDelete]
        public void Eliminar(int id)
        {
            if (this.iEmpleadosAplicacion == null)
                throw new Exception("No implementado");
            this.iEmpleadosAplicacion!.Eliminar(id);
        }
    }
}