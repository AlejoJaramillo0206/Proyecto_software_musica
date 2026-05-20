using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class AccesoriosAplicacion : IAccesoriosAplicacion
    {
        private readonly IConexion _conexion;

        public AccesoriosAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<Accesorios> Obtener() =>
            _conexion.Accesorios!.ToList();

        public Accesorios Obtener(int id) =>
            _conexion.Accesorios!.First(a => a.Id == id);

        public void Guardar(Accesorios accesorio)
        {
            _conexion.Accesorios!.Add(accesorio);
            _conexion.SaveChanges();
        }

        public void Editar(Accesorios accesorio)
        {
            _conexion.Accesorios!.Update(accesorio);
            _conexion.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var accesorio = Obtener(id);
            _conexion.Accesorios!.Remove(accesorio);
            _conexion.SaveChanges();
        }
    }
}
