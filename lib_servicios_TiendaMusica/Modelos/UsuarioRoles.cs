using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Modelos
{
    public class UsuarioRoles
    {
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuarios? _Usuario { get; set; }

        public int RolId { get; set; }
        [ForeignKey("RolId")]
        public Roles? _Rol { get; set; }
    }
}
