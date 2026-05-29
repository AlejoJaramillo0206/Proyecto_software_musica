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

        [BindProperty(SupportsGet = true)]
        public string? exito { get; set; }

        public bool? EstaLogueado { get; set; }



        public void OnGet()
        {


        }





        public async Task<IActionResult> OnPostAsync()

        {
         

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                ErrorMensaje = "Debes ingresar usuario y contraseña.";
                return Page();
            }

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

          
            var usuario = await com.Get<Usuarios>(
                $"Usuarios/ConsultarPorUsername?username={Username}");

            if (usuario == null)
            {
                ErrorMensaje = "Usuario o contraseña incorrectos.";
                return Page();
            }

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

           
            var roles = await com.Get<List<UsuarioRoles>>(
                $"UsuarioRoles/ConsultarPorUsuario?usuarioId={usuario.Id}");
            var rol = roles?.FirstOrDefault();
            var nombreRol = rol != null
                ? (await com.Get<Roles>($"Roles/ConsultarPorId?id={rol.RolId}"))?.Nombre
                : "Vendedor";


            if (usuario.EmpleadoId == null)
            {
                var clientes = await com.Get<List<Clientes>>("Clientes/Consultar");
                var clienteLogin = clientes?.FirstOrDefault(c =>
                    c.Nombre != null &&
                    c.Nombre.ToLower() == usuario.Username!.ToLower());

                if (clienteLogin != null)
                    HttpContext.Session.SetString("ClienteId",
                        clienteLogin.Id.ToString());
               
                if (clienteLogin != null)
                {
                    HttpContext.Session.SetString("ClienteId", clienteLogin.Id.ToString());

                    if (clienteLogin.Cedula != "000000000" &&
                        clienteLogin.Profesion != "Sin definir" &&
                        clienteLogin.Correo != "Sin definir")
                    {
                        HttpContext.Session.SetString("PerfilCompleto", "true");
                    }
                }
            }



            HttpContext.Session.SetString("UsuarioId", usuario.Id.ToString());
            HttpContext.Session.SetString("Username", usuario.Username!);
            HttpContext.Session.SetString("Rol", nombreRol ?? "Vendedor");

            if (nombreRol == "Administrador")
                return RedirectToPage("/Admin/Dashboard");
            else
                return RedirectToPage("/VistaClientes/DashboardCliente");
        }
    }
}