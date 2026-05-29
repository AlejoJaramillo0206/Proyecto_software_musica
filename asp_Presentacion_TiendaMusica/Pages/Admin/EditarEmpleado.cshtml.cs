using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages.Admin
{
    public class EditarEmpleadoModel : PageModel
    {
        [BindProperty] public int Id { get; set; }
        [BindProperty] public string? Nombre { get; set; }
        [BindProperty] public string? Cedula { get; set; }
        [BindProperty] public string? Direccion { get; set; }
        [BindProperty] public string? Genero { get; set; }
        [BindProperty] public string? Cargo { get; set; }
        [BindProperty] public DateTime FechaIngreso { get; set; }
        [BindProperty] public int ValorDia { get; set; }
        [BindProperty] public int DiasTrabajados { get; set; }
        [BindProperty] public string? NumeroBanco { get; set; }
        [BindProperty] public string? NumeroARL { get; set; }
        [BindProperty] public bool Activo { get; set; }

        public string? ErrorMensaje { get; set; }

        public string? ExitoMensaje { get; set; }

        public async Task<IActionResult> OnGetAsync(int id, string? exito)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            if (HttpContext.Session.GetString("Rol") != "Administrador")
                return RedirectToPage("/Index");

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());
            var empleado = await com.Get<Empleados>(
                $"Empleados/ConsultarPorId?id={id}");



            if (empleado == null)
                return RedirectToPage("/Admin/Empleados");

       
            Id = empleado.Id;
            Nombre = empleado.Nombre;
            Cedula = empleado.Cedula;
            Direccion = empleado.Direccion;
            Genero = empleado.Genero;
            Cargo = empleado.Cargo;
            FechaIngreso = empleado.FechaIngreso;
            ValorDia = empleado.ValorDia;
            DiasTrabajados = empleado.DiasTrabajados;
            NumeroBanco = empleado.Numero_Banco;
            NumeroARL = empleado.Numero_ARL;
            Activo = empleado.Activo;

           

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string? exito)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Cedula))
            {
                ErrorMensaje = "Nombre y cédula son obligatorios.";
                return Page();
            }



            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            var empleado = new Empleados
            {
                Id = Id,
                Nombre = Nombre,
                Cedula = Cedula,
                Direccion = Direccion ?? "Sin definir",
                Genero = Genero ?? "Sin definir",
                Cargo = Cargo ?? "Sin definir",
                FechaIngreso = FechaIngreso,
                ValorDia = ValorDia,
                DiasTrabajados = DiasTrabajados,
                Numero_Banco = NumeroBanco ?? "Sin definir",
                Numero_ARL = NumeroARL ?? "Sin definir",
                Activo = Activo
            };

            await com.Put<Empleados>("Empleados/Editar", empleado);

            return RedirectToPage("/Admin/Empleados", new { exito = "editado" });
        }
    }
}