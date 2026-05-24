using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages
{
    public class RegistroModel : PageModel
    {
        [BindProperty] public string? Username { get; set; }
        [BindProperty] public string? Password { get; set; }
        [BindProperty] public string? ConfirmarPassword { get; set; }

        public string? ErrorMensaje { get; set; }
        public string? ExitoMensaje { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Username) ||
                string.IsNullOrEmpty(Password) ||
                string.IsNullOrEmpty(ConfirmarPassword))
            {
                ErrorMensaje = "Todos los campos son obligatorios.";
                return Page();
            }

            if (Password != ConfirmarPassword)
            {
                ErrorMensaje = "Las contraseñas no coinciden.";
                return Page();
            }

            if (Password.Length < 6)
            {
                ErrorMensaje = "La contraseña debe tener al menos 6 caracteres.";
                return Page();
            }

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            // Verificar que el username no exista
            var usuarioExistente = await com.Get<Usuarios>(
                $"Usuarios/ConsultarPorUsername?username={Username}");

            if (usuarioExistente != null)
            {
                ErrorMensaje = "Ese nombre de usuario ya está en uso.";
                return Page();
            }

            // 1. Crear la Persona base
            var nuevaPersona = new Personas
            {
                Cedula = "000000000",   // el cliente puede editarlo despues
                Nombre = Username,
                Direccion = "Sin definir",
                Genero = "Sin definir"
            };

            var personaCreada = await com.Post<Personas>("Personas/Guardar", nuevaPersona);

            if (personaCreada == null)
            {
                ErrorMensaje = "Error al crear el perfil. Intenta de nuevo.";
                return Page();
            }

            // 2. Crear el Cliente con el mismo Id de Persona
            var nuevoCliente = new Clientes
            {
                Id = personaCreada.Id,
                Correo = "Sin definir",
                Fecha_Nacimiento = DateTime.Now,
                Profesion = "Sin definir",
                EsMusico = false,
                MarcaFav = "Sin definir"
            };

            await com.Post<Clientes>("Clientes/Guardar", nuevoCliente);

            // 3. Crear el Usuario vinculado al Cliente
            var nuevoUsuario = new Usuarios
            {
                Username = Username,
                Password = Password,
                Activo = true,
                FechaCreacion = DateTime.Now,
                EmpleadoId = null
            };

            var usuarioCreado = await com.Post<Usuarios>("Usuarios/Guardar", nuevoUsuario);

            if (usuarioCreado == null)
            {
                ErrorMensaje = "Error al crear el usuario. Intenta de nuevo.";
                return Page();
            }

            // 4. Asignar rol Cliente (verifica el Id en tu BD)
            var usuarioRol = new UsuarioRoles
            {
                UsuarioId = usuarioCreado.Id,
                RolId = 5 // Cliente
            };

            await com.Post<UsuarioRoles>("UsuarioRoles/Guardar", usuarioRol);

            return RedirectToPage("/Login", new { exito = "true" });
        }
    }
}
