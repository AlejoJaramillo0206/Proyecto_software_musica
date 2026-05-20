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
                _conexion.AlbumesReggaeton!.First(a => a.Id == id);

            public void Guardar(AlbumesReggaeton album)
            {
                _conexion.AlbumesReggaeton!.Add(album);
                _conexion.SaveChanges();
            }

            public void Editar(AlbumesReggaeton album)
            {
                _conexion.AlbumesReggaeton!.Update(album);
                _conexion.SaveChanges();
            }

            public void Eliminar(int id)
            {
                var album = Obtener(id);
                _conexion.AlbumesReggaeton!.Remove(album);
                _conexion.SaveChanges();
            }
        }
}

