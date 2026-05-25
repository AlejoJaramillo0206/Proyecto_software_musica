using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages.Admin.Productos
{
    public class EditarProductoModel : PageModel
    {
        [BindProperty] public int Id { get; set; }
        [BindProperty] public string? Codigo { get; set; }
        [BindProperty] public string? Nombre { get; set; }
        [BindProperty] public decimal Precio { get; set; }
        [BindProperty] public int ProveedorId { get; set; }
        public string? TipoProducto { get; set; }

        
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

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            if (HttpContext.Session.GetString("Rol") != "Administrador")
                return RedirectToPage("/Index");

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());
            Proveedores = await com.Get<List<Proveedores>>("Proveedores/Consultar");

            // Detectar el tipo consultando cada subtipo
            Id = id;

            var clasico = await com.Get<AlbumesClasicos>(
                $"AlbumesClasicos/ConsultarPorId?id={id}");
            if (clasico != null)
            {
                TipoProducto = "AlbumesClasicos";
                Codigo = clasico.Codigo; Nombre = clasico.Nombre;
                Precio = clasico.Precio; ProveedorId = clasico.ProveedorId;
                Compositor = clasico.Compositor; Interprete = clasico.Interprete;
                Orquesta = clasico.Orquesta;
                GrabacionesEnVivo = clasico.Grabaciones_en_vivo;
                EpocaMusical = clasico.Epoca_Musical;
                return Page();
            }

            var pop = await com.Get<AlbumesPop>(
                $"AlbumesPop/ConsultarPorId?id={id}");
            if (pop != null)
            {
                TipoProducto = "AlbumesPop";
                Codigo = pop.Codigo; Nombre = pop.Nombre;
                Precio = pop.Precio; ProveedorId = pop.ProveedorId;
                CantidadCanciones = pop.Cantidad_Canciones;
                Featuring = pop.Featuring; Nominaciones = pop.Nominaciones;
                SelloDiscografico = pop.SelloDiscografico;
                DuracionMinutos = pop.DuracionMinutos;
                return Page();
            }

            var reggaeton = await com.Get<AlbumesReggaeton>(
                $"AlbumesReggaeton/ConsultarPorId?id={id}");
            if (reggaeton != null)
            {
                TipoProducto = "AlbumesReggaeton";
                Codigo = reggaeton.Codigo; Nombre = reggaeton.Nombre;
                Precio = reggaeton.Precio; ProveedorId = reggaeton.ProveedorId;
                Explicito = reggaeton.Explicito; Idioma = reggaeton.Idioma;
                Productor = reggaeton.Productor;
                ColabDestacadas = reggaeton.ColabDestacadas;
                EstiloReggaeton = reggaeton.EstiloReggaeton;
                return Page();
            }

            var rock = await com.Get<AlbumesRock>(
                $"AlbumesRock/ConsultarPorId?id={id}");
            if (rock != null)
            {
                TipoProducto = "AlbumesRock";
                Codigo = rock.Codigo; Nombre = rock.Nombre;
                Precio = rock.Precio; ProveedorId = rock.ProveedorId;
                Autor = rock.Autor; AñoLanzamiento = (short)rock.Año_Lanzamiento;
                SelloDiscograficoRock = rock.Sello_Discografico;
                SubgeneroRock = rock.SubgeneroRock;
                EdicionRemaster = rock.EdicionRemaster;
                return Page();
            }

            var cuerdas = await com.Get<InstrumentosCuerdas>(
                $"InstrumentosCuerdas/ConsultarPorId?id={id}");
            if (cuerdas != null)
            {
                TipoProducto = "InstrumentosCuerdas";
                Codigo = cuerdas.Codigo; Nombre = cuerdas.Nombre;
                Precio = cuerdas.Precio; ProveedorId = cuerdas.ProveedorId;
                Marca = cuerdas.Marca; Color = cuerdas.Color;
                Material = cuerdas.Material;
                CantidadCuerdas = cuerdas.CantidadCuerdas;
                IncluyeEstuche = cuerdas.IncluyeEstuche;
                return Page();
            }

            var aire = await com.Get<InstrumentosAire>(
                $"InstrumentosAire/ConsultarPorId?id={id}");
            if (aire != null)
            {
                TipoProducto = "InstrumentosAire";
                Codigo = aire.Codigo; Nombre = aire.Nombre;
                Precio = aire.Precio; ProveedorId = aire.ProveedorId;
                TipoAire = aire.Tipo; AñoFabricacion = (short)aire.Año_Fabricacion;
                Peso = aire.Peso; Afinacion = aire.Afinacion;
                MaterialBoquilla = aire.MaterialBoquilla;
                return Page();
            }

            var percusion = await com.Get<InstrumentosPercusion>(
                $"InstrumentosPercusion/ConsultarPorId?id={id}");
            if (percusion != null)
            {
                TipoProducto = "InstrumentosPercusion";
                Codigo = percusion.Codigo; Nombre = percusion.Nombre;
                Precio = percusion.Precio; ProveedorId = percusion.ProveedorId;
                TipoPercusion = percusion.Tipo; Tamaño = percusion.Tamaño;
                PesoPercusion = percusion.Peso;
                MaterialParche = percusion.MaterialParche;
                IncluyeBaquetas = percusion.IncluyeBaquetas;
                return Page();
            }

            var bafl = await com.Get<Bafles>(
                $"Bafles/ConsultarPorId?id={id}");
            if (bafl != null)
            {
                TipoProducto = "Bafles";
                Codigo = bafl.Codigo; Nombre = bafl.Nombre;
                Precio = bafl.Precio; ProveedorId = bafl.ProveedorId;
                TamañoBafle = bafl.Tamaño; Decibeles = bafl.Decibeles;
                MarcaBafle = bafl.Marca; PotenciaWatts = bafl.PotenciaWatts;
                Bluetooth = bafl.Bluetooth;
                return Page();
            }

            var accesorio = await com.Get<Accesorios>(
                $"Accesorios/ConsultarPorId?id={id}");
            if (accesorio != null)
            {
                TipoProducto = "Accesorios";
                Codigo = accesorio.Codigo; Nombre = accesorio.Nombre;
                Precio = accesorio.Precio; ProveedorId = accesorio.ProveedorId;
                TipoAccesorio = accesorio.Tipo; ColorAccesorio = accesorio.Color;
                TamañoAccesorio = accesorio.Tamaño;
                Compatibilidad = accesorio.Compatibilidad;
                HechoEn = accesorio.HechoEn;
                return Page();
            }

            return RedirectToPage("/Admin/Productos");
        }

        public async Task<IActionResult> OnPostAsync(string tipoProducto)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());
            TipoProducto = tipoProducto;

            switch (tipoProducto)
            {
                case "AlbumesClasicos":
                    await com.Put<AlbumesClasicos>("AlbumesClasicos/Editar",
                        new AlbumesClasicos
                        {
                            Id = Id,
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
                    await com.Put<AlbumesPop>("AlbumesPop/Editar",
                        new AlbumesPop
                        {
                            Id = Id,
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
                    await com.Put<AlbumesReggaeton>("AlbumesReggaeton/Editar",
                        new AlbumesReggaeton
                        {
                            Id = Id,
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
                    await com.Put<AlbumesRock>("AlbumesRock/Editar",
                        new AlbumesRock
                        {
                            Id = Id,
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
                    await com.Put<InstrumentosCuerdas>("InstrumentosCuerdas/Editar",
                        new InstrumentosCuerdas
                        {
                            Id = Id,
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
                    await com.Put<InstrumentosAire>("InstrumentosAire/Editar",
                        new InstrumentosAire
                        {
                            Id = Id,
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
                    await com.Put<InstrumentosPercusion>("InstrumentosPercusion/Editar",
                        new InstrumentosPercusion
                        {
                            Id = Id,
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
                    await com.Put<Bafles>("Bafles/Editar",
                        new Bafles
                        {
                            Id = Id,
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
                    await com.Put<Accesorios>("Accesorios/Editar",
                        new Accesorios
                        {
                            Id = Id,
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

            return RedirectToPage("/Admin/Productos", new { exito = "editado" });
        }
    }
}