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

         

        
            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM DetalleFacturas WHERE FacturaId IN (SELECT Id FROM Facturas WHERE ClienteId = {0})", id);

         
            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Pagos WHERE FacturaId IN (SELECT Id FROM Facturas WHERE ClienteId = {0})", id);

          
            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Garantias WHERE ClienteId = {0}", id);

            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Facturas WHERE ClienteId = {0}", id);

          
            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Reparaciones WHERE ClienteId = {0}", id);

         
            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Reseñas WHERE ClienteId = {0}", id);

       
            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM UsuarioRoles WHERE UsuarioId IN (SELECT Id FROM Usuarios WHERE EmpleadoId IS NULL AND Id = {0})", id);
            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Usuarios WHERE EmpleadoId IS NULL AND Id = {0}", id);

       
            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Clientes WHERE Id = {0}", id);

            _conexion.Database.ExecuteSqlRaw(
                "DELETE FROM Personas WHERE Id = {0}", id);

            new AuditoriasAplicacion(_conexion).Registrar("Clientes", "Eliminar",
                $"Se eliminó el cliente con Id {id}", null);

            return true;

        }
    }
}
