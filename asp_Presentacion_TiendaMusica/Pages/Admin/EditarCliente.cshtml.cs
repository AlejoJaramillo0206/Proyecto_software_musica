using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages.Admin
{
    public class EditarClienteModel : PageModel
    {
        [BindProperty] public int Id { get; set; }
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

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            if (HttpContext.Session.GetString("Rol") != "Administrador")
                return RedirectToPage("/Index");

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());
            var cliente = await com.Get<Clientes>(
                $"Clientes/ConsultarPorId?id={id}");

            if (cliente == null)
                return RedirectToPage("/Admin/Clientes");

            Id = cliente.Id;
            Nombre = cliente.Nombre;
            Cedula = cliente.Cedula;
            Direccion = cliente.Direccion;
            Genero = cliente.Genero;
            Correo = cliente.Correo;
            FechaNacimiento = cliente.Fecha_Nacimiento;
            Profesion = cliente.Profesion;
            EsMusico = cliente.EsMusico;
            MarcaFav = cliente.MarcaFav;

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

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            var cliente = new Clientes
            {
                Id = Id,
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

            await com.Put<Clientes>("Clientes/Editar", cliente);

            return RedirectToPage("/Admin/Clientes", new { exito = "editado" });
        }
    }
}