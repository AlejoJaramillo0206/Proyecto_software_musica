using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages.Admin
{
    public class DashboardModel : PageModel
    {

        public int TotalProductos { get; set; }
        public int TotalClientes { get; set; }
        public int TotalFacturas { get; set; }
        public int TotalEmpleados { get; set; }

   
        public string? NombreAdmin { get; set; }


        [ResponseCache(NoStore = true, Duration = 0)]
        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            if (HttpContext.Session.GetString("Rol") != "Administrador")
                return RedirectToPage("/Index");

            NombreAdmin = HttpContext.Session.GetString("Username");

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            
            var productos = await com.Get<List<object>>("Productos/Consultar");
            var clientes = await com.Get<List<object>>("Clientes/Consultar");
            var facturas = await com.Get<List<object>>("Facturas/Consultar");
            var empleados = await com.Get<List<object>>("Empleados/Consultar");

            TotalProductos = productos?.Count ?? 0;
            TotalClientes = clientes?.Count ?? 0;
            TotalFacturas = facturas?.Count ?? 0;
            TotalEmpleados = empleados?.Count ?? 0;

            return Page();
        }
    }
}