using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Interfaces
{
    public interface IReparacionesAplicacion
    {
        List<Reparaciones> Obtener();
        List<Reparaciones> ObtenerPorCliente(int clienteId);
        Reparaciones Obtener(int id);
        Reparaciones Guardar(Reparaciones reparacion);
    }
}
