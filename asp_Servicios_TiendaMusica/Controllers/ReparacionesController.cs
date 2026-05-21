using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
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
    public class ReparacionesController : ControllerBase
    {
        private IReparacionesAplicacion? iReparacionesAplicacion;

        public ReparacionesController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iReparacionesAplicacion = new ReparacionesAplicacion(conexion);
        }

        [HttpGet]
        public List<Reparaciones> Consultar()
        {
            if (this.iReparacionesAplicacion == null)
                throw new Exception("No implementado");
            return this.iReparacionesAplicacion!.Obtener();
        }

        [HttpGet]
        public Reparaciones ConsultarPorId(int id)
        {
            if (this.iReparacionesAplicacion == null)
                throw new Exception("No implementado");
            return this.iReparacionesAplicacion!.Obtener(id);
        }

        [HttpGet]
        public List<Reparaciones> ConsultarPorCliente(int clienteId)
        {
            if (this.iReparacionesAplicacion == null)
                throw new Exception("No implementado");
            return this.iReparacionesAplicacion!.ObtenerPorCliente(clienteId);
        }

        [HttpPost]
        public void Guardar(Reparaciones reparacion)
        {
            if (this.iReparacionesAplicacion == null)
                throw new Exception("No implementado");
            this.iReparacionesAplicacion!.Guardar(reparacion);
        }
    }
}
