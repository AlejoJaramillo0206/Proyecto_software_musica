using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;

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
            // 1. Eliminar inventario vinculado
            var inventario = _conexion.Inventarios!
                .FirstOrDefault(i => i.ProductoId == id);

            if (inventario != null)
            {
                _conexion.Inventarios!.Remove(inventario);
                _conexion.SaveChanges();
            }

            // 2. Eliminar el subtipo
            var accesorio = Obtener(id);
            _conexion.Accesorios!.Remove(accesorio);
            _conexion.SaveChanges();

            // 3. Eliminar el producto base
            var producto = _conexion.Productos!
                .FirstOrDefault(p => p.Id == id);

            if (producto != null)
            {
                _conexion.Productos!.Remove(producto);
                _conexion.SaveChanges();
            }

            new AuditoriasAplicacion(_conexion).Registrar("Accesorio", "Eliminar",
                $"Se eliminó el accesorio con Id {id}", null);

            return true;
        }
    }
}