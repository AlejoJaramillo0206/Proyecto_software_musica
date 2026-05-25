using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class ProveedoresAplicacion : IProveedoresAplicacion
    {
        private readonly IConexion _conexion;

        public ProveedoresAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<Proveedores> Obtener() =>
            _conexion.Proveedores!.ToList();

        public Proveedores Obtener(int id) =>
            _conexion.Proveedores!.FirstOrDefault(p => p.Id == id)!;

        public Proveedores Guardar(Proveedores proveedor)
        {
            _conexion.Proveedores!.Add(proveedor);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("Proveedores", "Crear",
                $"Se creó el proveedor {proveedor.Nombre_Empresa} con Id {proveedor.Id}", null);

            return proveedor;
        }

        public Proveedores Editar(Proveedores proveedor)
        {
            _conexion.Proveedores!.Update(proveedor);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("Proveedores", "Editar",
                $"Se editó el proveedor {proveedor.Nombre_Empresa} con Id {proveedor.Id}", null);

            return proveedor;
        }

        public bool Eliminar(int id)
        {
            var proveedor = Obtener(id);
            _conexion.Proveedores!.Remove(proveedor);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("Proveedores", "Eliminar",
                $"Se eliminó el proveedor con Id {id}", null);

            return true;
        }
    }
}