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
    public class ReseñasController : ControllerBase
    {
        private IReseñasAplicacion? iReseñasAplicacion;

        public ReseñasController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iReseñasAplicacion = new ReseñasAplicacion(conexion);
        }

        [HttpGet]
        public List<Reseñas> Consultar()
        {
            if (this.iReseñasAplicacion == null)
                throw new Exception("No implementado");
            return this.iReseñasAplicacion!.Obtener();
        }

        [HttpGet]
        public Reseñas ConsultarPorId(int id)
        {
            if (this.iReseñasAplicacion == null)
                throw new Exception("No implementado");
            return this.iReseñasAplicacion!.Obtener(id);
        }

        [HttpGet]
        public List<Reseñas> ConsultarPorProducto(int productoId)
        {
            if (this.iReseñasAplicacion == null)
                throw new Exception("No implementado");
            return this.iReseñasAplicacion!.ObtenerPorProducto(productoId);
        }

        [HttpPost]
        public Reseñas Guardar(Reseñas reseña)
        {
            if (this.iReseñasAplicacion == null)
                throw new Exception("No implementado");
            return this.iReseñasAplicacion!.Guardar(reseña);
        }
    }
}
