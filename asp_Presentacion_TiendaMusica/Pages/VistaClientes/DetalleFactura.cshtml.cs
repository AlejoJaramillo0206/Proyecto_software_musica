using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages.VistaClientes
{
    public class DetalleFacturaModel : PageModel
    {
        public Facturas? Factura { get; set; }
        public List<DetalleFacturas>? Detalles { get; set; }
        public List<Pagos>? Pagos { get; set; }
        public List<lib_servicios_TiendaMusica.Modelos.Productos>? Productos { get; set; }
        public Clientes? Cliente { get; set; }
        public Empleados? Empleado { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

           
            if (HttpContext.Session.GetString("Rol") != "Cliente")
                return RedirectToPage("/Index");

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            Factura = await com.Get<Facturas>($"Facturas/ConsultarPorId?id={id}");
            if (Factura == null)
                return RedirectToPage("/VistaClientes/MisCompras");

            
            var usuarioId = int.Parse(HttpContext.Session.GetString("UsuarioId") ?? "0");
            var clientes = await com.Get<List<Clientes>>("Clientes/Consultar");
            var clienteActual = clientes?.FirstOrDefault(c => c.Id == usuarioId);
            if (clienteActual == null || Factura.ClienteId != clienteActual.Id)
                return RedirectToPage("/VistaClientes/MisCompras");

            Detalles = await com.Get<List<DetalleFacturas>>(
                $"DetalleFacturas/ConsultarPorFactura?facturaId={id}");
            Pagos = await com.Get<List<Pagos>>(
                $"Pagos/ConsultarPorFactura?facturaId={id}");
            Productos = await com.Get<List<lib_servicios_TiendaMusica.Modelos.Productos>>("Productos/Consultar");
            Cliente = await com.Get<Clientes>(
                $"Clientes/ConsultarPorId?id={Factura.ClienteId}");
            Empleado = await com.Get<Empleados>(
                $"Empleados/ConsultarPorId?id={Factura.EmpleadoId}");

            return Page();
        }

        public string ObtenerNombreProducto(int productoId) =>
            Productos?.FirstOrDefault(p => p.Id == productoId)?.Nombre
            ?? $"Producto #{productoId}";
    }
}