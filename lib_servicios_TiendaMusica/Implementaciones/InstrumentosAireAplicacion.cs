using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using Microsoft.EntityFrameworkCore;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class InstrumentosAireAplicacion : IInstrumentosAireAplicacion
    {
        private readonly IConexion _conexion;

        public InstrumentosAireAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<InstrumentosAire> Obtener() =>
            _conexion.InstrumentosAire!.ToList();

        public InstrumentosAire Obtener(int id) =>
            _conexion.InstrumentosAire!.FirstOrDefault(i => i.Id == id)!;

        public InstrumentosAire Guardar(InstrumentosAire instrumento)
        {
            _conexion.InstrumentosAire!.Add(instrumento);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("InstrumentosAire", "Crear",
                $"Se creó el instrumento {instrumento.Nombre} con Id {instrumento.Id}", null);

            return instrumento;
        }

        public InstrumentosAire Editar(InstrumentosAire instrumento)
        {
            _conexion.InstrumentosAire!.Update(instrumento);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("InstrumentosAire", "Editar",
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
                "DELETE FROM InstrumentosAire WHERE Id = {0}", id);


            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Productos WHERE Id = {0}", id);

            new AuditoriasAplicacion(_conexion).Registrar("InstrumentosAire", "Eliminar",
                $"Se eliminó el Instrumento Aire con Id {id}", null);

            return true;
        }
    }
}