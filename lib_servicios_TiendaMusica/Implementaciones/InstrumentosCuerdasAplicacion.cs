using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;

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
            // 1. Eliminar inventario vinculado
            var inventario = _conexion.Inventarios!
                .FirstOrDefault(i => i.ProductoId == id);

            if (inventario != null)
            {
                _conexion.Inventarios!.Remove(inventario);
                _conexion.SaveChanges();
            }

            // 2. Eliminar el subtipo
            var instrumentosCuerdas = Obtener(id);
            _conexion.InstrumentosCuerdas!.Remove(instrumentosCuerdas);
            _conexion.SaveChanges();

            // 3. Eliminar el producto base
            var producto = _conexion.Productos!
                .FirstOrDefault(p => p.Id == id);

            if (producto != null)
            {
                _conexion.Productos!.Remove(producto);
                _conexion.SaveChanges();
            }

            new AuditoriasAplicacion(_conexion).Registrar("InstrumentosCuerdas", "Eliminar",
                $"Se eliminó el Instrumento Cuerdas con Id {id}", null);

            return true;
        }
    }
}