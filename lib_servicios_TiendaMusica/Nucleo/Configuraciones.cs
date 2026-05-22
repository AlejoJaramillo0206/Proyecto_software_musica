

namespace lib_servicios_TiendaMusica.Nucleo
{
    public class Configuraciones
    {
        public static string obtener(string clave)
        {
            return "server=localhost;database=proyecto_TiendaMusica_Software;Integrated Security=True;TrustServerCertificate=true;";
        }
        public static string ObtenerUrlApi()
        {
            
            return "https://localhost:7207";
        }
    }
}
