
namespace lib_servicios_TiendaMusica.Modelos
{
    public class Empleados : Personas
    {
        public string? Numero_Banco { get; set; }
        public string? Numero_ARL { get; set; }
        public string? Cargo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Activo { get; set; }
        public int ValorDia { get; set; }
        public int DiasTrabajados { get; set; }
        public List<Facturas>? Facturas { get; set; }
        public List<Reparaciones>? _Reparaciones { get; set; }



    }
}
