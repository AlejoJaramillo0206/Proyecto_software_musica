using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class DetalleFacturasAplicacion : IDetalleFacturasAplicacion
    {
        private readonly IConexion _conexion;

        public DetalleFacturasAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<DetalleFacturas> Obtener() =>
            _conexion.DetalleFacturas!.ToList();

       
        public List<DetalleFacturas> ObtenerPorFactura(int facturaId) =>
            _conexion.DetalleFacturas!
                .Where(d => d.FacturaId == facturaId)
                .ToList();

       
        public void Guardar(DetalleFacturas detalle)
        {
            detalle.Subtotal = detalle.Cantidad * detalle.PrecioUnitario;
            _conexion.DetalleFacturas!.Add(detalle);
            _conexion.SaveChanges();
        }
    }
}
