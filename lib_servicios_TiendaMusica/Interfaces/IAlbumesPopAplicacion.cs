using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Interfaces
{
    public interface IAlbumesPopAplicacion
    {
        List<AlbumesPop> Obtener();
        AlbumesPop Obtener(int id);
        AlbumesPop Guardar(AlbumesPop album);
        AlbumesPop Editar(AlbumesPop album);
        bool Eliminar(int id);
    }
}
