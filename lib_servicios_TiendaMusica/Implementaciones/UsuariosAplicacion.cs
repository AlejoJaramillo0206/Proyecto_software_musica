using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;

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
            _conexion.Usuarios!.FirstOrDefault(u => u.Id == id)!;

        public Usuarios ObtenerPorUsername(string username) =>
            _conexion.Usuarios!.FirstOrDefault(u => u.Username == username)!;

        public Usuarios Guardar(Usuarios usuario)
        {
            usuario.FechaCreacion = DateTime.Now;
            _conexion.Usuarios!.Add(usuario);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("Usuarios", "Crear",
                $"Se creó el usuario {usuario.Username} con Id {usuario.Id}", null);

            return usuario;
        }

        public Usuarios Editar(Usuarios usuario)
        {
            _conexion.Usuarios!.Update(usuario);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("Usuarios", "Editar",
                $"Se editó el usuario {usuario.Username} con Id {usuario.Id}", null);

            return usuario;
        }

        public bool Eliminar(int id)
        {
            var usuario = Obtener(id);
            _conexion.Usuarios!.Remove(usuario);
            _conexion.SaveChanges();

            new AuditoriasAplicacion(_conexion).Registrar("Usuarios", "Eliminar",
                $"Se eliminó el usuario con Id {id}", null);

            return true;
        }
    }
}