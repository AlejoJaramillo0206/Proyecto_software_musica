using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Interfaces
{
    public interface IInstrumentosAireAplicacion
    {
        List<InstrumentosAire> Obtener();
        InstrumentosAire Obtener(int id);
        InstrumentosAire Guardar(InstrumentosAire instrumento);
        InstrumentosAire Editar(InstrumentosAire instrumento);
        bool Eliminar(int id);
    }
}
