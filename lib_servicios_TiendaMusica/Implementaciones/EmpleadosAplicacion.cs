using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using Microsoft.EntityFrameworkCore;


namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class EmpleadosAplicacion : IEmpleadosAplicacion
    {
        private readonly IConexion _conexion;

        public EmpleadosAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<Empleados> Obtener() =>
            _conexion.Empleados!.ToList();

        public Empleados Obtener(int id) =>
            _conexion.Empleados!.FirstOrDefault(e => e.Id == id)!;

        public Empleados Guardar(Empleados empleado)
        {
                _conexion.Database.ExecuteSqlRaw(
            "INSERT INTO Empleados (Id, Numero_Banco, Numero_ARL, Cargo, FechaIngreso, Activo, ValorDia, DiasTrabajados) " +
            "VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})",
            empleado.Id,
            empleado.Numero_Banco ?? "Sin definir",
            empleado.Numero_ARL ?? "Sin definir",
            empleado.Cargo ?? "Sin definir",
            empleado.FechaIngreso,
            empleado.Activo,
            empleado.ValorDia,
            empleado.DiasTrabajados
    );

            new AuditoriasAplicacion(_conexion).Registrar("Empleados", "Crear",
                $"Se creó el empleado {empleado.Nombre} con Id {empleado.Id}", null);

            return empleado;
        }

        public Empleados Editar(Empleados empleado)
        {
            _conexion.Empleados!.Update(empleado);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("Empleados", "Editar",
                $"Se editó el empleado {empleado.Nombre} con Id {empleado.Id}", null);

            return empleado;
        }

        public bool Eliminar(int id)
        {
            
            var usuario = _conexion.Usuarios!
                .FirstOrDefault(u => u.EmpleadoId == id);

            if (usuario != null)
            {
               
                var roles = _conexion.UsuarioRoles!
                    .Where(ur => ur.UsuarioId == usuario.Id)
                    .ToList();

                if (roles.Any())
                {
                    _conexion.UsuarioRoles!.RemoveRange(roles);
                    _conexion.SaveChanges();
                }

               
                _conexion.Usuarios!.Remove(usuario);
                _conexion.SaveChanges();
            }

     
            var empleado = Obtener(id);
            _conexion.Empleados!.Remove(empleado);
            _conexion.SaveChanges();


            var persona = _conexion.Personas!
                .FirstOrDefault(p => p.Id == id);

            if (persona != null)
            {
                _conexion.Personas!.Remove(persona);
                _conexion.SaveChanges();
            }

            new AuditoriasAplicacion(_conexion).Registrar("Empleados", "Eliminar",
                $"Se eliminó el empleado con Id {id}", null);

            return true;
        }
    }
}