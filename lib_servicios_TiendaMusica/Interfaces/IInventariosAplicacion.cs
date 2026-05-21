using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Interfaces
{
    public interface IInventariosAplicacion
    {
        List<Inventarios> Obtener();
        Inventarios Obtener(int id);
        Inventarios ObtenerPorProducto(int productoId);
        void Guardar(Inventarios inventario);
        void Editar(Inventarios inventario);
        void Eliminar(int id);
    }
}
