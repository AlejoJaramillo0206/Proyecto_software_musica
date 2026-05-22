using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Interfaces
{
    public interface IClientesAplicacion
    {
        List<Clientes> Obtener();
        Clientes Obtener(int id);
        Clientes Guardar(Clientes cliente);
        Clientes Editar(Clientes cliente);
        bool Eliminar(int id);
    }
}
