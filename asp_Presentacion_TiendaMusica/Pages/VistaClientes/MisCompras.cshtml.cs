using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages.VistaClientes
{
    public class MisComprasModel : PageModel
    {
        public List<Facturas>? Lista { get; set; }
        public string? ErrorMensaje { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            var clienteId = int.Parse(
                HttpContext.Session.GetString("ClienteId") ?? "0");

            if (clienteId == 0)
            {
                ErrorMensaje = "Completa tu perfil para ver tus compras.";
                return Page();
            }

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            var todasFacturas = await com.Get<List<Facturas>>("Facturas/Consultar");

            Lista = todasFacturas?
                .Where(f => f.ClienteId == clienteId)
                .OrderByDescending(f => f.Fecha)
                .ToList();

            return Page();
        }
    }
}