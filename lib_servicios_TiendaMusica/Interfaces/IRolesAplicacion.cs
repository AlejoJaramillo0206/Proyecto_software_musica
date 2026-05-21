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
        void Guardar(Roles rol);
        void Editar(Roles rol);
        void Eliminar(int id);
    }
}
