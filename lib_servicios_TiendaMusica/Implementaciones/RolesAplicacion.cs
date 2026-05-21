using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class RolesAplicacion : IRolesAplicacion
    {
        private readonly IConexion _conexion;

        public RolesAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<Roles> Obtener() =>
            _conexion.Roles!.ToList();

        public Roles Obtener(int id) =>
            _conexion.Roles!.First(r => r.Id == id);

        public void Guardar(Roles rol)
        {
            _conexion.Roles!.Add(rol);
            _conexion.SaveChanges();
        }

        public void Editar(Roles rol)
        {
            _conexion.Roles!.Update(rol);
            _conexion.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var rol = Obtener(id);
            _conexion.Roles!.Remove(rol);
            _conexion.SaveChanges();
        }
    }
}
