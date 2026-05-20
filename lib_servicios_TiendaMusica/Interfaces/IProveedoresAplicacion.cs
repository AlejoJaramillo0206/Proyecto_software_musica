using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Interfaces
{
    public interface IProveedoresAplicacion
    {
        List<Proveedores> Obtener();
        Proveedores Obtener(int id);
        void Guardar(Proveedores proveedor);
        void Editar(Proveedores proveedor);
        void Eliminar(int id);
    }
}
