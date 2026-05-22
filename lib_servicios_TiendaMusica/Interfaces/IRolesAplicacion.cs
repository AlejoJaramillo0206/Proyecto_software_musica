using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Interfaces
{
    public interface IRolesAplicacion
    {
        List<Roles> Obtener();
        Roles Obtener(int id);
        Roles Guardar(Roles rol);
        Roles Editar(Roles rol);
        bool Eliminar(int id);
    }
}
