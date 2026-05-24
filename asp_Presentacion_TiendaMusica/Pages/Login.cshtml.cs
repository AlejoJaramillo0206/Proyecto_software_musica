using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string? Username { get; set; }

        [BindProperty]
        public string? Password { get; set; }

        public string? ErrorMensaje { get; set; }

        public void OnGet() { }
        [BindProperty(SupportsGet = true)]
        public string? exito { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                ErrorMensaje = "Debes ingresar usuario y contraseña.";
                return Page();
            }

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            // Buscar el usuario por username en el API
            var usuario = await com.Get<Usuarios>(
                $"Usuarios/ConsultarPorUsername?username={Username}");

            if (usuario == null)
            {
                ErrorMensaje = "Usuario o contraseña incorrectos.";
                return Page();
            }

            // Verificar contraseña (comparación simple por ahora,
            // luego implementamos BCrypt)
            if (usuario.Password != Password)
            {
                ErrorMensaje = "Usuario o contraseña incorrectos.";
                return Page();
            }

            if (!usuario.Activo)
            {
                ErrorMensaje = "Tu usuario está inactivo. Contacta al administrador.";
                return Page();
            }
           

            // Obtener los roles del usuario
            var roles = await com.Get<List<UsuarioRoles>>(
                $"UsuarioRoles/ConsultarPorUsuario?usuarioId={usuario.Id}");

            var rol = roles?.FirstOrDefault();
            var nombreRol = rol != null
                ? (await com.Get<Roles>($"Roles/ConsultarPorId?id={rol.RolId}"))?.Nombre
                : "Vendedor";


            // Guardar en sesión
            HttpContext.Session.SetString("UsuarioId", usuario.Id.ToString());
            HttpContext.Session.SetString("Username", usuario.Username!);
            HttpContext.Session.SetString("Rol", nombreRol ?? "Vendedor");

            if (nombreRol == "Administrador")
                return RedirectToPage("/Admin/Dashboard");
            else
                return RedirectToPage("/Index");

        }
    }
}
