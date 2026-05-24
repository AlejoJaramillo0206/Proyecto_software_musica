using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class InstrumentosAireAplicacion : IInstrumentosAireAplicacion
    {
        private readonly IConexion _conexion;

        public InstrumentosAireAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<InstrumentosAire> Obtener() =>
            _conexion.InstrumentosAire!.ToList();

        public InstrumentosAire Obtener(int id) =>
            _conexion.InstrumentosAire!.FirstOrDefault(c => c.Id == id)!;

        public InstrumentosAire instrumento(InstrumentosAire instrumento)
        {
            _conexion.InstrumentosAire!.Add(instrumento);
            _conexion.SaveChanges();
            return instrumento;
        }

        public InstrumentosAire Editar(InstrumentosAire instrumento)
        {
            _conexion.InstrumentosAire!.Update(instrumento);
            _conexion.SaveChanges();
            return instrumento;
        }

        public bool Eliminar(int id)
        {
            var instrumento = Obtener(id);
            _conexion.InstrumentosAire!.Remove(instrumento);
            _conexion.SaveChanges();
            return true;
        }

        public InstrumentosAire Guardar(InstrumentosAire instrumento)
        {
            _conexion.InstrumentosAire!.Update(instrumento);
            _conexion.SaveChanges();
            return instrumento;
        }
    }
}
