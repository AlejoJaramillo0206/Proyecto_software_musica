using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Modelos
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosAplicacion? iUsuariosAplicacion;

        public UsuariosController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iUsuariosAplicacion = new UsuariosAplicacion(conexion);
        }

        [HttpGet]
        public List<Usuarios> Consultar()
        {
            if (this.iUsuariosAplicacion == null)
                throw new Exception("No implementado");
            return this.iUsuariosAplicacion!.Obtener();
        }

        [HttpGet]
        public Usuarios ConsultarPorId(int id)
        {
            if (this.iUsuariosAplicacion == null)
                throw new Exception("No implementado");
            return this.iUsuariosAplicacion!.Obtener(id);
        }

        [HttpGet]
        public Usuarios ConsultarPorUsername(string username)
        {
            if (this.iUsuariosAplicacion == null)
                throw new Exception("No implementado");
            return this.iUsuariosAplicacion!.ObtenerPorUsername(username);
        }

        [HttpPost]
        public Usuarios Guardar(Usuarios usuario)
        {
            if (this.iUsuariosAplicacion == null)
                throw new Exception("No implementado");
            return this.iUsuariosAplicacion!.Guardar(usuario);
        }

        [HttpPut]
        public Usuarios Editar(Usuarios usuario)
        {
            if (this.iUsuariosAplicacion == null)
                throw new Exception("No implementado");
            return this.iUsuariosAplicacion!.Editar(usuario);
        }

        [HttpDelete]
        public bool Eliminar(int id)
        {
            if (this.iUsuariosAplicacion == null)
                throw new Exception("No implementado");
            return this.iUsuariosAplicacion!.Eliminar(id);
        }
    }
}
