using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages.Admin
{
    public class AgregarProveedorModel : PageModel
    {
        [BindProperty] public string? Codigo { get; set; }
        [BindProperty] public string? Nombre_Empresa { get; set; }
        [BindProperty] public string? Telefono { get; set; }
        [BindProperty] public string? Correo { get; set; }

        public string? ErrorMensaje { get; set; }

        public IActionResult OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            if (HttpContext.Session.GetString("Rol") != "Administrador")
                return RedirectToPage("/Index");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            if (string.IsNullOrEmpty(Codigo) || string.IsNullOrEmpty(Nombre_Empresa))
            {
                ErrorMensaje = "Código y nombre de empresa son obligatorios.";
                return Page();
            }

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            await com.Post<Proveedores>("Proveedores/Guardar", new Proveedores
            {
                Codigo = Codigo,
                Nombre_Empresa = Nombre_Empresa,
                Telefono = Telefono ?? "Sin definir",
                Correo = Correo ?? "Sin definir"
            });

            return RedirectToPage("/Admin/Proveedores", new { exito = "agregado" });
        }
    }
}