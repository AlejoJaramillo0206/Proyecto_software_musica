using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class AlbumesPopAplicacion : IAlbumesPopAplicacion
    {
        private readonly IConexion _conexion;

        public AlbumesPopAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<AlbumesPop> Obtener() =>
            _conexion.AlbumesPop!.ToList();

        public AlbumesPop Obtener(int id) =>
            _conexion.AlbumesPop!.First(a => a.Id == id);

        public void Guardar(AlbumesPop album)
        {
            _conexion.AlbumesPop!.Add(album);
            _conexion.SaveChanges();
        }

        public void Editar(AlbumesPop album)
        {
            _conexion.AlbumesPop!.Update(album);
            _conexion.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var album = Obtener(id);
            _conexion.AlbumesPop!.Remove(album);
            _conexion.SaveChanges();
        }
    }
}
