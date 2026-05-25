using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages.Admin
{
    public class AgregarEmpleadoModel : PageModel
    {
        [BindProperty] public string? Nombre { get; set; }
        [BindProperty] public string? Cedula { get; set; }
        [BindProperty] public string? Direccion { get; set; }
        [BindProperty] public string? Genero { get; set; }
        [BindProperty] public string? Cargo { get; set; }
        [BindProperty] public DateTime FechaIngreso { get; set; }
        [BindProperty] public int ValorDia { get; set; }
        [BindProperty] public int DiasTrabajados { get; set; }
        [BindProperty] public string? NumeroBanco { get; set; }
        [BindProperty] public string? NumeroARL { get; set; }
        [BindProperty] public string? Username { get; set; }
        [BindProperty] public string? Password { get; set; }
        [BindProperty] public int RolId { get; set; }

        public List<Roles>? Roles { get; set; }
        public string? ErrorMensaje { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            if (HttpContext.Session.GetString("Rol") != "Administrador")
                return RedirectToPage("/Index");

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());
            Roles = await com.Get<List<Roles>>("Roles/Consultar");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            // Validaciones basicas
            if (string.IsNullOrEmpty(Nombre) ||
                string.IsNullOrEmpty(Cedula) ||
                string.IsNullOrEmpty(Username) ||
                string.IsNullOrEmpty(Password))
            {
                ErrorMensaje = "Nombre, cédula, usuario y contraseña son obligatorios.";
                var com2 = new Comunicaciones(Configuraciones.ObtenerUrlApi());
                Roles = await com2.Get<List<Roles>>("Roles/Consultar");
                return Page();
            }

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            // Verificar que el username no exista
            var usuarioExistente = await com.Get<Usuarios>(
                $"Usuarios/ConsultarPorUsername?username={Username}");

            if (usuarioExistente != null)
            {
                ErrorMensaje = "Ese nombre de usuario ya está en uso.";
                Roles = await com.Get<List<Roles>>("Roles/Consultar");
                return Page();
            }

            // 1. Crear Persona
            var persona = new Personas
            {
                Cedula = Cedula,
                Nombre = Nombre,
                Direccion = Direccion ?? "Sin definir",
                Genero = Genero ?? "Sin definir"
            };

            var personaCreada = await com.Post<Personas>("Personas/Guardar", persona);

            if (personaCreada == null)
            {
                ErrorMensaje = "Error al crear la persona. Intenta de nuevo.";
                Roles = await com.Get<List<Roles>>("Roles/Consultar");
                return Page();
            }

            // 2. Crear Empleado
            var empleado = new Empleados
            {
                Id = personaCreada.Id,
                Cargo = Cargo ?? "Sin definir",
                FechaIngreso = FechaIngreso,
                ValorDia = ValorDia,
                DiasTrabajados = DiasTrabajados,
                Numero_Banco = NumeroBanco ?? "Sin definir",
                Numero_ARL = NumeroARL ?? "Sin definir",
                Activo = true
            };

            await com.Post<Empleados>("Empleados/Guardar", empleado);

            // 3. Crear Usuario vinculado al empleado
            var usuario = new Usuarios
            {
                Username = Username,
                Password = Password,
                Activo = true,
                FechaCreacion = DateTime.Now,
                EmpleadoId = personaCreada.Id
            };

            var usuarioCreado = await com.Post<Usuarios>("Usuarios/Guardar", usuario);

            if (usuarioCreado == null)
            {
                ErrorMensaje = "Error al crear el usuario. Intenta de nuevo.";
                Roles = await com.Get<List<Roles>>("Roles/Consultar");
                return Page();
            }

            // 4. Asignar rol
            var usuarioRol = new UsuarioRoles
            {
                UsuarioId = usuarioCreado.Id,
                RolId = RolId
            };

            await com.Post<UsuarioRoles>("UsuarioRoles/Guardar", usuarioRol);

            // Redirigir al dashboard con exito
            return RedirectToPage("/Admin/Dashboard");
        }
    }
}