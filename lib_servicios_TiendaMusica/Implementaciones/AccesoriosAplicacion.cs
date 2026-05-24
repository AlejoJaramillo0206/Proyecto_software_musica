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
            _conexion.Accesorios!.FirstOrDefault(c => c.Id == id)!;

        public Accesorios Guardar(Accesorios accesorio)
        {
            _conexion.Accesorios!.Add(accesorio);
            _conexion.SaveChanges();
            var auditoria = new AuditoriasAplicacion(_conexion);
            auditoria.Registrar("Accesorios", "Crear",
                $"Se creó accesorio {Accesorios.Tipo} con Id {Accesorios.Id}",
                null);
            return accesorio;
        }

        public Accesorios Editar(Accesorios accesorio)
        {
            _conexion.Accesorios!.Update(accesorio);
            _conexion.SaveChanges();
            var auditoria = new AuditoriasAplicacion(_conexion);
            auditoria.Registrar("Clientes", "Editar",
                $"Se editó el cliente {cliente.Nombre} con Id {cliente.Id}",
                null);
            return accesorio;
        }

        public bool Eliminar(int id)
        {
            var accesorio = Obtener(id);
            _conexion.Accesorios!.Remove(accesorio);
            _conexion.SaveChanges();
            var auditoria = new AuditoriasAplicacion(_conexion);
            auditoria.Registrar("Clientes", "Eliminar",
                $"Se eliminó el cliente con Id {id}",
                null);
            return true;
        }
    }
}
