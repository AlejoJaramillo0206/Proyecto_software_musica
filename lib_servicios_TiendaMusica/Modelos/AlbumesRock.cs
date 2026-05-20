
namespace lib_servicios_TiendaMusica.Modelos
{
    public class AlbumesRock : Productos
    {
        public string? Autor { get; set; }
        public int Año_Lanzamiento { get; set; }
        public string? Sello_Discografico { get; set; }
        public string? SubgeneroRock { get; set; }
        public bool EdicionRemaster { get; set; }
    }
}
