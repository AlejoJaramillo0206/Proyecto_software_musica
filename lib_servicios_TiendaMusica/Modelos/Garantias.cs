

namespace lib_servicios_TiendaMusica.Modelos
{
    public class Garantias
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string? Estado { get; set; }
        public string? DescripcionDaño { get; set; }
        public int FacturaId { get; set; }
        public Facturas? _Factura { get; set; }
        public int ProductoId { get; set; }
        public Productos? _Producto { get; set; }
        public int ClienteId { get; set; }
        public Clientes? _Cliente { get; set; }
    }
}
