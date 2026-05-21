

using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;

namespace lib_servicios_TiendaMusica.Modelos
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AlbumesPopController : ControllerBase
    {
        private IAlbumesPopAplicacion? iAlbumesPopAplicacion;

        public AlbumesPopController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iAlbumesPopAplicacion = new AlbumesPopAplicacion(conexion);
        }

        [HttpGet]
        public List<AlbumesPop> Consultar()
        {
            if (this.iAlbumesPopAplicacion == null)
                throw new Exception("No implementado");
            return this.iAlbumesPopAplicacion!.Obtener();
        }

        [HttpGet]
        public AlbumesPop ConsultarPorId(int id)
        {
            if (this.iAlbumesPopAplicacion == null)
                throw new Exception("No implementado");
            return this.iAlbumesPopAplicacion!.Obtener(id);
        }

        [HttpPost]
        public void Guardar(AlbumesPop album)
        {
            if (this.iAlbumesPopAplicacion == null)
                throw new Exception("No implementado");
            this.iAlbumesPopAplicacion!.Guardar(album);
        }

        [HttpPut]
        public void Editar(AlbumesPop album)
        {
            if (this.iAlbumesPopAplicacion == null)
                throw new Exception("No implementado");
            this.iAlbumesPopAplicacion!.Editar(album);
        }

        [HttpDelete]
        public void Eliminar(int id)
        {
            if (this.iAlbumesPopAplicacion == null)
                throw new Exception("No implementado");
            this.iAlbumesPopAplicacion!.Eliminar(id);
        }
    }

}
