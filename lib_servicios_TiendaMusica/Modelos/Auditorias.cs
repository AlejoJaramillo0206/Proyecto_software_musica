using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Modelos
{
    public class Auditorias
    {
        public int Id { get; set; }
        public string? Entidad { get; set; }       
        public string? Accion { get; set; }        
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public int? UsuarioId { get; set; }      
        public Usuarios? _Usuario { get; set; }
    }
}
