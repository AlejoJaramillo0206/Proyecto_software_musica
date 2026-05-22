using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Interfaces
{
    public interface IAlbumesReggaetonAplicacion
    {
        List<AlbumesReggaeton> Obtener();
        AlbumesReggaeton Obtener(int id);
        AlbumesReggaeton Guardar(AlbumesReggaeton album);
        AlbumesReggaeton Editar(AlbumesReggaeton album);
        bool Eliminar(int id);
    }
}
