using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Interfaces
{
    public interface IInstrumentosPercusionAplicacion
    {
        List<InstrumentosPercusion> Obtener();
        InstrumentosPercusion Obtener(int id);
        InstrumentosPercusion Guardar(InstrumentosPercusion instrumento);
        InstrumentosPercusion Editar(InstrumentosPercusion instrumento);
        bool Eliminar(int id);
    }
}
