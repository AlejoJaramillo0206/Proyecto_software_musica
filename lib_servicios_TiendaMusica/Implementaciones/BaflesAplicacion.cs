using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class BaflesAplicacion : IBaflesAplicacion
    {
        private readonly IConexion _conexion;

        public BaflesAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<Bafles> Obtener() =>
            _conexion.Bafles!.ToList();

        public Bafles Obtener(int id) =>
            _conexion.Bafles!.First(b => b.Id == id);

        public Bafles Guardar(Bafles bafl)
        {
            _conexion.Bafles!.Add(bafl);
            _conexion.SaveChanges();
            return bafl;
        }

        public Bafles Editar(Bafles bafl)
        {
            _conexion.Bafles!.Update(bafl);
            _conexion.SaveChanges();
            return bafl;
        }

        public bool Eliminar(int id)
        {
            var bafl = Obtener(id);
            _conexion.Bafles!.Remove(bafl);
            _conexion.SaveChanges();
            return true;
        }
    }
}
