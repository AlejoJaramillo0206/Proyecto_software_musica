using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // Util para ver el historial de reparaciones de un cliente
        public List<Reparaciones> ObtenerPorCliente(int clienteId) =>
            _conexion.Reparaciones!
                .Where(r => r.ClienteId == clienteId)
                .ToList();

        public Reparaciones Obtener(int id) =>
            _conexion.Reparaciones!.First(r => r.Id == id);

        public Reparaciones Guardar(Reparaciones reparacion)
        {
            // La fecha de ingreso se asigna automaticamente
            reparacion.FechaIngreso = DateTime.Now;
            _conexion.Reparaciones!.Add(reparacion);
            _conexion.SaveChanges();
            return reparacion;
        }
    }
}
