
namespace lib_servicios_TiendaMusica.Modelos
{
    public class Bafles : Productos
    {
        public string? Tamaño { get; set; }
        public int Decibeles { get; set; }
        public string? Marca { get; set; }
        public int PotenciaWatts { get; set; }
        public bool Bluetooth { get; set; }
    }
}
