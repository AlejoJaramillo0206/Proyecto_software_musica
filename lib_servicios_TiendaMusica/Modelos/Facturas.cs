
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_servicios_TiendaMusica.Modelos
{
    public class Facturas
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }

        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }



        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Clientes? _Cliente { get; set; }



        public int EmpleadoId { get; set; }
        [ForeignKey("EmpleadoId")]
        public Empleados? _Empleado { get; set; }


        public List<DetalleFacturas>? Detalles { get; set; }
        public List<Pagos>? pagos { get; set; }
        public List<Garantias>? Garantias { get; set; }
    }
}
