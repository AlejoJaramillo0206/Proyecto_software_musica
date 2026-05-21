using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Interfaces
{
    public interface IDetalleFacturasAplicacion
    {
        List<DetalleFacturas> Obtener();
        List<DetalleFacturas> ObtenerPorFactura(int facturaId);
        void Guardar(DetalleFacturas detalle);
    }
}
