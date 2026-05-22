using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _conexion.Facturas!.First(f => f.Id == id);

        // Al guardar una factura se registra la fecha automaticamente
        public Facturas Guardar(Facturas factura)
        {
            factura.Fecha = DateTime.Now;
            _conexion.Facturas!.Add(factura);
            _conexion.SaveChanges();
            return factura;
        }
    }
}
