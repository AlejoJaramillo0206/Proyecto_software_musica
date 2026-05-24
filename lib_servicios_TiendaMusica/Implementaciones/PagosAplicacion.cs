using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class PagosAplicacion : IPagosAplicacion
    {
        private readonly IConexion _conexion;

        public PagosAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<Pagos> Obtener() =>
            _conexion.Pagos!.ToList();

       
        public List<Pagos> ObtenerPorFactura(int facturaId) =>
            _conexion.Pagos!
                .Where(p => p.FacturaId == facturaId)
                .ToList();

       
        public Pagos Guardar(Pagos pago)
        {
            pago.FechaPago = DateTime.Now;
            _conexion.Pagos!.Add(pago);
            _conexion.SaveChanges();
            return pago;
        }
    }
}
