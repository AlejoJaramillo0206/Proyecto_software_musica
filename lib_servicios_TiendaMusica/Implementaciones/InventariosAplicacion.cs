using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class InventariosAplicacion : IInventariosAplicacion
    {
        private readonly IConexion _conexion;

        public InventariosAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<Inventarios> Obtener() =>
            _conexion.Inventarios!.ToList();

        public Inventarios Obtener(int id) =>
            _conexion.Inventarios!.FirstOrDefault(i => i.Id == id)!;

        public Inventarios ObtenerPorProducto(int productoId) =>
            _conexion.Inventarios!.FirstOrDefault(i => i.ProductoId == productoId)!;

        public Inventarios Guardar(Inventarios inventario)
        {
            inventario.FechaActualizacion = DateTime.Now;
            _conexion.Inventarios!.Add(inventario);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("Inventarios", "Crear",
                $"Se creó inventario para producto Id {inventario.ProductoId}", null);

            return inventario;
        }

        public Inventarios Editar(Inventarios inventario)
        {
            inventario.FechaActualizacion = DateTime.Now;
            _conexion.Inventarios!.Update(inventario);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("Inventarios", "Editar",
                $"Se actualizó inventario Id {inventario.Id}, stock: {inventario.StockDisponible}", null);

            return inventario;
        }

        public bool Eliminar(int id)
        {
            var inventario = Obtener(id);
            _conexion.Inventarios!.Remove(inventario);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("Inventarios", "Eliminar",
                $"Se eliminó el inventario con Id {id}", null);

            return true;
        }
    }
}