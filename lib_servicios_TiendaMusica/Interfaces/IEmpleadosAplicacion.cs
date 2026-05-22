using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Interfaces
{
    public interface IEmpleadosAplicacion
    {
        List<Empleados> Obtener();
        Empleados Obtener(int id);
        Empleados Guardar(Empleados empleado);
        Empleados Editar(Empleados empleado);
        bool Eliminar(int id);
    }
}
