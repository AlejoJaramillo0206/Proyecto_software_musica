
namespace lib_servicios_TiendaMusica.Modelos
{
    public class Clientes : Personas
    {
        public string? Correo { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string? Profesion { get; set; }
        public bool EsMusico { get; set; }
        public string? MarcaFav { get; set; }


        public List<Facturas>? Facturas { get; set; }
        public List<Garantias>? Garantias { get; set; }
        public List<Reparaciones>? _Reparaciones { get; set; }
        public List<Reseñas>? _Reseñas { get; set; }

    }
}
