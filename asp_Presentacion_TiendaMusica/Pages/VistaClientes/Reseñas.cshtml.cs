using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages.VistaClientes
{
    public class ReseñasModel : PageModel
    {
        public List<Reseñas>? Lista { get; set; }

        [BindProperty] public int Calificacion { get; set; }
        [BindProperty] public string? Titulo { get; set; }
        [BindProperty] public string? Comentario { get; set; }

      


        public string? ErrorMensaje { get; set; }
        public string? ExitoMensaje { get; set; }

        public async Task<IActionResult> OnGetAsync(string? exito)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            if (exito == "true")
                ExitoMensaje = "¡Reseña publicada correctamente!";

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());
            Lista = await com.Get<List<Reseñas>>("Reseñas/Consultar");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            var clienteId = int.Parse(
                HttpContext.Session.GetString("ClienteId") ?? "0");

            if (clienteId == 0)
            {
                ErrorMensaje = "Debes completar tu perfil antes de dejar una reseña.";
                return Page();
            }

            if (string.IsNullOrEmpty(Titulo) || string.IsNullOrEmpty(Comentario))
            {
                ErrorMensaje = "Título y comentario son obligatorios.";
                return Page();
            }

            if (Calificacion < 1 || Calificacion > 5)
            {
                ErrorMensaje = "Selecciona una calificación entre 1 y 5 estrellas.";
                return Page();
            }

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

           
            var reseña = new Reseñas
            {
                Calificacion = Calificacion,
                Titulo = Titulo,
                Comentario = Comentario,
                FechaReseña = DateTime.Now,
                Verificada = false,
                ClienteId = clienteId,
                ProductoId = 1,
              
            };

            await com.Post<Reseñas>("Reseñas/Guardar", reseña);

            return RedirectToPage("/VistaClientes/Reseñas",
                new { exito = "true" });
        }
    }
}