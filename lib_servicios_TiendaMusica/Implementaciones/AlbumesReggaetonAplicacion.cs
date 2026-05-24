using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Implementaciones
{
        public class AlbumesReggaetonAplicacion : IAlbumesReggaetonAplicacion
        {
            private readonly IConexion _conexion;

            public AlbumesReggaetonAplicacion(IConexion conexion)
            {
                _conexion = conexion;
            }

            public List<AlbumesReggaeton> Obtener() =>
                _conexion.AlbumesReggaeton!.ToList();

            public AlbumesReggaeton Obtener(int id) =>
               _conexion.AlbumesReggaeton!.FirstOrDefault(c => c.Id == id)!;

        public AlbumesReggaeton Guardar(AlbumesReggaeton album)
            {
                _conexion.AlbumesReggaeton!.Add(album);
            _conexion.SaveChanges();
            return album;
        }

        public AlbumesReggaeton Editar(AlbumesReggaeton album)
            {
                _conexion.AlbumesReggaeton!.Update(album);
            _conexion.SaveChanges();
            return album;
        }

        public bool Eliminar(int id)
            {
                var album = Obtener(id);
                _conexion.AlbumesReggaeton!.Remove(album);
            _conexion.SaveChanges();
            return true;
        }
    }
}

