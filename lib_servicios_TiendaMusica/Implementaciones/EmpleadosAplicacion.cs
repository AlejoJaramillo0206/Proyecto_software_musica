using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _conexion.Empleados!.First(e => e.Id == id);

        public void Guardar(Empleados empleado)
        {
            _conexion.Empleados!.Add(empleado);
            _conexion.SaveChanges();
        }

        public void Editar(Empleados empleado)
        {
            _conexion.Empleados!.Update(empleado);
            _conexion.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var empleado = Obtener(id);
            _conexion.Empleados!.Remove(empleado);
            _conexion.SaveChanges();
        }
    }

}
