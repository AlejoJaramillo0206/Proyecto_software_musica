using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class InstrumentosCuerdasAplicacion : IInstrumentosCuerdasAplicacion
    {
        private readonly IConexion _conexion;

        public InstrumentosCuerdasAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<InstrumentosCuerdas> Obtener() =>
            _conexion.InstrumentosCuerdas!.ToList();

        public InstrumentosCuerdas Obtener(int id) =>
            _conexion.InstrumentosCuerdas!.First(i => i.Id == id);

        public InstrumentosCuerdas Guardar(InstrumentosCuerdas instrumento)
        {
            _conexion.InstrumentosCuerdas!.Add(instrumento);
            _conexion.SaveChanges();
            return instrumento;
        }

        public InstrumentosCuerdas Editar(InstrumentosCuerdas instrumento)
        {
            _conexion.InstrumentosCuerdas!.Update(instrumento);
            _conexion.SaveChanges();
            return instrumento;
        }

        public bool Eliminar(int id)
        {
            var instrumento = Obtener(id);
            _conexion.InstrumentosCuerdas!.Remove(instrumento);
            _conexion.SaveChanges();
            return true;
        }
    }
}
