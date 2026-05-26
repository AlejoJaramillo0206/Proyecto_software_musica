using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages.Admin
{
    public class ProveedoresModel : PageModel
    {
        public List<Proveedores>? Lista { get; set; }
        public string? MensajeExito { get; set; }

        public async Task<IActionResult> OnGetAsync(string? exito)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            if (HttpContext.Session.GetString("Rol") != "Administrador")
                return RedirectToPage("/Index");

            if (exito == "true")
                MensajeExito = "Proveedor eliminado correctamente.";
            else if (exito == "editado")
                MensajeExito = "Proveedor editado correctamente.";
            else if (exito == "agregado")
                MensajeExito = "Proveedor agregado correctamente.";

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());
            Lista = await com.Get<List<Proveedores>>("Proveedores/Consultar");

            return Page();
        }

        public async Task<IActionResult> OnPostEliminarAsync(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());
            await com.Delete($"Proveedores/Eliminar?id={id}");

            return RedirectToPage("/Admin/Proveedores", new { exito = "true" });
        }
    }
}