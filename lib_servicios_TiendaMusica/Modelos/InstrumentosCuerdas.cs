
namespace lib_servicios_TiendaMusica.Modelos
{
    public class InstrumentosCuerdas : Productos
    {
        public string? Marca { get; set; }
        public string? Color { get; set; }
        public string? Material { get; set; }
        public int CantidadCuerdas { get; set; }
        public bool IncluyeEstuche { get; set; }
    }
}
