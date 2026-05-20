

namespace lib_servicios_TiendaMusica.Modelos
{
    public class MetodosPago
    {
        public int Id { get; set; }
        public int NumCuotas { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }
        public List<Pagos>? pago { get; set; }
    }
}
