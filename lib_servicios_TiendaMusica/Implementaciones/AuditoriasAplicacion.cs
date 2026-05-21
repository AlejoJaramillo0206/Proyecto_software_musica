using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class AuditoriasAplicacion : IAuditoriasAplicacion
    {
        private readonly IConexion _conexion;

        public AuditoriasAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<Auditorias> Obtener() =>
            _conexion.Auditorias!.ToList();

    
        public List<Auditorias> ObtenerPorEntidad(string entidad) =>
            _conexion.Auditorias!
                .Where(a => a.Entidad == entidad)
                .ToList();

        public List<Auditorias> ObtenerPorUsuario(int usuarioId) =>
            _conexion.Auditorias!
                .Where(a => a.UsuarioId == usuarioId)
                .ToList();

        public void Registrar(string entidad, string accion, string descripcion, int? usuarioId)
        {
            var auditoria = new Auditorias
            {
                Entidad = entidad,
                Accion = accion,
                Descripcion = descripcion,
                Fecha = DateTime.Now,
                UsuarioId = usuarioId
            };
            _conexion.Auditorias!.Add(auditoria);
            _conexion.SaveChanges();
        }
    }
}
