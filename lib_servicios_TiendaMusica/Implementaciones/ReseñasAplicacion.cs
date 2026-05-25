using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;

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

        public List<Reseñas> ObtenerPorProducto(int productoId) =>
            _conexion.Reseñas!.Where(r => r.ProductoId == productoId).ToList();

        public Reseñas Obtener(int id) =>
            _conexion.Reseñas!.FirstOrDefault(r => r.Id == id)!;

        public Reseñas Guardar(Reseñas reseña)
        {
            reseña.FechaReseña = DateTime.Now;
            _conexion.Reseñas!.Add(reseña);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("Reseñas", "Crear",
                $"Se creó reseña para producto Id {reseña.ProductoId}, cliente Id {reseña.ClienteId}", null);

            return reseña;
        }
    }
}