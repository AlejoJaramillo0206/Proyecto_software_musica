using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages.Admin
{
    public class AuditoriasModel : PageModel
    {
        public List<Auditorias>? Lista { get; set; }
        public string? FiltroEntidad { get; set; }
        public string? FiltroAccion { get; set; }

        public async Task<IActionResult> OnGetAsync(string? entidad, string? accion)
        {
            // Proteger la pagina
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            if (HttpContext.Session.GetString("Rol") != "Administrador")
                return RedirectToPage("/Index");

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            // Traer todas las auditorias
            Lista = await com.Get<List<Auditorias>>("Auditorias/Consultar");

            // Aplicar filtros si vienen en la URL
            if (!string.IsNullOrEmpty(entidad))
            {
                FiltroEntidad = entidad;
                Lista = Lista?.Where(a => a.Entidad == entidad).ToList();
            }

            if (!string.IsNullOrEmpty(accion))
            {
                FiltroAccion = accion;
                Lista = Lista?.Where(a => a.Accion == accion).ToList();
            }

            return Page();
        }
    }
}