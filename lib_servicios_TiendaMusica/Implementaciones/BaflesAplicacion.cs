using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;

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
            // 1. Eliminar inventario vinculado
            var inventario = _conexion.Inventarios!
                .FirstOrDefault(i => i.ProductoId == id);

            if (inventario != null)
            {
                _conexion.Inventarios!.Remove(inventario);
                _conexion.SaveChanges();
            }

            // 2. Eliminar el subtipo
            var bafle = Obtener(id);
            _conexion.Bafles!.Remove(bafle);
            _conexion.SaveChanges();

            // 3. Eliminar el producto base
            var producto = _conexion.Productos!
                .FirstOrDefault(p => p.Id == id);

            if (producto != null)
            {
                _conexion.Productos!.Remove(producto);
                _conexion.SaveChanges();
            }

            new AuditoriasAplicacion(_conexion).Registrar("Bafles", "Eliminar",
                $"Se eliminó el bafle con Id {id}", null);

            return true;
        }
    }
}