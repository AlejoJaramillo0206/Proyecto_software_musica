

using System.ComponentModel.DataAnnotations.Schema;

namespace lib_servicios_TiendaMusica.Modelos
{
    public class Garantias
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string? Estado { get; set; }

        [Column("DescripcionDano")]
        public string? DescripcionDaño { get; set; }

        public int FacturaId { get; set; }
        [ForeignKey("FacturaId")]
        public Facturas? _Factura { get; set; }
        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]
        public Productos? _Producto { get; set; }
        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Clientes? _Cliente { get; set; }
    }
}
