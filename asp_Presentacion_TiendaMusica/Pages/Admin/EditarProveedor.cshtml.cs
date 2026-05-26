using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages.Admin
{
    public class EditarProveedorModel : PageModel
    {
        [BindProperty] public int Id { get; set; }
        [BindProperty] public string? Codigo { get; set; }
        [BindProperty] public string? Nombre_Empresa { get; set; }
        [BindProperty] public string? Telefono { get; set; }
        [BindProperty] public string? Correo { get; set; }

        public string? ErrorMensaje { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            if (HttpContext.Session.GetString("Rol") != "Administrador")
                return RedirectToPage("/Index");

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());
            var proveedor = await com.Get<Proveedores>(
                $"Proveedores/ConsultarPorId?id={id}");

            if (proveedor == null)
                return RedirectToPage("/Admin/Proveedores");

            Id = proveedor.Id;
            Codigo = proveedor.Codigo;
            Nombre_Empresa = proveedor.Nombre_Empresa;
            Telefono = proveedor.Telefono;
            Correo = proveedor.Correo;

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

            await com.Put<Proveedores>("Proveedores/Editar", new Proveedores
            {
                Id = Id,
                Codigo = Codigo,
                Nombre_Empresa = Nombre_Empresa,
                Telefono = Telefono ?? "Sin definir",
                Correo = Correo ?? "Sin definir"
            });

            return RedirectToPage("/Admin/Proveedores", new { exito = "editado" });
        }
    }
}