using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace asp_Presentacion_TiendaMusica.Pages.VistaClientes
{
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class AlbumesModel : PageModel
    {
        public List<AlbumesClasicos> Clasicos { get; set; } = new();
        public List<AlbumesPop> Pop { get; set; } = new();
        public List<AlbumesReggaeton> Reggaeton { get; set; } = new();
        public List<AlbumesRock> Rock { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            // Evitar botón atrás si cerró sesión
            HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            HttpContext.Response.Headers["Pragma"] = "no-cache";
            HttpContext.Response.Headers["Expires"] = "0";

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            Clasicos = await com.Get<List<AlbumesClasicos>>("AlbumesClasicos/Consultar") ?? new();
            Pop = await com.Get<List<AlbumesPop>>("AlbumesPop/Consultar") ?? new();
            Reggaeton = await com.Get<List<AlbumesReggaeton>>("AlbumesReggaeton/Consultar") ?? new();
            Rock = await com.Get<List<AlbumesRock>>("AlbumesRock/Consultar") ?? new();

            return Page();
        }

        public IActionResult OnPostAgregarAlCarrito(int idProducto, string nombre, decimal precio, string codigo)
        {
            var cartJson = HttpContext.Session.GetString("Carrito");
            var carrito = string.IsNullOrEmpty(cartJson)
                ? new List<DashboardClienteModel.ItemCarrito>()
                : JsonSerializer.Deserialize<List<DashboardClienteModel.ItemCarrito>>(cartJson) ?? new();

            var item = carrito.FirstOrDefault(c => c.IdProducto == idProducto);
            if (item != null) item.Cantidad++;
            else
            {
                carrito.Add(new DashboardClienteModel.ItemCarrito { IdProducto = idProducto, Nombre = nombre, Precio = precio, Codigo = codigo, Cantidad = 1 });
            }
            HttpContext.Session.SetString("Carrito", JsonSerializer.Serialize(carrito));
            return RedirectToPage();
        }
    }
}