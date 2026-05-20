

namespace lib_servicios_TiendaMusica.Modelos
{
    public class InstrumentosAire : Productos
    {
        public string? Tipo { get; set; }
        public int Año_Fabricacion { get; set; }
        public decimal Peso { get; set; }
        public string? Afinacion { get; set; }
        public string? MaterialBoquilla { get; set; }
    }
}
