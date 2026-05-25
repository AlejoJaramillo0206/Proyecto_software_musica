using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class AlbumesClasicosAplicacion : IAlbumesClasicosAplicacion
    {
        private readonly IConexion _conexion;

        public AlbumesClasicosAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<AlbumesClasicos> Obtener() =>
            _conexion.AlbumesClasicos!.ToList();

        public AlbumesClasicos Obtener(int id) =>
            _conexion.AlbumesClasicos!.FirstOrDefault(a => a.Id == id)!;

        public AlbumesClasicos Guardar(AlbumesClasicos album)
        {
            _conexion.AlbumesClasicos!.Add(album);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("AlbumesClasicos", "Crear",
                $"Se creó el álbum clásico {album.Nombre} con Id {album.Id}", null);

            return album;
        }

        public AlbumesClasicos Editar(AlbumesClasicos album)
        {
            _conexion.AlbumesClasicos!.Update(album);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("AlbumesClasicos", "Editar",
                $"Se editó el álbum clásico {album.Nombre} con Id {album.Id}", null);

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
            var albumesClasicos = Obtener(id);
            _conexion.AlbumesClasicos!.Remove(albumesClasicos);
            _conexion.SaveChanges();

            // 3. Eliminar el producto base
            var producto = _conexion.Productos!
                .FirstOrDefault(p => p.Id == id);

            if (producto != null)
            {
                _conexion.Productos!.Remove(producto);
                _conexion.SaveChanges();
            }

            new AuditoriasAplicacion(_conexion).Registrar("AlbumesClasicos", "Eliminar",
                $"Se eliminó el álbum clásico con Id {id}", null);

            return true;
        }
    }
}