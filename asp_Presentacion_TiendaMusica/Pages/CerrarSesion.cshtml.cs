using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages
{
    public class CerrarSesionModel : PageModel
    {
        public IActionResult OnGet()
        {
            
            HttpContext.Session.Clear();

           
            return RedirectToPage("/Pages/Login");
        }
    }
}