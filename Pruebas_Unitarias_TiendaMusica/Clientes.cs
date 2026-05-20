using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;

namespace Pruebas_Unitarias_TiendaMusica;

[TestClass]
public class Clientes
{
    [TestMethod]
    public void Ejecutar()
    {
        IConexion conexion = new Conexion();
        conexion.string_conexion = "server=localhost; database=proyecto_TiendaMusica_Software; Integrated Security=True;TrustServerCertificate=true;";
        var lista = conexion.Clientes!.ToList();
      
    }
}
