using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;

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
            // 1. Eliminar inventario vinculado
            var inventario = _conexion.Inventarios!
                .FirstOrDefault(i => i.ProductoId == id);

            if (inventario != null)
            {
                _conexion.Inventarios!.Remove(inventario);
                _conexion.SaveChanges();
            }

            // 2. Eliminar el subtipo
            var instrumentosAire = Obtener(id);
            _conexion.InstrumentosAire!.Remove(instrumentosAire);
            _conexion.SaveChanges();

            // 3. Eliminar el producto base
            var producto = _conexion.Productos!
                .FirstOrDefault(p => p.Id == id);

            if (producto != null)
            {
                _conexion.Productos!.Remove(producto);
                _conexion.SaveChanges();
            }

            new AuditoriasAplicacion(_conexion).Registrar("InstrumentosAire", "Eliminar",
                $"Se eliminó el Instrumento Aire con Id {id}", null);

            return true;
        }
    }
}