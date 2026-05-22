using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Interfaces
{
    public interface IUsuariosAplicacion
    {
        List<Usuarios> Obtener();
        Usuarios Obtener(int id);
        Usuarios ObtenerPorUsername(string username);
        Usuarios Guardar(Usuarios usuario);
        Usuarios Editar(Usuarios usuario);
        bool Eliminar(int id);
    }
}
