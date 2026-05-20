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
        void Guardar(Empleados empleado);
        void Editar(Empleados empleado);
        void Eliminar(int id);
    }
}
