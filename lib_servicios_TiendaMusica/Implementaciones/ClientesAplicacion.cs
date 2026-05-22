using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class ClientesAplicacion : IClientesAplicacion
    {
        private readonly IConexion _conexion;

        public ClientesAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }

        public List<Clientes> Obtener() =>
            _conexion.Clientes!.ToList();

       
        public Clientes Obtener(int id) =>
            _conexion.Clientes!.First(c => c.Id == id);

        
        public Clientes Guardar(Clientes cliente)
        {
            _conexion.Clientes!.Add(cliente);
            _conexion.SaveChanges();
            return cliente;
        }


        public Clientes Editar(Clientes cliente)
        {
            _conexion.Clientes!.Update(cliente);
            _conexion.SaveChanges();
            return cliente;
        }

        public bool Eliminar(int id)
        {
            var cliente = Obtener(id);
            _conexion.Clientes!.Remove(cliente);
            _conexion.SaveChanges();
            return true;
        }
    }
}
