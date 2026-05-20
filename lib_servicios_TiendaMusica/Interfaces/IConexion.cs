using lib_servicios_TiendaMusica.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_servicios_TiendaMusica.Interfaces
{
    public interface IConexion
    {
        string? string_conexion { get; set; }

       
        DbSet<Personas>? Personas { get; set; }
        DbSet<Empleados>? Empleados { get; set; }
        DbSet<Clientes>? Clientes { get; set; }
        DbSet<Proveedores>? Proveedores { get; set; }
        DbSet<Productos>? Productos { get; set; }
        DbSet<AlbumesClasicos>? AlbumesClasicos { get; set; }
        DbSet<AlbumesPop>? AlbumesPop { get; set; }         
        DbSet<AlbumesReggaeton>? AlbumesReggaeton { get; set; }
        DbSet<AlbumesRock>? AlbumesRock { get; set; }
        DbSet<InstrumentosCuerdas>? InstrumentosCuerdas { get; set; }
        DbSet<InstrumentosAire>? InstrumentosAire { get; set; }
        DbSet<InstrumentosPercusion>? InstrumentosPercusion { get; set; }
        DbSet<Bafles>? Bafles { get; set; }
        DbSet<Accesorios>? Accesorios { get; set; }
        DbSet<MetodosPago>? MetodosPago { get; set; }
        DbSet<Facturas>? Facturas { get; set; }
        DbSet<DetalleFacturas>? DetalleFacturas { get; set; }
        DbSet<Pagos>? Pagos { get; set; }
        DbSet<Inventarios>? Inventarios { get; set; }
        DbSet<Garantias>? Garantias { get; set; }
        DbSet<Reseñas>? Reseñas { get; set; }
        DbSet<Reparaciones>? Reparaciones { get; set; }
        DbSet<Roles>? Roles { get; set; }
        DbSet<Usuarios>? Usuarios { get; set; }
        DbSet<UsuarioRoles>? UsuarioRoles { get; set; }
        DbSet<Auditorias>? Auditorias { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
