

using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;

namespace lib_servicios_TiendaMusica.Modelos
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProveedoresController : ControllerBase
    {
        private IProveedoresAplicacion? iProveedoresAplicacion;

        public ProveedoresController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iProveedoresAplicacion = new ProveedoresAplicacion(conexion);
        }

        [HttpGet]
        public List<Proveedores> Consultar()
        {
            if (this.iProveedoresAplicacion == null)
                throw new Exception("No implementado");
            return this.iProveedoresAplicacion!.Obtener();
        }

        [HttpGet]
        public Proveedores ConsultarPorId(int id)
        {
            if (this.iProveedoresAplicacion == null)
                throw new Exception("No implementado");
            return this.iProveedoresAplicacion!.Obtener(id);
        }

        [HttpPost]
        public void Guardar(Proveedores proveedor)
        {
            if (this.iProveedoresAplicacion == null)
                throw new Exception("No implementado");
            this.iProveedoresAplicacion!.Guardar(proveedor);
        }

        [HttpPut]
        public void Editar(Proveedores proveedor)
        {
            if (this.iProveedoresAplicacion == null)
                throw new Exception("No implementado");
            this.iProveedoresAplicacion!.Editar(proveedor);
        }

        [HttpDelete]
        public void Eliminar(int id)
        {
            if (this.iProveedoresAplicacion == null)
                throw new Exception("No implementado");
            this.iProveedoresAplicacion!.Eliminar(id);
        }
    }
}
