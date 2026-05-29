using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using Microsoft.EntityFrameworkCore;

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

            _conexion.Database.ExecuteSqlRaw(
                     "DELETE FROM DetalleFacturas WHERE ProductoId = {0}", id);


            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Inventarios WHERE ProductoId = {0}", id);


            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Garantias WHERE ProductoId = {0}", id);


            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Reseñas WHERE ProductoId = {0}", id);


            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM AlbumesRock WHERE Id = {0}", id);


            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Productos WHERE Id = {0}", id);

            new AuditoriasAplicacion(_conexion).Registrar("AlbumesRock", "Eliminar",
                $"Se eliminó el álbum rock con Id {id}", null);

            return true;
        }
    }
}