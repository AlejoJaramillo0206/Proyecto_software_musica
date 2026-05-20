

using System.ComponentModel.DataAnnotations.Schema;

namespace lib_servicios_TiendaMusica.Modelos
{
    public class DetalleFacturas
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }

        public decimal PrecioUnitario { get; set; }

        public int FacturaId { get; set; }
        [ForeignKey("FacturaId")]
        public Facturas? _Factura { get; set; }



        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]
        public Productos? _Producto { get; set; }

    }
}
