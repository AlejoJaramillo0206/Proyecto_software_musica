using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;

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
            _conexion.AlbumesRock!.FirstOrDefault(a => a.Id == id)!;

        public AlbumesRock Guardar(AlbumesRock album)
        {
            _conexion.AlbumesRock!.Add(album);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("AlbumesRock", "Crear",
                $"Se creó el álbum rock {album.Nombre} con Id {album.Id}", null);

            return album;
        }

        public AlbumesRock Editar(AlbumesRock album)
        {
            _conexion.AlbumesRock!.Update(album);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("AlbumesRock", "Editar",
                $"Se editó el álbum rock {album.Nombre} con Id {album.Id}", null);

            return album;
        }

        public bool Eliminar(int id)
        {
            // 1. Eliminar inventario vinculado
            var inventario = _conexion.Inventarios!
                .FirstOrDefault(i => i.ProductoId == id);

            if (inventario != null)
            {
                _conexion.Inventarios!.Remove(inventario);
                _conexion.SaveChanges();
            }

            // 2. Eliminar el subtipo
            var albumesRock = Obtener(id);
            _conexion.AlbumesRock!.Remove(albumesRock);
            _conexion.SaveChanges();

            // 3. Eliminar el producto base
            var producto = _conexion.Productos!
                .FirstOrDefault(p => p.Id == id);

            if (producto != null)
            {
                _conexion.Productos!.Remove(producto);
                _conexion.SaveChanges();
            }

            new AuditoriasAplicacion(_conexion).Registrar("AlbumesRock", "Eliminar",
                $"Se eliminó el álbum rock con Id {id}", null);

            return true;
        }
    }
}