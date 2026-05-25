using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class ReparacionesAplicacion : IReparacionesAplicacion
    {
        private readonly IConexion _conexion;

        public ReparacionesAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<Reparaciones> Obtener() =>
            _conexion.Reparaciones!.ToList();

        public List<Reparaciones> ObtenerPorCliente(int clienteId) =>
            _conexion.Reparaciones!.Where(r => r.ClienteId == clienteId).ToList();

        public Reparaciones Obtener(int id) =>
            _conexion.Reparaciones!.FirstOrDefault(r => r.Id == id)!;

        public Reparaciones Guardar(Reparaciones reparacion)
        {
            reparacion.FechaIngreso = DateTime.Now;
            _conexion.Reparaciones!.Add(reparacion);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("Reparaciones", "Crear",
                $"Se creó reparación para cliente Id {reparacion.ClienteId}", null);

            return reparacion;
        }
    }
}