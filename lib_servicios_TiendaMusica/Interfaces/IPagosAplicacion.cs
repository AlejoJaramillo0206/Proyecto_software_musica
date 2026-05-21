using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Interfaces
{
    public interface IPagosAplicacion
    {
        List<Pagos> Obtener();
        List<Pagos> ObtenerPorFactura(int facturaId);
        void Guardar(Pagos pago);
    }
}
