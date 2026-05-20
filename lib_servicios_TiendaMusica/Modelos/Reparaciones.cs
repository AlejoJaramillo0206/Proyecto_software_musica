using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Modelos
{
    public class Reparaciones
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal Costo { get; set; }
        public string? Estado { get; set; }

        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Clientes? _Cliente { get; set; }

        public int EmpleadoId { get; set; }
        [ForeignKey("EmpleadoId")]
        public Empleados? _Empleado { get; set; }

        public int? ProductoId { get; set; }
        [ForeignKey("ProductoId")]
        public Productos? _Producto { get; set; }

    }
}
