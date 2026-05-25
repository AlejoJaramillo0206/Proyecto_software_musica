using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages.Admin.Productos
{
    public class AgregarProductoModel : PageModel
    {
 
        [BindProperty] public string? Codigo { get; set; }
        [BindProperty] public string? Nombre { get; set; }
        [BindProperty] public decimal Precio { get; set; }
        [BindProperty] public int ProveedorId { get; set; }
        [BindProperty] public string? TipoProducto { get; set; }

      
        [BindProperty] public string? Compositor { get; set; }
        [BindProperty] public string? Interprete { get; set; }
        [BindProperty] public string? Orquesta { get; set; }
        [BindProperty] public bool GrabacionesEnVivo { get; set; }
        [BindProperty] public string? EpocaMusical { get; set; }

        [BindProperty] public int CantidadCanciones { get; set; }
        [BindProperty] public string? Featuring { get; set; }
        [BindProperty] public int Nominaciones { get; set; }
        [BindProperty] public string? SelloDiscografico { get; set; }
        [BindProperty] public int DuracionMinutos { get; set; }

       
        [BindProperty] public bool Explicito { get; set; }
        [BindProperty] public string? Idioma { get; set; }
        [BindProperty] public string? Productor { get; set; }
        [BindProperty] public string? ColabDestacadas { get; set; }
        [BindProperty] public string? EstiloReggaeton { get; set; }

       
        [BindProperty] public string? Autor { get; set; }
        [BindProperty] public short AñoLanzamiento { get; set; }
        [BindProperty] public string? SelloDiscograficoRock { get; set; }
        [BindProperty] public string? SubgeneroRock { get; set; }
        [BindProperty] public bool EdicionRemaster { get; set; }

        
        [BindProperty] public string? Marca { get; set; }
        [BindProperty] public string? Color { get; set; }
        [BindProperty] public string? Material { get; set; }
        [BindProperty] public int CantidadCuerdas { get; set; }
        [BindProperty] public bool IncluyeEstuche { get; set; }

        
        [BindProperty] public string? TipoAire { get; set; }
        [BindProperty] public short AñoFabricacion { get; set; }
        [BindProperty] public decimal Peso { get; set; }
        [BindProperty] public string? Afinacion { get; set; }
        [BindProperty] public string? MaterialBoquilla { get; set; }

      
        [BindProperty] public string? TipoPercusion { get; set; }
        [BindProperty] public string? Tamaño { get; set; }
        [BindProperty] public decimal PesoPercusion { get; set; }
        [BindProperty] public string? MaterialParche { get; set; }
        [BindProperty] public bool IncluyeBaquetas { get; set; }

       
        [BindProperty] public string? TamañoBafle { get; set; }
        [BindProperty] public int Decibeles { get; set; }
        [BindProperty] public string? MarcaBafle { get; set; }
        [BindProperty] public int PotenciaWatts { get; set; }
        [BindProperty] public bool Bluetooth { get; set; }

       
        [BindProperty] public string? TipoAccesorio { get; set; }
        [BindProperty] public string? ColorAccesorio { get; set; }
        [BindProperty] public string? TamañoAccesorio { get; set; }
        [BindProperty] public string? Compatibilidad { get; set; }
        [BindProperty] public string? HechoEn { get; set; }

        public List<Proveedores>? Proveedores { get; set; }
        public string? ErrorMensaje { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            if (HttpContext.Session.GetString("Rol") != "Administrador")
                return RedirectToPage("/Index");

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());
            Proveedores = await com.Get<List<Proveedores>>("Proveedores/Consultar");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Codigo)
                || string.IsNullOrEmpty(TipoProducto))
            {
                ErrorMensaje = "Código, nombre y tipo son obligatorios.";
                var com2 = new Comunicaciones(Configuraciones.ObtenerUrlApi());
                Proveedores = await com2.Get<List<Proveedores>>("Proveedores/Consultar");
                return Page();
            }

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            switch (TipoProducto)
            {
                case "AlbumesClasicos":
                    await com.Post<AlbumesClasicos>("AlbumesClasicos/Guardar",
                        new AlbumesClasicos
                        {
                            Codigo = Codigo,
                            Nombre = Nombre,
                            Precio = Precio,
                            ProveedorId = ProveedorId,
                            Compositor = Compositor ?? "",
                            Interprete = Interprete ?? "",
                            Orquesta = Orquesta ?? "",
                            Grabaciones_en_vivo = GrabacionesEnVivo,
                            Epoca_Musical = EpocaMusical ?? ""
                        });
                    break;

                case "AlbumesPop":
                    await com.Post<AlbumesPop>("AlbumesPop/Guardar",
                        new AlbumesPop
                        {
                            Codigo = Codigo,
                            Nombre = Nombre,
                            Precio = Precio,
                            ProveedorId = ProveedorId,
                            Cantidad_Canciones = CantidadCanciones,
                            Featuring = Featuring ?? "",
                            Nominaciones = Nominaciones,
                            SelloDiscografico = SelloDiscografico ?? "",
                            DuracionMinutos = DuracionMinutos
                        });
                    break;

                case "AlbumesReggaeton":
                    await com.Post<AlbumesReggaeton>("AlbumesReggaeton/Guardar",
                        new AlbumesReggaeton
                        {
                            Codigo = Codigo,
                            Nombre = Nombre,
                            Precio = Precio,
                            ProveedorId = ProveedorId,
                            Explicito = Explicito,
                            Idioma = Idioma ?? "",
                            Productor = Productor ?? "",
                            ColabDestacadas = ColabDestacadas ?? "",
                            EstiloReggaeton = EstiloReggaeton ?? ""
                        });
                    break;

                case "AlbumesRock":
                    await com.Post<AlbumesRock>("AlbumesRock/Guardar",
                        new AlbumesRock
                        {
                            Codigo = Codigo,
                            Nombre = Nombre,
                            Precio = Precio,
                            ProveedorId = ProveedorId,
                            Autor = Autor ?? "",
                            Año_Lanzamiento = AñoLanzamiento,
                            Sello_Discografico = SelloDiscograficoRock ?? "",
                            SubgeneroRock = SubgeneroRock ?? "",
                            EdicionRemaster = EdicionRemaster
                        });
                    break;

                case "InstrumentosCuerdas":
                    await com.Post<InstrumentosCuerdas>("InstrumentosCuerdas/Guardar",
                        new InstrumentosCuerdas
                        {
                            Codigo = Codigo,
                            Nombre = Nombre,
                            Precio = Precio,
                            ProveedorId = ProveedorId,
                            Marca = Marca ?? "",
                            Color = Color ?? "",
                            Material = Material ?? "",
                            CantidadCuerdas = CantidadCuerdas,
                            IncluyeEstuche = IncluyeEstuche
                        });
                    break;

                case "InstrumentosAire":
                    await com.Post<InstrumentosAire>("InstrumentosAire/Guardar",
                        new InstrumentosAire
                        {
                            Codigo = Codigo,
                            Nombre = Nombre,
                            Precio = Precio,
                            ProveedorId = ProveedorId,
                            Tipo = TipoAire ?? "",
                            Año_Fabricacion = AñoFabricacion,
                            Peso = Peso,
                            Afinacion = Afinacion ?? "",
                            MaterialBoquilla = MaterialBoquilla ?? ""
                        });
                    break;

                case "InstrumentosPercusion":
                    await com.Post<InstrumentosPercusion>("InstrumentosPercusion/Guardar",
                        new InstrumentosPercusion
                        {
                            Codigo = Codigo,
                            Nombre = Nombre,
                            Precio = Precio,
                            ProveedorId = ProveedorId,
                            Tipo = TipoPercusion ?? "",
                            Tamaño = Tamaño ?? "",
                            Peso = PesoPercusion,
                            MaterialParche = MaterialParche ?? "",
                            IncluyeBaquetas = IncluyeBaquetas
                        });
                    break;

                case "Bafles":
                    await com.Post<Bafles>("Bafles/Guardar",
                        new Bafles
                        {
                            Codigo = Codigo,
                            Nombre = Nombre,
                            Precio = Precio,
                            ProveedorId = ProveedorId,
                            Tamaño = TamañoBafle ?? "",
                            Decibeles = Decibeles,
                            Marca = MarcaBafle ?? "",
                            PotenciaWatts = PotenciaWatts,
                            Bluetooth = Bluetooth
                        });
                    break;

                case "Accesorios":
                    await com.Post<Accesorios>("Accesorios/Guardar",
                        new Accesorios
                        {
                            Codigo = Codigo,
                            Nombre = Nombre,
                            Precio = Precio,
                            ProveedorId = ProveedorId,
                            Tipo = TipoAccesorio ?? "",
                            Color = ColorAccesorio ?? "",
                            Tamaño = TamañoAccesorio ?? "",
                            Compatibilidad = Compatibilidad ?? "",
                            HechoEn = HechoEn ?? ""
                        });
                    break;
            }

            return RedirectToPage("/Admin/Productos",
                new { exito = "true" });
        }
    }
}