using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using Microsoft.EntityFrameworkCore;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class InstrumentosCuerdasAplicacion : IInstrumentosCuerdasAplicacion
    {
        private readonly IConexion _conexion;

        public InstrumentosCuerdasAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<InstrumentosCuerdas> Obtener() =>
            _conexion.InstrumentosCuerdas!.ToList();

        public InstrumentosCuerdas Obtener(int id) =>
            _conexion.InstrumentosCuerdas!.FirstOrDefault(i => i.Id == id)!;

        public InstrumentosCuerdas Guardar(InstrumentosCuerdas instrumento)
        {
            _conexion.InstrumentosCuerdas!.Add(instrumento);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("InstrumentosCuerdas", "Crear",
                $"Se creó el instrumento {instrumento.Nombre} con Id {instrumento.Id}", null);

            return instrumento;
        }

        public InstrumentosCuerdas Editar(InstrumentosCuerdas instrumento)
        {
            _conexion.InstrumentosCuerdas!.Update(instrumento);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("InstrumentosCuerdas", "Editar",
                $"Se editó el instrumento {instrumento.Nombre} con Id {instrumento.Id}", null);

            return instrumento;
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
                "DELETE FROM InstrumentosCuerdas WHERE Id = {0}", id);


            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Productos WHERE Id = {0}", id);

            new AuditoriasAplicacion(_conexion).Registrar("InstrumentosCuerdas", "Eliminar",
                $"Se eliminó el Instrumento Cuerdas con Id {id}", null);

            return true;
        }
    }
}