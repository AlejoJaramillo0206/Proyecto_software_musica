using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages.Admin
{
    public class ReparacionesGarantiasModel : PageModel
    {
        public List<Reparaciones>? ListaReparaciones { get; set; }
        public List<Garantias>? ListaGarantias { get; set; }
        public string TabActivo { get; set; } = "reparaciones";

        public async Task<IActionResult> OnGetAsync(string? tab)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            if (HttpContext.Session.GetString("Rol") != "Administrador")
                return RedirectToPage("/Index");

            TabActivo = tab ?? "reparaciones";

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            ListaReparaciones = await com.Get<List<Reparaciones>>(
                "Reparaciones/Consultar");
            ListaGarantias = await com.Get<List<Garantias>>(
                "Garantias/Consultar");

            return Page();
        }
    }
}