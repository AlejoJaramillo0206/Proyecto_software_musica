using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace asp_Presentacion_TiendaMusica.Pages.VistaClientes
{
    public class DashboardClienteModel : PageModel
    {
        public Usuarios? Cliente { get; set; }
        public List<Productos> ProductosDestacados { get; set; } = new();
        public int TotalProductos { get; set; }
        public int TotalCompras { get; set; }
        public int TotalFavoritos { get; set; }
        public int TotalGarantias { get; set; }
        public int CantidadCarrito { get; set; }

        public class ItemCarrito
        {
            public int IdProducto { get; set; }
            public string Nombre { get; set; } = string.Empty;
            public string Codigo { get; set; } = string.Empty;
            public decimal Precio { get; set; }
            public int Cantidad { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            int usuarioId = Convert.ToInt32(HttpContext.Session.GetString("UsuarioId"));

            Cliente = await com.Get<Usuarios>($"Usuarios/ConsultarId?id={usuarioId}");

            var albumes = await com.Get<List<AlbumesRock>>("AlbumesRock/Consultar");
            var accesorios = await com.Get<List<Accesorios>>("Accesorios/Consultar");
            var instrumentos = await com.Get<List<InstrumentosCuerdas>>("InstrumentosCuerdas/Consultar");

            if (albumes != null) ProductosDestacados.AddRange(albumes);
            if (accesorios != null) ProductosDestacados.AddRange(accesorios);
            if (instrumentos != null) ProductosDestacados.AddRange(instrumentos);

            // Corregido: Contamos todos los productos antes de recortar la lista para los destacados
            TotalProductos = ProductosDestacados.Count;

            // Tomamos solo 6 para mostrar en el Dashboard
            ProductosDestacados = ProductosDestacados.Take(6).ToList();

            TotalCompras = 0;
            TotalFavoritos = 0;
            TotalGarantias = 0;

            // Leer la cantidad del carrito para la burbuja flotante
            var cartJson = HttpContext.Session.GetString("Carrito");
            if (!string.IsNullOrEmpty(cartJson))
            {
                var carrito = JsonSerializer.Deserialize<List<ItemCarrito>>(cartJson);
                CantidadCarrito = carrito?.Sum(x => x.Cantidad) ?? 0;
            }

            return Page();
        }

        public IActionResult OnPostAgregarAlCarrito(int idProducto, string nombre, decimal precio, string codigo)
        {
            var cartJson = HttpContext.Session.GetString("Carrito");
            var carrito = string.IsNullOrEmpty(cartJson)
                ? new List<ItemCarrito>()
                : JsonSerializer.Deserialize<List<ItemCarrito>>(cartJson);

            var item = carrito.FirstOrDefault(c => c.IdProducto == idProducto);

            if (item != null)
            {
                item.Cantidad++;
            }
            else
            {
                carrito.Add(new ItemCarrito
                {
                    IdProducto = idProducto,
                    Nombre = nombre,
                    Precio = precio,
                    Codigo = codigo,
                    Cantidad = 1
                });
            }

            HttpContext.Session.SetString("Carrito", JsonSerializer.Serialize(carrito));

            return RedirectToPage();
        }

        public IActionResult OnPostCerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Login");
        }
    }
}