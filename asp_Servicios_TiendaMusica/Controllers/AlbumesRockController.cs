
using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;

namespace lib_servicios_TiendaMusica.Modelos
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AlbumesRockController : ControllerBase
    {
        private IAlbumesRockAplicacion? iAlbumesRockAplicacion;

        public AlbumesRockController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iAlbumesRockAplicacion = new AlbumesRockAplicacion(conexion);
        }

        [HttpGet]
        public List<AlbumesRock> Consultar()
        {
            if (this.iAlbumesRockAplicacion == null)
                throw new Exception("No implementado");
            return this.iAlbumesRockAplicacion!.Obtener();
        }

        [HttpGet]
        public AlbumesRock ConsultarPorId(int id)
        {
            if (this.iAlbumesRockAplicacion == null)
                throw new Exception("No implementado");
            return this.iAlbumesRockAplicacion!.Obtener(id);
        }

        [HttpPost]
        public void Guardar(AlbumesRock album)
        {
            if (this.iAlbumesRockAplicacion == null)
                throw new Exception("No implementado");
            this.iAlbumesRockAplicacion!.Guardar(album);
        }

        [HttpPut]
        public void Editar(AlbumesRock album)
        {
            if (this.iAlbumesRockAplicacion == null)
                throw new Exception("No implementado");
            this.iAlbumesRockAplicacion!.Editar(album);
        }

        [HttpDelete]
        public void Eliminar(int id)
        {
            if (this.iAlbumesRockAplicacion == null)
                throw new Exception("No implementado");
            this.iAlbumesRockAplicacion!.Eliminar(id);
        }
    }
}
