using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;

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
            _conexion.AlbumesReggaeton!.FirstOrDefault(a => a.Id == id)!;

        public AlbumesReggaeton Guardar(AlbumesReggaeton album)
        {
            _conexion.AlbumesReggaeton!.Add(album);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("AlbumesReggaeton", "Crear",
                $"Se creó el álbum reggaeton {album.Nombre} con Id {album.Id}", null);

            return album;
        }

        public AlbumesReggaeton Editar(AlbumesReggaeton album)
        {
            _conexion.AlbumesReggaeton!.Update(album);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("AlbumesReggaeton", "Editar",
                $"Se editó el álbum reggaeton {album.Nombre} con Id {album.Id}", null);

            return album;
        }

        public bool Eliminar(int id)
        {
            var inventario = _conexion.Inventarios!
                .FirstOrDefault(i => i.ProductoId == id);

            if (inventario != null)
            {
                _conexion.Inventarios!.Remove(inventario);
                _conexion.SaveChanges();
            }

          
            var albumesReggaeton = Obtener(id);
            _conexion.AlbumesReggaeton!.Remove(albumesReggaeton);
            _conexion.SaveChanges();

           
            var producto = _conexion.Productos!
                .FirstOrDefault(p => p.Id == id);

            if (producto != null)
            {
                _conexion.Productos!.Remove(producto);
                _conexion.SaveChanges();
            }

            new AuditoriasAplicacion(_conexion).Registrar("AlbumesReggaeton", "Eliminar",
                $"Se eliminó el álbum reggaeton con Id {id}", null);

            return true;
        }
    }
}