using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Modelos
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RolesController : ControllerBase
    {
        private IRolesAplicacion? iRolesAplicacion;

        public RolesController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iRolesAplicacion = new RolesAplicacion(conexion);
        }

        [HttpGet]
        public List<Roles> Consultar()
        {
            if (this.iRolesAplicacion == null)
                throw new Exception("No implementado");
            return this.iRolesAplicacion!.Obtener();
        }

        [HttpGet]
        public Roles ConsultarPorId(int id)
        {
            if (this.iRolesAplicacion == null)
                throw new Exception("No implementado");
            return this.iRolesAplicacion!.Obtener(id);
        }

        [HttpPost]
        public Roles Guardar(Roles rol)
        {
            if (this.iRolesAplicacion == null)
                throw new Exception("No implementado");
            return this.iRolesAplicacion!.Guardar(rol);
        }

        [HttpPut]
        public Roles Editar(Roles rol)
        {
            if (this.iRolesAplicacion == null)
                throw new Exception("No implementado");
            return this.iRolesAplicacion!.Editar(rol);
        }

        [HttpDelete]
        public bool Eliminar(int id)
        {
            if (this.iRolesAplicacion == null)
                throw new Exception("No implementado");
            return this.iRolesAplicacion!.Eliminar(id);
        }
    }
}
