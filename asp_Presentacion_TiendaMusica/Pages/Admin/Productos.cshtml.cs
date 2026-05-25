using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages.Admin
{
    public class ProductosModel : PageModel
    {
        public List<lib_servicios_TiendaMusica.Modelos.Productos>? Lista { get; set; }

        public List<Proveedores>? Proveedores { get; set; }

        public string? FiltroTipo { get; set; }

        public string? MensajeExito { get; set; }

        public async Task<IActionResult> OnGetAsync(string? tipo, string? exito)
        {
            // Validar sesión
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            // Validar rol
            if (HttpContext.Session.GetString("Rol") != "Administrador")
                return RedirectToPage("/Index");

            // Mensaje de éxito
            if (exito == "true")
                MensajeExito = "Producto eliminado correctamente.";

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            // Traer proveedores
            Proveedores = await com.Get<List<Proveedores>>("Proveedores/Consultar");

            // Guardar filtro actual
            FiltroTipo = tipo;

            // SI NO HAY FILTRO -> TRAER TODOS
            if (string.IsNullOrEmpty(tipo))
            {
                Lista = new List<lib_servicios_TiendaMusica.Modelos.Productos>();

                Lista.AddRange(
                    (await com.Get<List<AlbumesClasicos>>("AlbumesClasicos/Consultar"))
                    ?.Cast<lib_servicios_TiendaMusica.Modelos.Productos>()
                    ?? new List<lib_servicios_TiendaMusica.Modelos.Productos>());

                Lista.AddRange(
                    (await com.Get<List<AlbumesPop>>("AlbumesPop/Consultar"))
                    ?.Cast<lib_servicios_TiendaMusica.Modelos.Productos>()
                    ?? new List<lib_servicios_TiendaMusica.Modelos.Productos>());

                Lista.AddRange(
                    (await com.Get<List<AlbumesReggaeton>>("AlbumesReggaeton/Consultar"))
                    ?.Cast<lib_servicios_TiendaMusica.Modelos.Productos>()
                    ?? new List<lib_servicios_TiendaMusica.Modelos.Productos>());

                Lista.AddRange(
                    (await com.Get<List<AlbumesRock>>("AlbumesRock/Consultar"))
                    ?.Cast<lib_servicios_TiendaMusica.Modelos.Productos>()
                    ?? new List<lib_servicios_TiendaMusica.Modelos.Productos>());

                Lista.AddRange(
                    (await com.Get<List<InstrumentosCuerdas>>("InstrumentosCuerdas/Consultar"))
                    ?.Cast<lib_servicios_TiendaMusica.Modelos.Productos>()
                    ?? new List<lib_servicios_TiendaMusica.Modelos.Productos>());

                Lista.AddRange(
                    (await com.Get<List<InstrumentosAire>>("InstrumentosAire/Consultar"))
                    ?.Cast<lib_servicios_TiendaMusica.Modelos.Productos>()
                    ?? new List<lib_servicios_TiendaMusica.Modelos.Productos>());

                Lista.AddRange(
                    (await com.Get<List<InstrumentosPercusion>>("InstrumentosPercusion/Consultar"))
                    ?.Cast<lib_servicios_TiendaMusica.Modelos.Productos>()
                    ?? new List<lib_servicios_TiendaMusica.Modelos.Productos>());

                Lista.AddRange(
                    (await com.Get<List<Bafles>>("Bafles/Consultar"))
                    ?.Cast<lib_servicios_TiendaMusica.Modelos.Productos>()
                    ?? new List<lib_servicios_TiendaMusica.Modelos.Productos>());

                Lista.AddRange(
                    (await com.Get<List<Accesorios>>("Accesorios/Consultar"))
                    ?.Cast<lib_servicios_TiendaMusica.Modelos.Productos>()
                    ?? new List<lib_servicios_TiendaMusica.Modelos.Productos>());
            }
            else
            {
                // FILTRAR POR TIPO
                Lista = tipo switch
                {
                    "AlbumesClasicos" =>
                        (await com.Get<List<AlbumesClasicos>>("AlbumesClasicos/Consultar"))
                        ?.Cast<lib_servicios_TiendaMusica.Modelos.Productos>()
                        .ToList(),

                    "AlbumesPop" =>
                        (await com.Get<List<AlbumesPop>>("AlbumesPop/Consultar"))
                        ?.Cast<lib_servicios_TiendaMusica.Modelos.Productos>()
                        .ToList(),

                    "AlbumesReggaeton" =>
                        (await com.Get<List<AlbumesReggaeton>>("AlbumesReggaeton/Consultar"))
                        ?.Cast<lib_servicios_TiendaMusica.Modelos.Productos>()
                        .ToList(),

                    "AlbumesRock" =>
                        (await com.Get<List<AlbumesRock>>("AlbumesRock/Consultar"))
                        ?.Cast<lib_servicios_TiendaMusica.Modelos.Productos>()
                        .ToList(),

                    "InstrumentosCuerdas" =>
                        (await com.Get<List<InstrumentosCuerdas>>("InstrumentosCuerdas/Consultar"))
                        ?.Cast<lib_servicios_TiendaMusica.Modelos.Productos>()
                        .ToList(),

                    "InstrumentosAire" =>
                        (await com.Get<List<InstrumentosAire>>("InstrumentosAire/Consultar"))
                        ?.Cast<lib_servicios_TiendaMusica.Modelos.Productos>()
                        .ToList(),

                    "InstrumentosPercusion" =>
                        (await com.Get<List<InstrumentosPercusion>>("InstrumentosPercusion/Consultar"))
                        ?.Cast<lib_servicios_TiendaMusica.Modelos.Productos>()
                        .ToList(),

                    "Bafles" =>
                        (await com.Get<List<Bafles>>("Bafles/Consultar"))
                        ?.Cast<lib_servicios_TiendaMusica.Modelos.Productos>()
                        .ToList(),

                    "Accesorios" =>
                        (await com.Get<List<Accesorios>>("Accesorios/Consultar"))
                        ?.Cast<lib_servicios_TiendaMusica.Modelos.Productos>()
                        .ToList(),

                    _ => new List<lib_servicios_TiendaMusica.Modelos.Productos>()
                };
            }

            return Page();
        }

        public async Task<IActionResult> OnPostEliminarAsync(int id, string tipo)
        {
            // Validar sesión
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            // Endpoint según tipo
            var endpoint = tipo switch
            {
                "AlbumesClasicos" => $"AlbumesClasicos/Eliminar?id={id}",
                "AlbumesPop" => $"AlbumesPop/Eliminar?id={id}",
                "AlbumesReggaeton" => $"AlbumesReggaeton/Eliminar?id={id}",
                "AlbumesRock" => $"AlbumesRock/Eliminar?id={id}",
                "InstrumentosCuerdas" => $"InstrumentosCuerdas/Eliminar?id={id}",
                "InstrumentosAire" => $"InstrumentosAire/Eliminar?id={id}",
                "InstrumentosPercusion" => $"InstrumentosPercusion/Eliminar?id={id}",
                "Bafles" => $"Bafles/Eliminar?id={id}",
                "Accesorios" => $"Accesorios/Eliminar?id={id}",
                _ => $"Productos/Eliminar?id={id}"
            };

            await com.Delete(endpoint);

            return RedirectToPage("/Admin/Productos", new
            {
                exito = "true",
                tipo
            });
        }

        // Obtener nombre proveedor
        public string ObtenerNombreProveedor(int proveedorId)
        {
            return Proveedores?
                .FirstOrDefault(p => p.Id == proveedorId)?
                .Nombre_Empresa
                ?? "Sin proveedor";
        }

        // Obtener tipo legible
        public string ObtenerTipo(lib_servicios_TiendaMusica.Modelos.Productos producto)
            => producto switch
            {
                AlbumesClasicos => "Álbum Clásico",
                AlbumesPop => "Álbum Pop",
                AlbumesReggaeton => "Álbum Reggaetón",
                AlbumesRock => "Álbum Rock",
                InstrumentosCuerdas => "Inst. Cuerdas",
                InstrumentosAire => "Inst. Aire",
                InstrumentosPercusion => "Inst. Percusión",
                Bafles => "Bafle",
                Accesorios => "Accesorio",
                _ => "Producto"
            };
    }
}