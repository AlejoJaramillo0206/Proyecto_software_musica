

using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;

namespace lib_servicios_TiendaMusica.Modelos
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AlbumesReggaetonController : ControllerBase
    {
        private IAlbumesReggaetonAplicacion? iAlbumesReggaetonAplicacion;

        public AlbumesReggaetonController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iAlbumesReggaetonAplicacion = new AlbumesReggaetonAplicacion(conexion);
        }

        [HttpGet]
        public List<AlbumesReggaeton> Consultar()
        {
            if (this.iAlbumesReggaetonAplicacion == null)
                throw new Exception("No implementado");
            return this.iAlbumesReggaetonAplicacion!.Obtener();
        }

        [HttpGet]
        public AlbumesReggaeton ConsultarPorId(int id)
        {
            if (this.iAlbumesReggaetonAplicacion == null)
                throw new Exception("No implementado");
            return this.iAlbumesReggaetonAplicacion!.Obtener(id);
        }

        [HttpPost]
        public void Guardar(AlbumesReggaeton album)
        {
            if (this.iAlbumesReggaetonAplicacion == null)
                throw new Exception("No implementado");
            this.iAlbumesReggaetonAplicacion!.Guardar(album);
        }

        [HttpPut]
        public void Editar(AlbumesReggaeton album)
        {
            if (this.iAlbumesReggaetonAplicacion == null)
                throw new Exception("No implementado");
            this.iAlbumesReggaetonAplicacion!.Editar(album);
        }

        [HttpDelete]
        public void Eliminar(int id)
        {
            if (this.iAlbumesReggaetonAplicacion == null)
                throw new Exception("No implementado");
            this.iAlbumesReggaetonAplicacion!.Eliminar(id);
        }
    }
}
