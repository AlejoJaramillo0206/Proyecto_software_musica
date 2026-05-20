

namespace lib_servicios_TiendaMusica.Modelos
{
    public class AlbumesPop : Productos
    {
        public int Cantidad_Canciones { get; set; }
        public string? Featuring { get; set; }
        public int Nominaciones { get; set; }
        public string? SelloDiscografico { get; set; }
        public int DuracionMinutos { get; set; }
    }
}
