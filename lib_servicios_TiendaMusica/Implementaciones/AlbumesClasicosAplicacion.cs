using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using Microsoft.EntityFrameworkCore;

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

            _conexion.Database.ExecuteSqlRaw(
                     "DELETE FROM DetalleFacturas WHERE ProductoId = {0}", id);


            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Inventarios WHERE ProductoId = {0}", id);


            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Garantias WHERE ProductoId = {0}", id);


            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Reseñas WHERE ProductoId = {0}", id);


            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM AlbumesClasicos WHERE Id = {0}", id);


            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Productos WHERE Id = {0}", id);

            new AuditoriasAplicacion(_conexion).Registrar("AlbumesClasicos", "Eliminar",
                $"Se eliminó el álbum clásico con Id {id}", null);

            return true;
        }
    }
}