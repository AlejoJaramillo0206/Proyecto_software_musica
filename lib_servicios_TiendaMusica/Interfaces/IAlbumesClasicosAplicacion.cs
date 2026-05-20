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
        void Guardar(AlbumesClasicos album);
        void Editar(AlbumesClasicos album);
        void Eliminar(int id);
    }
}
