using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace asp_Presentacion_TiendaMusica.Pages.VistaClientes
{
    public class ProcesarPagoModel : PageModel
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
        public List<MetodosPago>? MetodosPago { get; set; }
        public decimal TotalPagar { get; set; }

        [BindProperty] public int MetodoPagoId { get; set; }

        public string? ErrorMensaje { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            CargarCarrito();

           
            if (!Carrito.Any())
                return RedirectToPage("/VistaClientes/Carrito");

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());
            MetodosPago = await com.Get<List<MetodosPago>>("MetodosPago/Consultar");
            MetodosPago = MetodosPago?.Where(m => m.Activo).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            CargarCarrito();

            if (!Carrito.Any())
                return RedirectToPage("/VistaClientes/Carrito");

            if (MetodoPagoId == 0)
            {
                ErrorMensaje = "Debes seleccionar un método de pago.";
                var com2 = new Comunicaciones(Configuraciones.ObtenerUrlApi());
                MetodosPago = await com2.Get<List<MetodosPago>>("MetodosPago/Consultar");
                MetodosPago = MetodosPago?.Where(m => m.Activo).ToList();
                return Page();
            }

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

           
            var usuarioId = int.Parse(
                HttpContext.Session.GetString("UsuarioId") ?? "0");

           
            var usuario = await com.Get<Usuarios>(
                $"Usuarios/ConsultarPorId?id={usuarioId}");

            if (usuario == null)
            {
                ErrorMensaje = "Error al obtener el usuario. Intenta de nuevo.";
                return Page();
            }

          
            var clientes = await com.Get<List<lib_servicios_TiendaMusica.Modelos.Clientes>>(
                "Clientes/Consultar");
            var cliente = clientes?.FirstOrDefault(c => c.Id == usuario.Id);

            if (cliente == null)
            {
                ErrorMensaje = "No se encontró el perfil de cliente. Completa tu perfil primero.";
                return Page();
            }

            // Buscar un empleado activo para asignar a la factura
            var empleados = await com.Get<List<Empleados>>("Empleados/Consultar");
            var empleado = empleados?.FirstOrDefault(e => e.Activo);

            if (empleado == null)
            {
                ErrorMensaje = "No hay empleados disponibles. Contacta al administrador.";
                return Page();
            }

           
            var codigo = $"FAC-{DateTime.Now:yyyyMMddHHmmss}";
            var factura = new Facturas
            {
                Codigo = codigo,
                Fecha = DateTime.Now,
                Total = TotalPagar,
                ClienteId = cliente.Id,
                EmpleadoId = empleado.Id
            };

            var facturaCreada = await com.Post<Facturas>("Facturas/Guardar", factura);

            if (facturaCreada == null)
            {
                ErrorMensaje = "Error al crear la factura. Intenta de nuevo.";
                return Page();
            }

           
            foreach (var item in Carrito)
            {
                var detalle = new DetalleFacturas
                {
                    FacturaId = facturaCreada.Id,
                    ProductoId = item.IdProducto,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = item.Precio,
                    Subtotal = item.Total
                };
                await com.Post<DetalleFacturas>("DetalleFacturas/Guardar", detalle);
            }

           
            var pago = new Pagos
            {
                FacturaId = facturaCreada.Id,
                MetodoPagoId = MetodoPagoId,
                FechaPago = DateTime.Now,
                Estado = "Pagado"
            };
            await com.Post<Pagos>("Pagos/Guardar", pago);


            var comprasActuales = int.Parse(
                HttpContext.Session.GetString("TotalCompras") ?? "0");
            HttpContext.Session.SetString("TotalCompras", (comprasActuales + 1).ToString());

            
            HttpContext.Session.Remove("Carrito");

   

           
            HttpContext.Session.SetString("UltimaFactura", facturaCreada.Id.ToString());
            HttpContext.Session.SetString("UltimoCodigoFactura", codigo);

            return RedirectToPage("/VistaClientes/PagoExitoso");
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
    }
}