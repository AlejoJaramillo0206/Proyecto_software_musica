using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Interfaces
{
    public interface IBaflesAplicacion
    {
        List<Bafles> Obtener();
        Bafles Obtener(int id);
        Bafles Guardar(Bafles bafl);
        Bafles Editar(Bafles bafl);
        bool Eliminar(int id);
    }
}
