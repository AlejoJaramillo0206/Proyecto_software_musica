using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages.VistaClientes
{
    public class ReparacionesModel : PageModel
    {
        public List<Reparaciones>? Lista { get; set; }
        public string? ErrorMensaje { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            var clienteId = int.Parse(
                HttpContext.Session.GetString("ClienteId") ?? "0");

            if (clienteId == 0)
            {
                ErrorMensaje = "Completa tu perfil para ver tus reparaciones.";
                return Page();
            }

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            var todas = await com.Get<List<Reparaciones>>("Reparaciones/Consultar");

            Lista = todas?
                .Where(r => r.ClienteId == clienteId)
                .OrderByDescending(r => r.FechaIngreso)
                .ToList();

            return Page();
        }
    }
}