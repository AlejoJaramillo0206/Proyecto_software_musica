using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class ReseñasAplicacion : IReseñasAplicacion
    {
        private readonly IConexion _conexion;

        public ReseñasAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<Reseñas> Obtener() =>
            _conexion.Reseñas!.ToList();

        // Util para mostrar las reseñas de un producto especifico
        public List<Reseñas> ObtenerPorProducto(int productoId) =>
            _conexion.Reseñas!
                .Where(r => r.ProductoId == productoId)
                .ToList();

        public Reseñas Obtener(int id) =>
            _conexion.Reseñas!.First(r => r.Id == id);

        public void Guardar(Reseñas reseña)
        {
            // La fecha se asigna automaticamente al momento de crear la reseña
            reseña.FechaReseña = DateTime.Now;
            _conexion.Reseñas!.Add(reseña);
            _conexion.SaveChanges();
        }
    }
}
