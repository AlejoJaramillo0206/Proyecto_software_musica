using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace asp_Presentacion_TiendaMusica.Pages.VistaClientes
{
    public class CarritoModel : PageModel
    {
        public class ItemCarrito
        {
            public int IdProducto { get; set; }
            public string Nombre { get; set; } = string.Empty;
            public string Codigo { get; set; } = string.Empty;
            public decimal Precio { get; set; }
            public int Cantidad { get; set; }
            public decimal Total => Precio * Cantidad;
        }

        public List<ItemCarrito> Carrito { get; set; } = new();
        public decimal TotalPagar { get; set; }

        public void OnGet()
        {
            CargarCarrito();
        }

        private void CargarCarrito()
        {
            var cartJson = HttpContext.Session.GetString("Carrito");
            if (!string.IsNullOrEmpty(cartJson))
            {
                Carrito = JsonSerializer.Deserialize<List<ItemCarrito>>(cartJson) ?? new();
                TotalPagar = Carrito.Sum(x => x.Total);
            }
        }

       
        public IActionResult OnPostIncrementar(int idProducto)
        {
            var cartJson = HttpContext.Session.GetString("Carrito");
            if (!string.IsNullOrEmpty(cartJson))
            {
                var carrito = JsonSerializer.Deserialize<List<ItemCarrito>>(cartJson) ?? new();
                var item = carrito.FirstOrDefault(x => x.IdProducto == idProducto);

                if (item != null)
                {
                    item.Cantidad++;
                }

                HttpContext.Session.SetString("Carrito", JsonSerializer.Serialize(carrito));
            }
            return RedirectToPage();
        }

       
        public IActionResult OnPostDecrementar(int idProducto)
        {
            var cartJson = HttpContext.Session.GetString("Carrito");
            if (!string.IsNullOrEmpty(cartJson))
            {
                var carrito = JsonSerializer.Deserialize<List<ItemCarrito>>(cartJson) ?? new();
                var item = carrito.FirstOrDefault(x => x.IdProducto == idProducto);

                if (item != null)
                {
                    item.Cantidad--;

                    // Si la cantidad llega a 0, eliminamos el producto automáticamente
                    if (item.Cantidad <= 0)
                    {
                        carrito.Remove(item);
                    }
                }

                HttpContext.Session.SetString("Carrito", JsonSerializer.Serialize(carrito));
            }
            return RedirectToPage();
        }

        public IActionResult OnPostEliminar(int idProducto)
        {
            var cartJson = HttpContext.Session.GetString("Carrito");
            if (!string.IsNullOrEmpty(cartJson))
            {
                var carrito = JsonSerializer.Deserialize<List<ItemCarrito>>(cartJson) ?? new();
                var item = carrito.FirstOrDefault(x => x.IdProducto == idProducto);

                if (item != null)
                {
                    carrito.Remove(item);
                }

                HttpContext.Session.SetString("Carrito", JsonSerializer.Serialize(carrito));
            }
            return RedirectToPage();
        }

        public IActionResult OnPostVaciar()
        {
            HttpContext.Session.Remove("Carrito");
            return RedirectToPage();
        }
    }
}