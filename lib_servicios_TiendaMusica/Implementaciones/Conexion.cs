

using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using Microsoft.EntityFrameworkCore;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class Conexion : DbContext, IConexion
    {
  

        public string? string_conexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.string_conexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personas>().UseTptMappingStrategy();
            modelBuilder.Entity<Productos>().UseTptMappingStrategy();

            // PK compuesta para la tabla puente UsuarioRoles
            modelBuilder.Entity<UsuarioRoles>()
                .HasKey(ur => new { ur.UsuarioId, ur.RolId });
        }

        // Personas y subtipos
        public DbSet<Personas>? Personas { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }

        // Proveedores
        public DbSet<Proveedores>? Proveedores { get; set; }

        // Productos y subtipos
        public DbSet<Productos>? Productos { get; set; }
        public DbSet<AlbumesClasicos>? AlbumesClasicos { get; set; }
        public DbSet<AlbumesPop>? AlbumesPop { get; set; }
        public DbSet<AlbumesReggaeton>? AlbumesReggaeton { get; set; }
        public DbSet<AlbumesRock>? AlbumesRock { get; set; }
        public DbSet<InstrumentosCuerdas>? InstrumentosCuerdas { get; set; }
        public DbSet<InstrumentosAire>? InstrumentosAire { get; set; }
        public DbSet<InstrumentosPercusion>? InstrumentosPercusion { get; set; }
        public DbSet<Bafles>? Bafles { get; set; }
        public DbSet<Accesorios>? Accesorios { get; set; }

        // Facturación
        public DbSet<MetodosPago>? MetodosPago { get; set; }
        public DbSet<Facturas>? Facturas { get; set; }
        public DbSet<DetalleFacturas>? DetalleFacturas { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }

        // Operaciones
        public DbSet<Inventarios>? Inventarios { get; set; }
        public DbSet<Garantias>? Garantias { get; set; }
        public DbSet<Reseñas>? Reseñas { get; set; }
        public DbSet<Reparaciones>? Reparaciones { get; set; }

        // Usuarios, Roles y Auditoría
        public DbSet<Roles>? Roles { get; set; }
        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<UsuarioRoles>? UsuarioRoles { get; set; }
        public DbSet<Auditorias>? Auditorias { get; set; }
    }
}