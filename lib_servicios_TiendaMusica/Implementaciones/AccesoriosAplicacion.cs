using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using Microsoft.EntityFrameworkCore;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class AccesoriosAplicacion : IAccesoriosAplicacion
    {
        private readonly IConexion _conexion;

        public AccesoriosAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<Accesorios> Obtener() =>
            _conexion.Accesorios!.ToList();

        public Accesorios Obtener(int id) =>
            _conexion.Accesorios!.FirstOrDefault(a => a.Id == id)!;

        public Accesorios Guardar(Accesorios accesorio)
        {
            _conexion.Accesorios!.Add(accesorio);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("Accesorios", "Crear",
                $"Se creó el accesorio {accesorio.Nombre} con Id {accesorio.Id}", null);

            return accesorio;
        }

        public Accesorios Editar(Accesorios accesorio)
        {
            _conexion.Accesorios!.Update(accesorio);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("Accesorios", "Editar",
                $"Se editó el accesorio {accesorio.Nombre} con Id {accesorio.Id}", null);

            return accesorio;
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
                "DELETE FROM Accesorios WHERE Id = {0}", id);

           
            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Productos WHERE Id = {0}", id);

            new AuditoriasAplicacion(_conexion).Registrar("Accesorios", "Eliminar",
                $"Se eliminó el accesorio con Id {id}", null);

            return true;
        }
    }
}