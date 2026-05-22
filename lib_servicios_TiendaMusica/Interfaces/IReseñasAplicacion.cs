using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Interfaces
{
    public interface IReseñasAplicacion
    {
        List<Reseñas> Obtener();
        List<Reseñas> ObtenerPorProducto(int productoId);
        Reseñas Obtener(int id);
        Reseñas Guardar(Reseñas reseña);
    }
}
