using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Modelos
{
    public class UsuarioRoles
    {
        public int UsuarioId { get; set; }
        public Usuarios? _Usuario { get; set; }

        public int RolId { get; set; }
        public Roles? _Rol { get; set; }
    }
}
