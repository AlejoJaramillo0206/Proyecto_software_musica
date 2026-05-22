using lib_servicios_TiendaMusica.Implementaciones;
using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Nucleo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ── Conexion ─────────────────────────────────────────────────────
builder.Services.AddScoped<IConexion>(p => new Conexion
{
    string_conexion = Configuraciones.obtener("conexion")
});

// ── Personas ──────────────────────────────────────────────────────
builder.Services.AddScoped<IClientesAplicacion, ClientesAplicacion>();
builder.Services.AddScoped<IEmpleadosAplicacion, EmpleadosAplicacion>();

// ── Proveedores ───────────────────────────────────────────────────
builder.Services.AddScoped<IProveedoresAplicacion, ProveedoresAplicacion>();

// ── Productos y subtipos ──────────────────────────────────────────
builder.Services.AddScoped<IProductosAplicacion, ProductosAplicacion>();
builder.Services.AddScoped<IAlbumesClasicosAplicacion, AlbumesClasicosAplicacion>();
builder.Services.AddScoped<IAlbumesPopAplicacion, AlbumesPopAplicacion>();
builder.Services.AddScoped<IAlbumesReggaetonAplicacion, AlbumesReggaetonAplicacion>();
builder.Services.AddScoped<IAlbumesRockAplicacion, AlbumesRockAplicacion>();
builder.Services.AddScoped<IInstrumentosCuerdasAplicacion, InstrumentosCuerdasAplicacion>();
builder.Services.AddScoped<IInstrumentosAireAplicacion, InstrumentosAireAplicacion>();
builder.Services.AddScoped<IInstrumentosPercusionAplicacion, InstrumentosPercusionAplicacion>();
builder.Services.AddScoped<IBaflesAplicacion, BaflesAplicacion>();
builder.Services.AddScoped<IAccesoriosAplicacion, AccesoriosAplicacion>();

// ── Facturacion ───────────────────────────────────────────────────
builder.Services.AddScoped<IMetodosPagoAplicacion, MetodosPagoAplicacion>();
builder.Services.AddScoped<IFacturasAplicacion, FacturasAplicacion>();
builder.Services.AddScoped<IDetalleFacturasAplicacion, DetalleFacturasAplicacion>();
builder.Services.AddScoped<IPagosAplicacion, PagosAplicacion>();

// ── Operaciones ───────────────────────────────────────────────────
builder.Services.AddScoped<IInventariosAplicacion, InventariosAplicacion>();
builder.Services.AddScoped<IGarantiasAplicacion, GarantiasAplicacion>();
builder.Services.AddScoped<IReseñasAplicacion, ReseñasAplicacion>();
builder.Services.AddScoped<IReparacionesAplicacion, ReparacionesAplicacion>();

// ── Usuarios, Roles y Auditoria ───────────────────────────────────
builder.Services.AddScoped<IRolesAplicacion, RolesAplicacion>();
builder.Services.AddScoped<IUsuariosAplicacion, UsuariosAplicacion>();
builder.Services.AddScoped<IUsuarioRolesAplicacion, UsuarioRolesAplicacion>();
builder.Services.AddScoped<IAuditoriasAplicacion, AuditoriasAplicacion>();

// ── CORS ──────────────────────────────────────────────────────────
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("PermitirTodo");
app.UseAuthorization();
app.MapControllers();
app.Run();