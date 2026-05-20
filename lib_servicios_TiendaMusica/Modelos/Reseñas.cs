using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Modelos
{
    public class Reseñas
    {
        public int Id { get; set; }
        public int Calificacion { get; set; }
        public string? Comentario { get; set; }
        public DateTime FechaReseña { get; set; }
        public bool Verificada { get; set; }
        public string? Titulo { get; set; }

        public int ClienteId { get; set; }
        public Clientes? _Cliente { get; set; }

        public int ProductoId { get; set; }
        public Productos? _Producto { get; set; }
    }
}
