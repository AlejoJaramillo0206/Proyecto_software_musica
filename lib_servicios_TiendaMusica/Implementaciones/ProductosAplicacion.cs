using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class ProductosAplicacion : IProductosAplicacion
    {
        private readonly IConexion _conexion;

        public ProductosAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<Productos> Obtener() =>
            _conexion.Productos!.ToList();

        public Productos Obtener(int id) =>
            _conexion.Productos!.First(p => p.Id == id);
    }
}
