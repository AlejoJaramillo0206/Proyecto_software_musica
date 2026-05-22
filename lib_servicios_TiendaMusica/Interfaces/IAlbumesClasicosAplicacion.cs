using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Interfaces
{
    public interface IAlbumesClasicosAplicacion
    {
        List<AlbumesClasicos> Obtener();
        AlbumesClasicos Obtener(int id);
        AlbumesClasicos Guardar(AlbumesClasicos album);
        AlbumesClasicos Editar(AlbumesClasicos album);
        bool Eliminar(int id);
    }
}
