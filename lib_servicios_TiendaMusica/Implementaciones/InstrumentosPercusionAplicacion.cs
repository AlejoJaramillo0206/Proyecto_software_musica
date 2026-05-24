using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class InstrumentosPercusionAplicacion : IInstrumentosPercusionAplicacion
    {
        private readonly IConexion _conexion;

        public InstrumentosPercusionAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<InstrumentosPercusion> Obtener() =>
            _conexion.InstrumentosPercusion!.ToList();

        public InstrumentosPercusion Obtener(int id) =>
           _conexion.InstrumentosPercusion!.FirstOrDefault(c => c.Id == id)!;
        public InstrumentosPercusion Guardar(InstrumentosPercusion instrumento)
        {
            _conexion.InstrumentosPercusion!.Add(instrumento);
            _conexion.SaveChanges();
            return instrumento;
        }

        public InstrumentosPercusion Editar(InstrumentosPercusion instrumento)
        {
            _conexion.InstrumentosPercusion!.Update(instrumento);
            _conexion.SaveChanges();
            return instrumento;
        }

        public bool Eliminar(int id)
        {
            var instrumento = Obtener(id);
            _conexion.InstrumentosPercusion!.Remove(instrumento);
            _conexion.SaveChanges();
            return true;
        }
    }
}
