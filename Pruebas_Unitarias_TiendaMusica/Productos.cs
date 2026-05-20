using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;

namespace Pruebas_Unitarias_TiendaMusica;

[TestClass]
public class Productos
{
    [TestMethod]
    public void Ejecutar()
    {
        IConexion conexion = new Conexion();
        conexion.string_conexion = "server=localhost;Integrated Security=True;TrustServerCertificate=true;database=proyecto_TiendaMusica_Software;";
        var lista = conexion.Productos!.ToList();
   
    }
}
