

namespace lib_servicios_TiendaMusica.Modelos
{
    public abstract class Productos
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public decimal Precio { get; set; }
        public int ProveedorId { get; set; }

        public Proveedores? _Proveedor { get; set; }


        public List<DetalleFacturas>? Detalles { get; set; }
        public List<Inventarios>? Inventario { get; set; }
        public List<Garantias>? Garantia { get; set; }
        public List<Reseñas>? _Reseñas { get; set; }

    }
}
