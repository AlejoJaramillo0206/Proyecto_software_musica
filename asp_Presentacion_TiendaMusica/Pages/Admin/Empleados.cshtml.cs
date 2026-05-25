using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages.Admin
{
    public class EmpleadosModel : PageModel
    {
        public List<Empleados>? Lista { get; set; }
        public string? MensajeExito { get; set; }
        public string? MensajeError { get; set; }

        public async Task<IActionResult> OnGetAsync(string? exito)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            if (HttpContext.Session.GetString("Rol") != "Administrador")
                return RedirectToPage("/Index");

            if (exito == "true")
                MensajeExito = "Empleado eliminado correctamente.";

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());
            Lista = await com.Get<List<Empleados>>("Empleados/Consultar");

            return Page();
        }

        public async Task<IActionResult> OnPostEliminarAsync(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());
            await com.Delete($"Empleados/Eliminar?id={id}");

            return RedirectToPage("/Admin/Empleados", new { exito = "true" });
        }
    }
}