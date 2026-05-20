

namespace lib_servicios_TiendaMusica.Modelos
{
    public class Inventarios
    {
        public int Id { get; set; }
        public int StockDisponible { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string? UbicacionBodega { get; set; }
        public int ProductoId { get; set; }
        public Productos? _Producto { get; set; }
    }
}
