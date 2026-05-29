using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using Microsoft.EntityFrameworkCore;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class InstrumentosPercusionAplicacion : IInstrumentosPercusionAplicacion
    {
        private readonly IConexion _conexion;

        public InstrumentosPercusionAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<InstrumentosPercusion> Obtener() =>
            _conexion.InstrumentosPercusion!.ToList();

        public InstrumentosPercusion Obtener(int id) =>
            _conexion.InstrumentosPercusion!.FirstOrDefault(i => i.Id == id)!;

        public InstrumentosPercusion Guardar(InstrumentosPercusion instrumento)
        {
            _conexion.InstrumentosPercusion!.Add(instrumento);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("InstrumentosPercusion", "Crear",
                $"Se creó el instrumento {instrumento.Nombre} con Id {instrumento.Id}", null);

            return instrumento;
        }

        public InstrumentosPercusion Editar(InstrumentosPercusion instrumento)
        {
            _conexion.InstrumentosPercusion!.Update(instrumento);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("InstrumentosPercusion", "Editar",
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
                "DELETE FROM InstrumentosPercusion WHERE Id = {0}", id);


            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Productos WHERE Id = {0}", id);

            new AuditoriasAplicacion(_conexion).Registrar("InstrumentosPercusion", "Eliminar",
                $"Se eliminó el Instrumento Percusion con Id {id}", null);

            return true;
        }
    }
}