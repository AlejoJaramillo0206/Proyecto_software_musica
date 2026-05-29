using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using Microsoft.EntityFrameworkCore;

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
            _conexion.AlbumesPop!.FirstOrDefault(a => a.Id == id)!;

        public AlbumesPop Guardar(AlbumesPop album)
        {
            _conexion.AlbumesPop!.Add(album);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("AlbumesPop", "Crear",
                $"Se creó el álbum pop {album.Nombre} con Id {album.Id}", null);

            return album;
        }

        public AlbumesPop Editar(AlbumesPop album)
        {
            _conexion.AlbumesPop!.Update(album);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("AlbumesPop", "Editar",
                $"Se editó el álbum pop {album.Nombre} con Id {album.Id}", null);

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
                "DELETE FROM AlbumesPop WHERE Id = {0}", id);


            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Productos WHERE Id = {0}", id);

            new AuditoriasAplicacion(_conexion).Registrar("AlbumesPop", "Eliminar",
                $"Se eliminó el álbum pop con Id {id}", null);

            return true;
        }
    }
}