using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using Microsoft.EntityFrameworkCore;
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
           _conexion.Clientes!.FirstOrDefault(c => c.Id == id)!;


        public Clientes Guardar(Clientes cliente)
        {
            _conexion.Database.ExecuteSqlRaw(
               "INSERT INTO Clientes (Id, Correo, Fecha_Nacimiento, Profesion, EsMusico, MarcaFav) " +
               "VALUES ({0}, {1}, {2}, {3}, {4}, {5})",
               cliente.Id,
               cliente.Correo ?? "Sin definir",
               cliente.Fecha_Nacimiento,
               cliente.Profesion ?? "Sin definir",
               cliente.EsMusico,
               cliente.MarcaFav ?? "Sin definir"
           );
            var auditoria = new AuditoriasAplicacion(_conexion);
            auditoria.Registrar("Clientes", "Crear",
                $"Se creó el cliente {cliente.Nombre} con Id {cliente.Id}",
                null);
            return cliente;
        }


        public Clientes Editar(Clientes cliente)
        {


   
            _conexion.Database.ExecuteSqlRaw(
                "UPDATE Personas SET Nombre={0}, Cedula={1}, Direccion={2}, Genero={3} WHERE Id={4}",
                cliente.Nombre ?? "",
                cliente.Cedula ?? "",
                cliente.Direccion ?? "",
                cliente.Genero ?? "",
                cliente.Id);

            
            _conexion.Database.ExecuteSqlRaw(
                "UPDATE Clientes SET Correo={0}, Fecha_Nacimiento={1}, Profesion={2}, EsMusico={3}, MarcaFav={4} WHERE Id={5}",
                cliente.Correo ?? "",
                cliente.Fecha_Nacimiento,
                cliente.Profesion ?? "",
                cliente.EsMusico,
                cliente.MarcaFav ?? "",
                cliente.Id);

            new AuditoriasAplicacion(_conexion).Registrar("Clientes", "Editar",
                $"Se editó el cliente {cliente.Nombre} con Id {cliente.Id}", null);

            return cliente;
        }

   
            public bool Eliminar(int id)
            {
                var usuario = _conexion.Usuarios!
                    .FirstOrDefault(u => u.EmpleadoId == null &&
                        _conexion.Clientes!.Any(c => c.Id == id));

                var cliente = Obtener(id);
                _conexion.Clientes!.Remove(cliente);
                _conexion.SaveChanges();

          
                var persona = _conexion.Personas!
                    .FirstOrDefault(p => p.Id == id);

                if (persona != null)
                {
                    _conexion.Personas!.Remove(persona);
                    _conexion.SaveChanges();
                }

                new AuditoriasAplicacion(_conexion).Registrar("Clientes", "Eliminar",
                    $"Se eliminó el cliente {cliente.Nombre}", null);

                return true;
        
            }
    }
}
