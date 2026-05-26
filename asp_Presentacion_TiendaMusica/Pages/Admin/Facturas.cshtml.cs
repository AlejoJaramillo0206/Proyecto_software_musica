using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages.Admin
{
    public class FacturasModel : PageModel
    {
        public List<Facturas>? Lista { get; set; }
        public List<Clientes>? Clientes { get; set; }
        public List<Empleados>? Empleados { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            if (HttpContext.Session.GetString("Rol") != "Administrador")
                return RedirectToPage("/Index");

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            Lista = await com.Get<List<Facturas>>("Facturas/Consultar");
            Clientes = await com.Get<List<Clientes>>("Clientes/Consultar");
            Empleados = await com.Get<List<Empleados>>("Empleados/Consultar");

            return Page();
        }

        // Helpers
        public string ObtenerNombreCliente(int clienteId) =>
            Clientes?.FirstOrDefault(c => c.Id == clienteId)?.Nombre
            ?? $"Cliente #{clienteId}";

        public string ObtenerNombreEmpleado(int empleadoId) =>
            Empleados?.FirstOrDefault(e => e.Id == empleadoId)?.Nombre
            ?? $"Empleado #{empleadoId}";
    }
}