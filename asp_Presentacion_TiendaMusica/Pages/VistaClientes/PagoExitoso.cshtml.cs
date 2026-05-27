using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages.VistaClientes
{
    public class PagoExitosoModel : PageModel
    {
        public string? CodigoFactura { get; set; }
        public string? FacturaId { get; set; }

        public IActionResult OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            CodigoFactura = HttpContext.Session.GetString("UltimoCodigoFactura");
            FacturaId = HttpContext.Session.GetString("UltimaFactura");

            // Limpiar de sesion
            HttpContext.Session.Remove("UltimaFactura");
            HttpContext.Session.Remove("UltimoCodigoFactura");

            return Page();
        }
    }
}