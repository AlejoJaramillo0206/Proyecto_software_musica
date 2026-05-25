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
        Bafles Guardar(Bafles bafle);
        Bafles Editar(Bafles bafle);
        bool Eliminar(int id);
    }
}
