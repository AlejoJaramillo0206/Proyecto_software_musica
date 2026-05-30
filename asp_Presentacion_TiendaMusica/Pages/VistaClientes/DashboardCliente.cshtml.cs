using ClosedXML.Excel;
using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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

            var productos = await com.Get<List<object>>("Productos/Consultar");

            TotalProductos = productos?.Count ?? 0;


            ProductosDestacados = ProductosDestacados.Take(6).ToList();

            TotalCompras = int.Parse(
            HttpContext.Session.GetString("TotalCompras") ?? "0");
            TotalGarantias = 0;

            
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


        public async Task<IActionResult> OnGetDescargarReporteClienteAsync()
        {
            var usuarioIdStr = HttpContext.Session.GetString("UsuarioId");
            if (string.IsNullOrEmpty(usuarioIdStr)) return RedirectToPage("/Login");

            int idClienteActivo = Convert.ToInt32(usuarioIdStr);
            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            // Productos (Asegurados)
            var albumes = await com.Get<List<AlbumesRock>>("AlbumesRock/Consultar") ?? new();
            var accesorios = await com.Get<List<Accesorios>>("Accesorios/Consultar") ?? new();
            var instrumentos = await com.Get<List<InstrumentosCuerdas>>("InstrumentosCuerdas/Consultar") ?? new();

            // Facturas consumidas directamente desde la API del Administrador (que sí responde bien)
            var listaFacturas = await com.Get<List<Facturas>>("Facturas/Consultar") ?? new List<Facturas>();

            // Filtramos por el cliente actual
            var misFacturas = listaFacturas.Where(f => f.ClienteId == idClienteActivo).ToList();

            using (var workbook = new XLWorkbook())
            {
     
                var hojaProductos = workbook.Worksheets.Add("Catálogo Disponible");
                hojaProductos.Cell(1, 1).Value = "Código";
                hojaProductos.Cell(1, 2).Value = "Instrumento / Artículo";
                hojaProductos.Cell(1, 3).Value = "Precio";

                var cabeceraProd = hojaProductos.Range("A1:C1");
                cabeceraProd.Style.Font.Bold = true;
                cabeceraProd.Style.Fill.BackgroundColor = XLColor.FromHtml("#1A1208");
                cabeceraProd.Style.Font.FontColor = XLColor.FromHtml("#F0C040");

                int filaP = 2;
                foreach (var prod in albumes) { hojaProductos.Cell(filaP, 1).Value = prod.Id; hojaProductos.Cell(filaP, 2).Value = prod.Nombre; hojaProductos.Cell(filaP, 3).Value = prod.Precio; hojaProductos.Cell(filaP, 3).Style.NumberFormat.Format = "$#,##0.00"; filaP++; }
                foreach (var prod in accesorios) { hojaProductos.Cell(filaP, 1).Value = prod.Id; hojaProductos.Cell(filaP, 2).Value = prod.Nombre; hojaProductos.Cell(filaP, 3).Value = prod.Precio; hojaProductos.Cell(filaP, 3).Style.NumberFormat.Format = "$#,##0.00"; filaP++; }
                foreach (var prod in instrumentos) { hojaProductos.Cell(filaP, 1).Value = prod.Id; hojaProductos.Cell(filaP, 2).Value = prod.Nombre; hojaProductos.Cell(filaP, 3).Value = prod.Precio; hojaProductos.Cell(filaP, 3).Style.NumberFormat.Format = "$#,##0.00"; filaP++; }
                hojaProductos.Columns().AdjustToContents();

                var hojaCompras = workbook.Worksheets.Add("Mis Compras");
                hojaCompras.Cell(1, 1).Value = "N° Factura";
                hojaCompras.Cell(1, 2).Value = "Fecha de Emisión";
                hojaCompras.Cell(1, 3).Value = "Total Pagado";

                var cabeceraComp = hojaCompras.Range("A1:C1");
                cabeceraComp.Style.Font.Bold = true;
                cabeceraComp.Style.Fill.BackgroundColor = XLColor.FromHtml("#F0C040");
                cabeceraComp.Style.Font.FontColor = XLColor.FromHtml("#1A1208");

                int filaC = 2;
                foreach (var fac in misFacturas)
                {
                    hojaCompras.Cell(filaC, 1).Value = fac.Id;
                    hojaCompras.Cell(filaC, 2).Value = fac.Fecha.ToString("dd/MM/yyyy");
                    hojaCompras.Cell(filaC, 3).Value = fac.Total;
                    hojaCompras.Cell(filaC, 3).Style.NumberFormat.Format = "$#,##0.00";
                    filaC++;
                }
                hojaCompras.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Reporte_TiendaMusica_{idClienteActivo}.xlsx");
                }
            }
        }





        public IActionResult OnPostCerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Login");
        }
    }
}