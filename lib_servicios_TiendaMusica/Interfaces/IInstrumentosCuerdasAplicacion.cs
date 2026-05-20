using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Interfaces
{
    public interface IInstrumentosCuerdasAplicacion
    {
        List<InstrumentosCuerdas> Obtener();
        InstrumentosCuerdas Obtener(int id);
        void Guardar(InstrumentosCuerdas instrumento);
        void Editar(InstrumentosCuerdas instrumento);
        void Eliminar(int id);
    }
}
