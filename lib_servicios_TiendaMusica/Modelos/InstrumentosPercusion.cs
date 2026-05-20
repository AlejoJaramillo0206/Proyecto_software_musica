

namespace lib_servicios_TiendaMusica.Modelos
{
    public class InstrumentosPercusion : Productos
    {
        public string? Tipo { get; set; }
        public string? Tamaño { get; set; }
        public decimal Peso { get; set; }
        public string? MaterialParche { get; set; }
        public bool IncluyeBaquetas { get; set; }
    }
}
