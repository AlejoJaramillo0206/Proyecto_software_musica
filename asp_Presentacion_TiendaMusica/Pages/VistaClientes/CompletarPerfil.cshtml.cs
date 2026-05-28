using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages.VistaClientes
{
    public class CompletarPerfilModel : PageModel
    {
        [BindProperty] public string? Nombre { get; set; }
        [BindProperty] public string? Cedula { get; set; }
        [BindProperty] public string? Direccion { get; set; }
        [BindProperty] public string? Genero { get; set; }
        [BindProperty] public string? Correo { get; set; }
        [BindProperty] public DateTime FechaNacimiento { get; set; }
        [BindProperty] public string? Profesion { get; set; }
        [BindProperty] public bool EsMusico { get; set; }
        [BindProperty] public string? MarcaFav { get; set; }

        public string? ErrorMensaje { get; set; }
        public string? ExitoMensaje { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            var clienteId = int.Parse(
                HttpContext.Session.GetString("ClienteId") ?? "0");

            if (clienteId == 0)
            {
                ErrorMensaje = "No se encontró tu perfil de cliente.";
                return Page();
            }

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());
            var cliente = await com.Get<lib_servicios_TiendaMusica.Modelos.Clientes>(
                $"Clientes/ConsultarPorId?id={clienteId}");

            if (cliente != null)
            {
                Nombre = cliente.Nombre;
                Cedula = cliente.Cedula;
                Direccion = cliente.Direccion;
                Genero = cliente.Genero;
                Correo = cliente.Correo;
                FechaNacimiento = cliente.Fecha_Nacimiento;
                Profesion = cliente.Profesion;
                EsMusico = cliente.EsMusico;
                MarcaFav = cliente.MarcaFav;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Cedula))
            {
                ErrorMensaje = "Nombre y cédula son obligatorios.";
                return Page();
            }

            var clienteId = int.Parse(
                HttpContext.Session.GetString("ClienteId") ?? "0");

            if (clienteId == 0)
            {
                ErrorMensaje = "No se encontró tu perfil de cliente.";
                return Page();
            }

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            var cliente = new lib_servicios_TiendaMusica.Modelos.Clientes
            {
                Id = clienteId,
                Nombre = Nombre,
                Cedula = Cedula,
                Direccion = Direccion ?? "Sin definir",
                Genero = Genero ?? "Sin definir",
                Correo = Correo ?? "Sin definir",
                Fecha_Nacimiento = FechaNacimiento,
                Profesion = Profesion ?? "Sin definir",
                EsMusico = EsMusico,
                MarcaFav = MarcaFav ?? "Sin definir"
            };

            await com.Put<lib_servicios_TiendaMusica.Modelos.Clientes>(
                "Clientes/Editar", cliente);
         
            HttpContext.Session.SetString("PerfilCompleto", "true");
            ExitoMensaje = "Perfil actualizado correctamente.";
            return Page();
        }
    }
}