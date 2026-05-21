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
            _conexion.MetodosPago!.First(m => m.Id == id);

        public void Guardar(MetodosPago metodoPago)
        {
            _conexion.MetodosPago!.Add(metodoPago);
            _conexion.SaveChanges();
        }

        public void Editar(MetodosPago metodoPago)
        {
            _conexion.MetodosPago!.Update(metodoPago);
            _conexion.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var metodoPago = Obtener(id);
            _conexion.MetodosPago!.Remove(metodoPago);
            _conexion.SaveChanges();
        }
    }
}
