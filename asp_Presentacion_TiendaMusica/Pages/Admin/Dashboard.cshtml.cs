using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClosedXML.Excel;
using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;

namespace asp_Presentacion_TiendaMusica.Pages.Admin
{
    public class DashboardModel : PageModel
    {
        public int TotalProductos { get; set; }
        public int TotalClientes { get; set; }
        public int TotalFacturas { get; set; }
        public int TotalEmpleados { get; set; }
        public string? NombreAdmin { get; set; }

        // Listas auxiliares para poder cruzar los IDs con los nombres reales en el Excel
        public List<Clientes>? Clientes { get; set; }
        public List<Empleados>? Empleados { get; set; }

        [ResponseCache(NoStore = true, Duration = 0)]
        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            if (HttpContext.Session.GetString("Rol") != "Administrador")
                return RedirectToPage("/Index");

            NombreAdmin = HttpContext.Session.GetString("Username");

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            var productos = await com.Get<List<object>>("Productos/Consultar");
            var clientes = await com.Get<List<object>>("Clientes/Consultar");
            var facturas = await com.Get<List<object>>("Facturas/Consultar");
            var empleados = await com.Get<List<object>>("Empleados/Consultar");

            TotalProductos = productos?.Count ?? 0;
            TotalClientes = clientes?.Count ?? 0;
            TotalFacturas = facturas?.Count ?? 0;
            TotalEmpleados = empleados?.Count ?? 0;

            return Page();
        }

        // ==================================================
        // DESCARGA DIRECTA DESDE EL DASHBOARD
        // ==================================================
        public async Task<IActionResult> OnGetDescargarReporteAdminAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            if (HttpContext.Session.GetString("Rol") != "Administrador")
                return RedirectToPage("/Index");

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            // Cargamos los datos de la API
            var todasLasFacturas = await com.Get<List<Facturas>>("Facturas/Consultar") ?? new List<Facturas>();
            Clientes = await com.Get<List<Clientes>>("Clientes/Consultar") ?? new List<Clientes>();
            Empleados = await com.Get<List<Empleados>>("Empleados/Consultar") ?? new List<Empleados>();

            using (var workbook = new XLWorkbook())
            {
                var hoja = workbook.Worksheets.Add("Reporte General Ventas");

                // Cabeceras del Excel
                hoja.Cell(1, 1).Value = "N° Factura";
                hoja.Cell(1, 2).Value = "Código";
                hoja.Cell(1, 3).Value = "Fecha Emisión";
                hoja.Cell(1, 4).Value = "Cliente";
                hoja.Cell(1, 5).Value = "Atendido Por";
                hoja.Cell(1, 6).Value = "Total Venta";

                // Estilo elegante (Rojo oscuro y letras doradas)
                var cabecera = hoja.Range("A1:F1");
                cabecera.Style.Font.Bold = true;
                cabecera.Style.Fill.BackgroundColor = XLColor.FromHtml("#4A0E17");
                cabecera.Style.Font.FontColor = XLColor.FromHtml("#F0C040");

                int fila = 2;
                foreach (var fac in todasLasFacturas)
                {
                    hoja.Cell(fila, 1).Value = fac.Id;
                    hoja.Cell(fila, 2).Value = string.IsNullOrEmpty(fac.Codigo) ? "N/A" : fac.Codigo;
                    hoja.Cell(fila, 3).Value = fac.Fecha.ToString("dd/MM/yyyy");

                    // Cruzamos los datos para pintar los nombres en lugar de los IDs numéricos
                    hoja.Cell(fila, 4).Value = ObtenerNombreCliente(fac.ClienteId);
                    hoja.Cell(fila, 5).Value = ObtenerNombreEmpleado(fac.EmpleadoId);

                    hoja.Cell(fila, 6).Value = fac.Total;
                    hoja.Cell(fila, 6).Style.NumberFormat.Format = "$#,##0.00";

                    fila++;
                }

                hoja.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return File(
                        stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"Reporte_Global_Ventas_{DateTime.Now:yyyyMMdd}.xlsx"
                    );
                }
            }
        }

        // Métodos helper para buscar los nombres reales
        private string ObtenerNombreCliente(int clienteId) =>
            Clientes?.FirstOrDefault(c => c.Id == clienteId)?.Nombre ?? $"Cliente #{clienteId}";

        private string ObtenerNombreEmpleado(int empleadoId) =>
            Empleados?.FirstOrDefault(e => e.Id == empleadoId)?.Nombre ?? $"Empleado #{empleadoId}";
    }
}