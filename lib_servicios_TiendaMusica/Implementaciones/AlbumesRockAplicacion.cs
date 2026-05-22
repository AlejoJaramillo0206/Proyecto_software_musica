using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class AlbumesRockAplicacion : IAlbumesRockAplicacion
    {
        private readonly IConexion _conexion;

        public AlbumesRockAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<AlbumesRock> Obtener() =>
            _conexion.AlbumesRock!.ToList();

        public AlbumesRock Obtener(int id) =>
            _conexion.AlbumesRock!.First(a => a.Id == id);

        public AlbumesRock Guardar(AlbumesRock album)
        {
            _conexion.AlbumesRock!.Add(album);
            _conexion.SaveChanges();
            return album;
        }

        public AlbumesRock Editar(AlbumesRock album)
        {
            _conexion.AlbumesRock!.Update(album);
            _conexion.SaveChanges();
            return album;
        }

        public bool Eliminar(int id)
        {
            var album = Obtener(id);
            _conexion.AlbumesRock!.Remove(album);
            _conexion.SaveChanges();
            return true;
        }
    }
}
