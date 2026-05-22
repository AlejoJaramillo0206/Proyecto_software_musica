using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _conexion.Garantias!
                .Where(g => g.ClienteId == clienteId)
                .ToList();

        public Garantias Obtener(int id) =>
            _conexion.Garantias!.First(g => g.Id == id);

        public Garantias Guardar(Garantias garantia)
        {
            _conexion.Garantias!.Add(garantia);
            _conexion.SaveChanges();
            return garantia;
        }
    }
}
