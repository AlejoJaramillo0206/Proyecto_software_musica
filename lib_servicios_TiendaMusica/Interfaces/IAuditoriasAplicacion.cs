using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Interfaces
{
    public interface IAuditoriasAplicacion
    {
        List<Auditorias> Obtener();
        List<Auditorias> ObtenerPorEntidad(string entidad);
        List<Auditorias> ObtenerPorUsuario(int usuarioId);
        void Registrar(string entidad, string accion, string descripcion, int? usuarioId);
    }

}
