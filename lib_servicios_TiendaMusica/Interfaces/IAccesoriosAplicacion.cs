using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Interfaces
{
    public interface IAccesoriosAplicacion
    {
        List<Accesorios> Obtener();
        Accesorios Obtener(int id);
        void Guardar(Accesorios accesorio);
        void Editar(Accesorios accesorio);
        void Eliminar(int id);
    }
}
