

namespace lib_servicios_TiendaMusica.Modelos
{
    public class Proveedores
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre_Empresa { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }


        public List<Productos>? Productos { get; set; }
    }
}
