using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using Microsoft.EntityFrameworkCore;

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
            _conexion.Database.ExecuteSqlRaw(
                  "DELETE FROM DetalleFacturas WHERE ProductoId = {0}", id);


            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Inventarios WHERE ProductoId = {0}", id);


            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Garantias WHERE ProductoId = {0}", id);


            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Reseñas WHERE ProductoId = {0}", id);


            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM AlbumesReggaeton WHERE Id = {0}", id);


            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Productos WHERE Id = {0}", id);

            new AuditoriasAplicacion(_conexion).Registrar("AlbumesReggaeton", "Eliminar",
                $"Se eliminó el álbum reggaeton con Id {id}", null);

            return true;
        }
    }
}