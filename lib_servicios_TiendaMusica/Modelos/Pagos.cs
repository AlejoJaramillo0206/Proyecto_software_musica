

using System.ComponentModel.DataAnnotations.Schema;

namespace lib_servicios_TiendaMusica.Modelos
{
    public class Pagos
    {
        public int Id { get; set; }
        public DateTime FechaPago { get; set; }

        public string? Estado { get; set; }
        public int FacturaId { get; set; }
        [ForeignKey("FacturaId")]
        public Facturas? _factura { get; set; }
        public int MetodoPagoId { get; set; }
        [ForeignKey("MetodoPagoId")]
        public MetodosPago? _MetodoPago { get; set; }
    }
}
