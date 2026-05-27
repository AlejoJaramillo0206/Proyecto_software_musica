using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace asp_Presentacion_TiendaMusica.Pages.VistaClientes
{
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class InstrumentosModel : PageModel
    {
        public List<InstrumentosCuerdas> Cuerdas { get; set; } = new();
        public List<InstrumentosAire> Aire { get; set; } = new();
        public List<InstrumentosPercusion> Percusion { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            Cuerdas = await com.Get<List<InstrumentosCuerdas>>("InstrumentosCuerdas/Consultar") ?? new();
            Aire = await com.Get<List<InstrumentosAire>>("InstrumentosAire/Consultar") ?? new();
            Percusion = await com.Get<List<InstrumentosPercusion>>("InstrumentosPercusion/Consultar") ?? new();

            return Page();
        }

        public IActionResult OnPostAgregarAlCarrito(int idProducto, string nombre, decimal precio, string codigo)
        {
            var cartJson = HttpContext.Session.GetString("Carrito");
            var carrito = string.IsNullOrEmpty(cartJson) ? new List<DashboardClienteModel.ItemCarrito>() : JsonSerializer.Deserialize<List<DashboardClienteModel.ItemCarrito>>(cartJson) ?? new();

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