

namespace lib_servicios_TiendaMusica.Modelos
{
    public class AlbumesClasicos : Productos
    {
        public string? Compositor { get; set; }
        public string? Interprete { get; set; }
        public string? Orquesta { get; set; }
        public bool Grabaciones_en_vivo { get; set; }
        public string? Epoca_Musical { get; set; }


    }

}
