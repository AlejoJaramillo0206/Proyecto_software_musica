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
        void Guardar(Bafles bafl);
        void Editar(Bafles bafl);
        void Eliminar(int id);
    }
}
