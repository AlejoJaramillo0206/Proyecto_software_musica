using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Interfaces
{
    public interface IMetodosPagoAplicacion
    {
        List<MetodosPago> Obtener();
        MetodosPago Obtener(int id);
        void Guardar(MetodosPago metodoPago);
        void Editar(MetodosPago metodoPago);
        void Eliminar(int id);
    }
}
