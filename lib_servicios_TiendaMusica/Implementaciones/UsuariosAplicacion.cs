using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class UsuariosAplicacion : IUsuariosAplicacion
    {
        private readonly IConexion _conexion;

        public UsuariosAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<Usuarios> Obtener() =>
            _conexion.Usuarios!.ToList();

        public Usuarios Obtener(int id) =>
            _conexion.Usuarios!.First(u => u.Id == id);

     
        public Usuarios ObtenerPorUsername(string username) =>
            _conexion.Usuarios!.First(u => u.Username == username);

        public void Guardar(Usuarios usuario)
        {
          
            usuario.FechaCreacion = DateTime.Now;
            _conexion.Usuarios!.Add(usuario);
            _conexion.SaveChanges();
        }

        public void Editar(Usuarios usuario)
        {
            _conexion.Usuarios!.Update(usuario);
            _conexion.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var usuario = Obtener(id);
            _conexion.Usuarios!.Remove(usuario);
            _conexion.SaveChanges();
        }
    }
}
