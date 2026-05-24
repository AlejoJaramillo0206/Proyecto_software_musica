using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Implementaciones
{

        public class ProveedoresAplicacion : IProveedoresAplicacion
        {
            private readonly IConexion _conexion;

            public ProveedoresAplicacion(IConexion conexion)
            {
                _conexion = conexion;
            }

            public List<Proveedores> Obtener() =>
                _conexion.Proveedores!.ToList();

            public Proveedores Obtener(int id) =>
                _conexion.Proveedores!.FirstOrDefault(c => c.Id == id)!;

            public Proveedores Guardar(Proveedores proveedor)
            {
                _conexion.Proveedores!.Add(proveedor);
            _conexion.SaveChanges();
            return proveedor;
        }

        public Proveedores Editar(Proveedores proveedor)
            {
                _conexion.Proveedores!.Update(proveedor);
            _conexion.SaveChanges();
            return proveedor;
        }

        public bool Eliminar(int id)
            {
                var proveedor = Obtener(id);
                _conexion.Proveedores!.Remove(proveedor);
            _conexion.SaveChanges();
            return true;
        }
    }
}

