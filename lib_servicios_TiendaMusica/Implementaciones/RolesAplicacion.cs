using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class RolesAplicacion : IRolesAplicacion
    {
        private readonly IConexion _conexion;

        public RolesAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<Roles> Obtener() =>
            _conexion.Roles!.ToList();

        public Roles Obtener(int id) =>
            _conexion.Roles!.FirstOrDefault(r => r.Id == id)!;

        public Roles Guardar(Roles rol)
        {
            _conexion.Roles!.Add(rol);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("Roles", "Crear",
                $"Se creó el rol {rol.Nombre} con Id {rol.Id}", null);

            return rol;
        }

        public Roles Editar(Roles rol)
        {
            _conexion.Roles!.Update(rol);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("Roles", "Editar",
                $"Se editó el rol {rol.Nombre} con Id {rol.Id}", null);

            return rol;
        }

        public bool Eliminar(int id)
        {
            var rol = Obtener(id);
            _conexion.Roles!.Remove(rol);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("Roles", "Eliminar",
                $"Se eliminó el rol con Id {id}", null);

            return true;
        }
    }
}