

namespace lib_servicios_TiendaMusica.Modelos
{
    public class DetalleFacturas
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }

        public decimal PrecioUnitario { get; set; }


        public int FacturaId { get; set; }
        public Facturas? _Factura { get; set; }


        public int ProductoId { get; set; }
        public Productos? _Producto { get; set; }

    }
}
