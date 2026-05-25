using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;

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
            // 1. Eliminar inventario vinculado
            var inventario = _conexion.Inventarios!
                .FirstOrDefault(i => i.ProductoId == id);

            if (inventario != null)
            {
                _conexion.Inventarios!.Remove(inventario);
                _conexion.SaveChanges();
            }

            // 2. Eliminar el subtipo
            var instrumentosPercusion = Obtener(id);
            _conexion.InstrumentosPercusion!.Remove(instrumentosPercusion);
            _conexion.SaveChanges();

            // 3. Eliminar el producto base
            var producto = _conexion.Productos!
                .FirstOrDefault(p => p.Id == id);

            if (producto != null)
            {
                _conexion.Productos!.Remove(producto);
                _conexion.SaveChanges();
            }

            new AuditoriasAplicacion(_conexion).Registrar("InstrumentosPercusion", "Eliminar",
                $"Se eliminó el Instrumento Percusion con Id {id}", null);

            return true;
        }
    }
}