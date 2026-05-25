using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class FacturasAplicacion : IFacturasAplicacion
    {
        private readonly IConexion _conexion;

        public FacturasAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<Facturas> Obtener() =>
            _conexion.Facturas!.ToList();

        public Facturas Obtener(int id) =>
            _conexion.Facturas!.FirstOrDefault(f => f.Id == id)!;

        public Facturas Guardar(Facturas factura)
        {
            factura.Fecha = DateTime.Now;
            _conexion.Facturas!.Add(factura);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("Facturas", "Crear",
                $"Se creó la factura {factura.Codigo} con Id {factura.Id}", null);

            return factura;
        }
    }
}