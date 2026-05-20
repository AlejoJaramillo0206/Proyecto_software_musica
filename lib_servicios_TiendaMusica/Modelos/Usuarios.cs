using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Modelos
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }  
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }

        public int? EmpleadoId { get; set; }
        [ForeignKey("EmpleadoId")]
        public Empleados? _Empleado { get; set; }

        public List<UsuarioRoles>? UsuarioRoles { get; set; }
        public List<Auditorias>? Auditorias { get; set; }
    }
}
