using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Interfaces
{
    public interface IFacturasAplicacion
    {
        List<Facturas> Obtener();
        Facturas Obtener(int id);
        void Guardar(Facturas factura);
    }
}
