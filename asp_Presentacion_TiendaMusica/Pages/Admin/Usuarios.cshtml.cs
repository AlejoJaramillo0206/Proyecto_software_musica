using lib_presentacion_TiendaMusica;
using lib_servicios_TiendaMusica.Modelos;
using lib_servicios_TiendaMusica.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_Presentacion_TiendaMusica.Pages.Admin
{
    public class UsuariosModel : PageModel
    {
        public List<Usuarios>? Lista { get; set; }
        public List<Roles>? Roles { get; set; }
        public List<UsuarioRoles>? UsuarioRoles { get; set; }
        public string? MensajeExito { get; set; }

        public async Task<IActionResult> OnGetAsync(string? exito)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            if (HttpContext.Session.GetString("Rol") != "Administrador")
                return RedirectToPage("/Index");

            if (exito == "activado")
                MensajeExito = "Usuario activado correctamente.";
            else if (exito == "desactivado")
                MensajeExito = "Usuario desactivado correctamente.";
            else if (exito == "rol")
                MensajeExito = "Rol actualizado correctamente.";

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            Lista = await com.Get<List<Usuarios>>("Usuarios/Consultar");
            Roles = await com.Get<List<Roles>>("Roles/Consultar");
            UsuarioRoles = await com.Get<List<UsuarioRoles>>("UsuarioRoles/Consultar");

            return Page();
        }


        public async Task<IActionResult> OnPostToggleActivoAsync(int id, bool activo)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            var usuario = await com.Get<Usuarios>($"Usuarios/ConsultarPorId?id={id}");

            if (usuario != null)
            {
                usuario.Activo = !activo;
                await com.Put<Usuarios>("Usuarios/Editar", usuario);
            }

            var exito = !activo ? "activado" : "desactivado";
            return RedirectToPage("/Admin/Usuarios", new { exito });
        }

        // Cambiar rol del usuario
        public async Task<IActionResult> OnPostCambiarRolAsync(
            int usuarioId, int rolActualId, int nuevoRolId)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UsuarioId")))
                return RedirectToPage("/Login");

            var com = new Comunicaciones(Configuraciones.ObtenerUrlApi());

            // Eliminar rol actual
            await com.Delete(
                $"UsuarioRoles/Eliminar?usuarioId={usuarioId}&rolId={rolActualId}");

            // Asignar nuevo rol
            await com.Post<UsuarioRoles>("UsuarioRoles/Guardar", new UsuarioRoles
            {
                UsuarioId = usuarioId,
                RolId = nuevoRolId
            });

            return RedirectToPage("/Admin/Usuarios", new { exito = "rol" });
        }

        // Helpers
        public string ObtenerRolNombre(int usuarioId)
        {
            var ur = UsuarioRoles?.FirstOrDefault(ur => ur.UsuarioId == usuarioId);
            if (ur == null) return "Sin rol";
            return Roles?.FirstOrDefault(r => r.Id == ur.RolId)?.Nombre ?? "Sin rol";
        }

        public int ObtenerRolId(int usuarioId)
        {
            return UsuarioRoles?.FirstOrDefault(ur => ur.UsuarioId == usuarioId)
                ?.RolId ?? 0;
        }
    }
}