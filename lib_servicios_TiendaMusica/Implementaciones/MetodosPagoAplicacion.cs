using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class MetodosPagoAplicacion : IMetodosPagoAplicacion
    {
        private readonly IConexion _conexion;

        public MetodosPagoAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<MetodosPago> Obtener() =>
            _conexion.MetodosPago!.ToList();

        public MetodosPago Obtener(int id) =>
            _conexion.MetodosPago!.FirstOrDefault(m => m.Id == id)!;

        public MetodosPago Guardar(MetodosPago metodoPago)
        {
            _conexion.MetodosPago!.Add(metodoPago);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("MetodosPago", "Crear",
                $"Se creó el método de pago {metodoPago.Nombre} con Id {metodoPago.Id}", null);

            return metodoPago;
        }

        public MetodosPago Editar(MetodosPago metodoPago)
        {
            _conexion.MetodosPago!.Update(metodoPago);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("MetodosPago", "Editar",
                $"Se editó el método de pago {metodoPago.Nombre} con Id {metodoPago.Id}", null);

            return metodoPago;
        }

        public bool Eliminar(int id)
        {
            var metodoPago = Obtener(id);
            _conexion.MetodosPago!.Remove(metodoPago);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("MetodosPago", "Eliminar",
                $"Se eliminó el método de pago con Id {id}", null);

            return true;
        }
    }
}