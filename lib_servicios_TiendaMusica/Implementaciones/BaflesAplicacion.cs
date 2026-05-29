using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using Microsoft.EntityFrameworkCore;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class BaflesAplicacion : IBaflesAplicacion
    {
        private readonly IConexion _conexion;

        public BaflesAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<Bafles> Obtener() =>
            _conexion.Bafles!.ToList();

        public Bafles Obtener(int id) =>
            _conexion.Bafles!.FirstOrDefault(b => b.Id == id)!;

        public Bafles Guardar(Bafles bafl)
        {
            _conexion.Bafles!.Add(bafl);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("Bafles", "Crear",
                $"Se creó el bafle {bafl.Nombre} con Id {bafl.Id}", null);

            return bafl;
        }

        public Bafles Editar(Bafles bafl)
        {
            _conexion.Bafles!.Update(bafl);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("Bafles", "Editar",
                $"Se editó el bafle {bafl.Nombre} con Id {bafl.Id}", null);

            return bafl;
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
                "DELETE FROM Bafles WHERE Id = {0}", id);


            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Productos WHERE Id = {0}", id);

            new AuditoriasAplicacion(_conexion).Registrar("Bafles", "Eliminar",
                $"Se eliminó el bafle con Id {id}", null);

            return true;
        }
    }
}