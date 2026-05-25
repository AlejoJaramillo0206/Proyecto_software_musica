using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;

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

        public DetalleFacturas Guardar(DetalleFacturas detalle)
        {
            detalle.Subtotal = detalle.Cantidad * detalle.PrecioUnitario;
            _conexion.DetalleFacturas!.Add(detalle);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("DetalleFacturas", "Crear",
                $"Se agregó detalle a factura Id {detalle.FacturaId}, producto Id {detalle.ProductoId}", null);

            return detalle;
        }
    }
}