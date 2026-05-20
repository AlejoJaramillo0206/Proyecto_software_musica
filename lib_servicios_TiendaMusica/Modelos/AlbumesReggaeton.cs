

namespace lib_servicios_TiendaMusica.Modelos
{
    public class AlbumesReggaeton : Productos
    {
        public bool Explicito { get; set; }
        public string? Idioma { get; set; }
        public string? Productor { get; set; }
        public string? ColabDestacadas { get; set; }
        public string? EstiloReggaeton { get; set; }
    }
}
