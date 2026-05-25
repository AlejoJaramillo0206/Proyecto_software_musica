using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class GarantiasAplicacion : IGarantiasAplicacion
    {
        private readonly IConexion _conexion;

        public GarantiasAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<Garantias> Obtener() =>
            _conexion.Garantias!.ToList();

        public List<Garantias> ObtenerPorCliente(int clienteId) =>
            _conexion.Garantias!.Where(g => g.ClienteId == clienteId).ToList();

        public Garantias Obtener(int id) =>
            _conexion.Garantias!.FirstOrDefault(g => g.Id == id)!;

        public Garantias Guardar(Garantias garantia)
        {
            _conexion.Garantias!.Add(garantia);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("Garantias", "Crear",
                $"Se creó garantía para producto Id {garantia.ProductoId}, cliente Id {garantia.ClienteId}", null);

            return garantia;
        }
    }
}