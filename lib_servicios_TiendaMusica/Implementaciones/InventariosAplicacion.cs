using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class InventariosAplicacion : IInventariosAplicacion
    {
        private readonly IConexion _conexion;

        public InventariosAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<Inventarios> Obtener() =>
            _conexion.Inventarios!.ToList();

        public Inventarios Obtener(int id) =>
           _conexion.Inventarios!.FirstOrDefault(c => c.Id == id)!;


        public Inventarios ObtenerPorProducto(int productoId) =>
            _conexion.Inventarios!.First(i => i.ProductoId == productoId);

        public Inventarios Guardar(Inventarios inventario)
        {
       
            inventario.FechaActualizacion = DateTime.Now;
            _conexion.Inventarios!.Add(inventario);
            _conexion.SaveChanges();
            return inventario;
        }

        public Inventarios Editar(Inventarios inventario)
        {
    
            inventario.FechaActualizacion = DateTime.Now;
            _conexion.Inventarios!.Update(inventario);
            _conexion.SaveChanges();
            return inventario;
        }

        public bool Eliminar(int id)
        {
            var inventario = Obtener(id);
            _conexion.Inventarios!.Remove(inventario);
            _conexion.SaveChanges();
            return true;
        }
    }
}
