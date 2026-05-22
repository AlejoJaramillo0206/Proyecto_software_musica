

using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;

namespace lib_servicios_TiendaMusica.Modelos
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AlbumesClasicosController : ControllerBase
    {
        private IAlbumesClasicosAplicacion? iAlbumesClasicosAplicacion;

        public AlbumesClasicosController()
        {
            IConexion conexion = new Conexion();
            conexion.string_conexion = Configuraciones.obtener("conexion");
            this.iAlbumesClasicosAplicacion = new AlbumesClasicosAplicacion(conexion);
        }

        [HttpGet]
        public List<AlbumesClasicos> Consultar()
        {
            if (this.iAlbumesClasicosAplicacion == null)
                throw new Exception("No implementado");
            return this.iAlbumesClasicosAplicacion!.Obtener();
        }

        [HttpGet]
        public AlbumesClasicos ConsultarPorId(int id)
        {
            if (this.iAlbumesClasicosAplicacion == null)
                throw new Exception("No implementado");
            return this.iAlbumesClasicosAplicacion!.Obtener(id);
        }

        [HttpPost]
        public AlbumesClasicos Guardar(AlbumesClasicos album)
        {
            if (this.iAlbumesClasicosAplicacion == null)
                throw new Exception("No implementado");
           return this.iAlbumesClasicosAplicacion!.Guardar(album);
        }

        [HttpPut]
        public AlbumesClasicos Editar(AlbumesClasicos album)
        {
            if (this.iAlbumesClasicosAplicacion == null)
                throw new Exception("No implementado");
            return this.iAlbumesClasicosAplicacion!.Editar(album);
        }

        [HttpDelete]
        public bool Eliminar(int id)
        {
            if (this.iAlbumesClasicosAplicacion == null)
                throw new Exception("No implementado");
            return this.iAlbumesClasicosAplicacion!.Eliminar(id);
        }
    }

}
