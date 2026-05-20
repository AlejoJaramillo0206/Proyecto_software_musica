using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class AlbumesClasicosAplicacion : IAlbumesClasicosAplicacion
    {
        private readonly IConexion _conexion;

        public AlbumesClasicosAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<AlbumesClasicos> Obtener() =>
            _conexion.AlbumesClasicos!.ToList();

        public AlbumesClasicos Obtener(int id) =>
            _conexion.AlbumesClasicos!.First(a => a.Id == id);

        public void Guardar(AlbumesClasicos album)
        {
            _conexion.AlbumesClasicos!.Add(album);
            _conexion.SaveChanges();
        }

        public void Editar(AlbumesClasicos album)
        {
            _conexion.AlbumesClasicos!.Update(album);
            _conexion.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var album = Obtener(id);
            _conexion.AlbumesClasicos!.Remove(album);
            _conexion.SaveChanges();
        }
    }
}
