

var lista_clientes = new List<Clientes>();
lista_clientes.Add(new Clientes() {Id=1, Cedula="123456789", Nombre="Juan Perez", Correo="juan.perez@email.com", Fecha_Nacimiento= new DateTime(1990, 5, 15), Profesion="Abogado", EsMusico=false, MarcaFav="N/A" });
lista_clientes.Add(new Clientes() {Id=2, Cedula="987654321", Nombre="Maria Gomez", Correo="maria.gomez@email.com", Fecha_Nacimiento=new DateTime(1985, 8, 20), Profesion="Ingeniera", EsMusico=true, MarcaFav="Sony" });
lista_clientes.Add(new Clientes() {Id=3, Cedula="456789123", Nombre="Carlos Rodriguez", Correo="carlos.rodriguez@email.com", Fecha_Nacimiento=new DateTime(1992, 12, 10), Profesion="Docente", EsMusico=false, MarcaFav="Fender" });
lista_clientes.Add(new Clientes() {Id=4, Cedula="789123456", Nombre="Ana Martinez", Correo="ana.martinez@email.com", Fecha_Nacimiento=new DateTime(1988, 3, 25),Profesion="Diseñadora", EsMusico=true, MarcaFav="Yamaha" });
lista_clientes.Add(new Clientes() {Id=5, Cedula="321654987", Nombre="Luis Hernandez", Correo="luis.hernandez@email.com", Fecha_Nacimiento=new DateTime(1995, 7, 18),Profesion="Arquitecto", EsMusico=false, MarcaFav="Gibson" });

var lista_empleados = new List<Empleados>();

lista_empleados.Add(new Empleados() { Id=1, Cedula="111111111", Nombre="Carlos Mejia", Cargo="Vendedor", Numero_Banco=12345, Numero_ARL=101, FechaIngreso=new DateTime(2020,1,10), Activo=true, ValorDia = 45000, DiasTrabajados = 19});
lista_empleados.Add(new Empleados() { Id=2, Cedula="222222222", Nombre="Laura Torres", Cargo="Cajera", Numero_Banco=12346, Numero_ARL=102, FechaIngreso=new DateTime(2019,3,5), Activo=false, ValorDia = 50000, DiasTrabajados = 30});
lista_empleados.Add(new Empleados() { Id=3, Cedula="333333333", Nombre="Miguel Castro", Cargo="Administrador", Numero_Banco=12347, Numero_ARL=103, FechaIngreso=new DateTime(2018,7,20), Activo=true, ValorDia = 70000, DiasTrabajados = 28});
lista_empleados.Add(new Empleados() { Id=4, Cedula="444444444", Nombre="Sofia Ramirez", Cargo="Bodega", Numero_Banco=12348, Numero_ARL=104, FechaIngreso=new DateTime(2021,9,15), Activo=false, ValorDia = 48000, DiasTrabajados = 30});
lista_empleados.Add(new Empleados() { Id=5, Cedula="555555555", Nombre="Andres Lopez", Cargo="Soporte", Numero_Banco=12349, Numero_ARL=105, FechaIngreso=new DateTime(2022,2,1), Activo=true, ValorDia = 50000, DiasTrabajados = 25});



var lista_proveedores = new List<Proveedores>();

lista_proveedores.Add(new Proveedores() { Id=1, Codigo="PR01", Nombre_Empresa="Sony Music", Telefono=300111111, Correo="sony@proveedor.com" });
lista_proveedores.Add(new Proveedores() { Id=2, Codigo="PR02", Nombre_Empresa="Universal Music", Telefono=300222222, Correo="universal@proveedor.com" });
lista_proveedores.Add(new Proveedores() { Id=3, Codigo="PR03", Nombre_Empresa="Yamaha", Telefono=300333333, Correo="yamaha@proveedor.com" });
lista_proveedores.Add(new Proveedores() { Id=4, Codigo="PR04", Nombre_Empresa="Fender", Telefono=300444444, Correo="fender@proveedor.com" });
lista_proveedores.Add(new Proveedores() { Id=5, Codigo="PR05", Nombre_Empresa="Roland", Telefono=300555555, Correo="roland@proveedor.com" });



var lista_albumesClasicos = new List<AlbumesClasicos>();

lista_albumesClasicos.Add(new AlbumesClasicos() { Id=1, Codigo="CLA01", Nombre="Las Cuatro Estaciones", Precio=95000m, Compositor="Antonio Vivaldi", Interprete="Itzhak Perlman", Orquesta="Orquesta Barroca", Grabaciones_en_vivo=true, Epoca_Musical="Barroco", ProveedorId=1 });
lista_albumesClasicos.Add(new AlbumesClasicos() { Id=2, Codigo="CLA02", Nombre="Requiem", Precio=88000m, Compositor="Mozart", Interprete="Coro Filarmonico", Orquesta="Filarmonica de Viena", Grabaciones_en_vivo=false, Epoca_Musical="Clasico", ProveedorId=2 });
lista_albumesClasicos.Add(new AlbumesClasicos() { Id=3, Codigo="CLA03", Nombre="Sinfonia No.5", Precio=92000m, Compositor="Beethoven", Interprete="Herbert von Karajan", Orquesta="Berlin Philharmonic", Grabaciones_en_vivo=true, Epoca_Musical="Romantico", ProveedorId=1 });
lista_albumesClasicos.Add(new AlbumesClasicos() { Id=4, Codigo="CLA04", Nombre="El Mesias", Precio=87000m, Compositor="Handel", Interprete="London Symphony", Orquesta="Orquesta Nacional", Grabaciones_en_vivo=false, Epoca_Musical="Barroco", ProveedorId=2 });
lista_albumesClasicos.Add(new AlbumesClasicos() { Id=5, Codigo="CLA05", Nombre="Canon en D", Precio=76000m, Compositor="Pachelbel", Interprete="Academy of St Martin", Orquesta="Academy Orchestra", Grabaciones_en_vivo=true, Epoca_Musical="Barroco", ProveedorId=1 });


var lista_albumesPop = new List<AlbumesPop>();

lista_albumesPop.Add(new AlbumesPop() { Id=6, Codigo="POP01", Nombre="Future Nostalgia", Precio=80000m, Cantidad_Canciones=12, Featuring="DaBaby", Nominaciones=5, SelloDiscografico="Warner", DuracionMinutos=37, ProveedorId=1 });
lista_albumesPop.Add(new AlbumesPop() { Id=7, Codigo="POP02", Nombre="1989", Precio=75000m, Cantidad_Canciones=13, Featuring="N/A", Nominaciones=10, SelloDiscografico="Big Machine", DuracionMinutos=48, ProveedorId=2 });
lista_albumesPop.Add(new AlbumesPop() { Id=8, Codigo="POP03", Nombre="Thriller", Precio=90000m, Cantidad_Canciones=9, Featuring="Paul McCartney", Nominaciones=8, SelloDiscografico="Epic", DuracionMinutos=42, ProveedorId=1 });
lista_albumesPop.Add(new AlbumesPop() { Id=9, Codigo="POP04", Nombre="Divide", Precio=85000m, Cantidad_Canciones=16, Featuring="Beyonce", Nominaciones=4, SelloDiscografico="Atlantic", DuracionMinutos=50, ProveedorId=2 });
lista_albumesPop.Add(new AlbumesPop() { Id=10, Codigo="POP05", Nombre="Chromatica", Precio=78000m, Cantidad_Canciones=14, Featuring="Ariana Grande", Nominaciones=6, SelloDiscografico="Interscope", DuracionMinutos=43, ProveedorId=1 });



var lista_albumesReggaeton = new List<AlbumesReggaeton>();

lista_albumesReggaeton.Add(new AlbumesReggaeton() { Id=11, Codigo="REG01", Nombre="Un Verano Sin Ti", Precio=88000m, Explicito=true, Idioma="Español", Productor="Tainy", ColabDestacadas="Jhay Cortez", EstiloReggaeton="Moderno", ProveedorId=1 });
lista_albumesReggaeton.Add(new AlbumesReggaeton() { Id=12, Codigo="REG02", Nombre="Barrio Fino", Precio=79000m, Explicito=true, Idioma="Español", Productor="Luny Tunes", ColabDestacadas="Zion", EstiloReggaeton="Clasico", ProveedorId=2 });
lista_albumesReggaeton.Add(new AlbumesReggaeton() { Id=13, Codigo="REG03", Nombre="Vibras", Precio=76000m, Explicito=false, Idioma="Español", Productor="Sky Rompiendo", ColabDestacadas="Wisin", EstiloReggaeton="Romantico", ProveedorId=1 });
lista_albumesReggaeton.Add(new AlbumesReggaeton() { Id=14, Codigo="REG04", Nombre="LLNM", Precio=85000m, Explicito=true, Idioma="Español", Productor="Anuel AA", ColabDestacadas="Mora", EstiloReggaeton="Trap", ProveedorId=2 });
lista_albumesReggaeton.Add(new AlbumesReggaeton() { Id=15, Codigo="REG05", Nombre="Energía", Precio=75000m, Explicito=false, Idioma="Español", Productor="Bull Nene", ColabDestacadas="Daddy Yankee", EstiloReggaeton="Urbano", ProveedorId=1 });




var lista_albumesRock = new List<AlbumesRock>();

lista_albumesRock.Add(new AlbumesRock() { Id=16, Codigo="ROCK01", Nombre="Back in Black", Precio=85000m, Autor="AC/DC", Año_Lanzamiento=1980, Sello_Discografico="Atlantic", SubgeneroRock="Hard Rock", EdicionRemaster=true, ProveedorId=2 });
lista_albumesRock.Add(new AlbumesRock() { Id=17, Codigo="ROCK02", Nombre="The Dark Side of the Moon", Precio=99000m, Autor="Pink Floyd", Año_Lanzamiento=1973, Sello_Discografico="Harvest", SubgeneroRock="Progressive Rock", EdicionRemaster=true, ProveedorId=1 });
lista_albumesRock.Add(new AlbumesRock() { Id=18, Codigo="ROCK03", Nombre="Nevermind", Precio=78000m, Autor="Nirvana", Año_Lanzamiento=1991, Sello_Discografico="DGC", SubgeneroRock="Grunge", EdicionRemaster=false, ProveedorId=2 });
lista_albumesRock.Add(new AlbumesRock() { Id=19, Codigo="ROCK04", Nombre="Led Zeppelin IV", Precio=88000m, Autor="Led Zeppelin", Año_Lanzamiento=1971, Sello_Discografico="Atlantic", SubgeneroRock="Classic Rock", EdicionRemaster=true, ProveedorId=1 });
lista_albumesRock.Add(new AlbumesRock() { Id=20, Codigo="ROCK05", Nombre="Appetite for Destruction", Precio=82000m, Autor="Guns N Roses", Año_Lanzamiento=1987, Sello_Discografico="Geffen", SubgeneroRock="Hard Rock", EdicionRemaster=false, ProveedorId=2 });



var lista_instrumentosCuerda = new List<InstrumentosCuerdas>();

lista_instrumentosCuerda.Add(new InstrumentosCuerdas() { Id=21, Codigo="CUER01", Nombre="Guitarra Fender Stratocaster", Precio=2500000m, Marca="Fender", Color="Negro", Material="Madera", CantidadCuerdas=6, IncluyeEstuche=true, ProveedorId=4 });
lista_instrumentosCuerda.Add(new InstrumentosCuerdas() { Id=22, Codigo="CUER02", Nombre="Bajo Yamaha TRBX", Precio=1800000m, Marca="Yamaha", Color="Azul", Material="Madera", CantidadCuerdas=4, IncluyeEstuche=false, ProveedorId=3 });
lista_instrumentosCuerda.Add(new InstrumentosCuerdas() { Id=23, Codigo="CUER03", Nombre="Violin Clasico 4/4", Precio=950000m, Marca="Stentor", Color="Cafe", Material="Madera", CantidadCuerdas=4, IncluyeEstuche=true, ProveedorId=3 });
lista_instrumentosCuerda.Add(new InstrumentosCuerdas() { Id=24, Codigo="CUER04", Nombre="Guitarra Acustica Gibson", Precio=3200000m, Marca="Gibson", Color="Natural", Material="Caoba", CantidadCuerdas=6, IncluyeEstuche=true, ProveedorId=4 });
lista_instrumentosCuerda.Add(new InstrumentosCuerdas() { Id=25, Codigo="CUER05", Nombre="Ukelele Soprano", Precio=350000m, Marca="Mahalo", Color="Rojo", Material="Madera", CantidadCuerdas=4, IncluyeEstuche=false, ProveedorId=5 });


var lista_instrumentosAire = new List<InstrumentosAire>();

lista_instrumentosAire.Add(new InstrumentosAire() { Id=26, Codigo="AIRE01", Nombre="Flauta Traversa Yamaha", Precio=1200000m, Tipo="Flauta", Año_Fabricacion=2022, Peso=0.5, Afinacion="Do", MaterialBoquilla="Plata", ProveedorId=3 });
lista_instrumentosAire.Add(new InstrumentosAire() { Id=27, Codigo="AIRE02", Nombre="Saxofon Alto", Precio=2800000m, Tipo="Saxofon", Año_Fabricacion=2021, Peso=2.5, Afinacion="Mi Bemol", MaterialBoquilla="Metal", ProveedorId=5 });
lista_instrumentosAire.Add(new InstrumentosAire() { Id=28, Codigo="AIRE03", Nombre="Trompeta Profesional", Precio=1500000m, Tipo="Trompeta", Año_Fabricacion=2020, Peso=1.2, Afinacion="Si Bemol", MaterialBoquilla="Laton", ProveedorId=5 });
lista_instrumentosAire.Add(new InstrumentosAire() { Id=29, Codigo="AIRE04", Nombre="Clarinete Estudiantil", Precio=900000m, Tipo="Clarinete", Año_Fabricacion=2023, Peso=0.9, Afinacion="Si Bemol", MaterialBoquilla="Resina", ProveedorId=3 });
lista_instrumentosAire.Add(new InstrumentosAire() { Id=30, Codigo="AIRE05", Nombre="Armonica Blues", Precio=120000m, Tipo="Armonica", Año_Fabricacion=2024, Peso=0.2, Afinacion="Do", MaterialBoquilla="Metal", ProveedorId=5 });



var lista_instrumentosPercusion = new List<InstrumentosPercusion>();

lista_instrumentosPercusion.Add(new InstrumentosPercusion() { Id=31, Codigo="PERC01", Nombre="Bateria Acustica Completa", Precio=4500000m, Tipo="Bateria", Tamaño="Grande", Peso=35.0, MaterialParche="Sintetico", IncluyeBaquetas=true, ProveedorId=5 });
lista_instrumentosPercusion.Add(new InstrumentosPercusion() { Id=32, Codigo="PERC02", Nombre="Cajon Peruano", Precio=600000m, Tipo="Cajon", Tamaño="Mediano", Peso=5.0, MaterialParche="Madera", IncluyeBaquetas=false, ProveedorId=3 });
lista_instrumentosPercusion.Add(new InstrumentosPercusion() { Id=33, Codigo="PERC03", Nombre="Congas Profesionales", Precio=1800000m, Tipo="Congas", Tamaño="Grande", Peso=18.0, MaterialParche="Cuero", IncluyeBaquetas=false, ProveedorId=5 });
lista_instrumentosPercusion.Add(new InstrumentosPercusion() { Id=34, Codigo="PERC04", Nombre="Redoblante", Precio=750000m, Tipo="Redoblante", Tamaño="Pequeño", Peso=6.5, MaterialParche="Sintetico", IncluyeBaquetas=true, ProveedorId=3 });
lista_instrumentosPercusion.Add(new InstrumentosPercusion() { Id=35, Codigo="PERC05", Nombre="Pandereta Musical", Precio=120000m, Tipo="Pandereta", Tamaño="Pequeño", Peso=0.8, MaterialParche="Plastico", IncluyeBaquetas=false, ProveedorId=3 });




var lista_bafles = new List<Bafles>();

lista_bafles.Add(new Bafles() { Id=36, Codigo="BAF01", Nombre="Bafle JBL PartyBox", Precio=1500000m, Tamaño="Grande", Decibeles=120, Marca="JBL", PotenciaWatts=1000, Bluetooth=true, ProveedorId=5 });
lista_bafles.Add(new Bafles() { Id=37, Codigo="BAF02", Nombre="Bafle Sony X-Series", Precio=1300000m, Tamaño="Mediano", Decibeles=110, Marca="Sony", PotenciaWatts=800, Bluetooth=true, ProveedorId=1 });
lista_bafles.Add(new Bafles() { Id=38, Codigo="BAF03", Nombre="Bafle Yamaha Stage", Precio=2100000m, Tamaño="Grande", Decibeles=125, Marca="Yamaha", PotenciaWatts=1200, Bluetooth=false, ProveedorId=3 });
lista_bafles.Add(new Bafles() { Id=39, Codigo="BAF04", Nombre="Bafle Portatil LG", Precio=600000m, Tamaño="Pequeño", Decibeles=95, Marca="LG", PotenciaWatts=300, Bluetooth=true, ProveedorId=2 });
lista_bafles.Add(new Bafles() { Id=40, Codigo="BAF05", Nombre="Bafle Profesional Mackie", Precio=2500000m, Tamaño="Grande", Decibeles=130, Marca="Mackie", PotenciaWatts=1500, Bluetooth=false, ProveedorId=4 });



var lista_accesorios = new List<Accesorios>();

lista_accesorios.Add(new Accesorios() { Id=41, Codigo="ACC01", Nombre="Cuerdas para Guitarra", Precio=50000m, Tipo="Cuerdas", Color="Plateado", Tamaño="Estandar", Compatibilidad="Guitarra Electrica", HechoEn="USA", ProveedorId=4 });
lista_accesorios.Add(new Accesorios() { Id=42, Codigo="ACC02", Nombre="Baquetas Profesionales", Precio=35000m, Tipo="Baquetas", Color="Natural", Tamaño="5A", Compatibilidad="Bateria", HechoEn="Mexico", ProveedorId=5 });
lista_accesorios.Add(new Accesorios() { Id=43, Codigo="ACC03", Nombre="Capotraste Metalico", Precio=45000m, Tipo="Capotraste", Color="Negro", Tamaño="Universal", Compatibilidad="Guitarra Acustica", HechoEn="China", ProveedorId=3 });
lista_accesorios.Add(new Accesorios() { Id=44, Codigo="ACC04", Nombre="Cable Plug 3m", Precio=40000m, Tipo="Cable", Color="Negro", Tamaño="3 Metros", Compatibilidad="Instrumentos Electricos", HechoEn="Colombia", ProveedorId=2 });
lista_accesorios.Add(new Accesorios() { Id=45, Codigo="ACC05", Nombre="Afinador Digital", Precio=90000m, Tipo="Afinador", Color="Negro", Tamaño="Pequeño", Compatibilidad="Universal", HechoEn="Japon", ProveedorId=1 });



var lista_inventarios = new List<Inventarios>();

lista_inventarios.Add(new Inventarios() { Id=1, StockDisponible=10, FechaActualizacion=DateTime.Now, UbicacionBodega="Bodega A1", ProductoId=1 });
lista_inventarios.Add(new Inventarios() { Id=2, StockDisponible=5, FechaActualizacion=DateTime.Now, UbicacionBodega="Bodega A2", ProductoId=22 });
lista_inventarios.Add(new Inventarios() { Id=3, StockDisponible=15, FechaActualizacion=DateTime.Now, UbicacionBodega="Bodega B1", ProductoId=32 });
lista_inventarios.Add(new Inventarios() { Id=4, StockDisponible=8, FechaActualizacion=DateTime.Now, UbicacionBodega="Bodega B2", ProductoId=14 });
lista_inventarios.Add(new Inventarios() { Id=5, StockDisponible=0, FechaActualizacion=DateTime.Now, UbicacionBodega="Bodega C1", ProductoId=5 });


// ======================================================
// ======================================================

var lista_facturas = new List<Facturas>();

lista_facturas.Add(new Facturas()
{
    Id = 1,
    Codigo = "FAC001",
    Fecha = DateTime.Now,
    ClienteId = 1,
    Total = 175000,
 
});

lista_facturas.Add(new Facturas()
{
    Id = 2,
    Codigo = "FAC002",
    Fecha = DateTime.Now,
    ClienteId = 2,
    Total = 92000,
 
});

lista_facturas.Add(new Facturas()
{
    Id = 3,
    Codigo = "FAC003",
    Fecha = DateTime.Now,
    ClienteId = 3,
    Total = 190000,
});

lista_facturas.Add(new Facturas()
{
    Id = 4,
    Codigo = "FAC004",
    Fecha = DateTime.Now,
    ClienteId = 4,
    Total = 261000,
});

lista_facturas.Add(new Facturas()
{
    Id = 5,
    Codigo = "FAC005",
    Fecha = DateTime.Now,
    ClienteId = 5,
    Total = 1800000
});

lista_facturas.Add(new Facturas(){
    Id = 6,
    Codigo = "FAC006",
    Fecha = DateTime.Now,
    ClienteId = 2,
    Total = 195000
});

// ======================================================
// ======================================================



var lista_detalleFacturas = new List<DetalleFacturas>();

lista_detalleFacturas.Add(new DetalleFacturas()
{
    Id = 1,
    FacturaId = 1,
    ProductoId = 1,
    Cantidad = 1,
    PrecioUnitario = 95000,
    Subtotal = 95000
});

lista_detalleFacturas.Add(new DetalleFacturas()
{
    Id = 2,
    FacturaId = 1,
    ProductoId = 6,
    Cantidad = 1,
    PrecioUnitario = 80000,
    Subtotal = 80000
});

lista_detalleFacturas.Add(new DetalleFacturas()
{
    Id = 3,
    FacturaId = 2,
    ProductoId = 3,
    Cantidad = 1,
    PrecioUnitario = 92000,
    Subtotal = 92000
});

lista_detalleFacturas.Add(new DetalleFacturas()
{
    Id = 6,
    FacturaId = 3,
    ProductoId = 1,
    Cantidad = 2,
    PrecioUnitario = 95000,
    Subtotal = 190000  
});

lista_detalleFacturas.Add(new DetalleFacturas()
{
    Id = 7,
    FacturaId = 4,
    ProductoId = 4,
    Cantidad = 3,
    PrecioUnitario = 87000,
    Subtotal = 261000  
});

lista_detalleFacturas.Add(new DetalleFacturas()
{
    Id = 8,
    FacturaId = 5,
    ProductoId = 22,
    Cantidad = 1,
    PrecioUnitario = 1800000,
    Subtotal = 1800000 
});

lista_detalleFacturas.Add(new DetalleFacturas()
{
    Id = 9,
    FacturaId = 6,
    ProductoId = 23,
    Cantidad = 3,
    PrecioUnitario = 950000,
    Subtotal = 195000
});

// ======================================================
// ======================================================

var lista_pagos = new List<Pagos>();

lista_pagos.Add(new Pagos()
{
    Id = 1,
    FacturaId = 1,
    FechaPago = DateTime.Now,
    Estado = "Completado"
});

lista_pagos.Add(new Pagos()
{
    Id = 2,
    FacturaId = 2,
    FechaPago = DateTime.Now,
    Estado = "Pendiente"
});

lista_pagos.Add(new Pagos()
{
    Id = 3,
    FacturaId = 3,
    FechaPago = DateTime.Now.AddDays(-2),
    Estado = "Pagado"
});

lista_pagos.Add(new Pagos()
{
    Id = 4,
    FacturaId = 4,
    FechaPago = DateTime.Now.AddDays(-10),
    Estado = "Pendiente"
});

lista_pagos.Add(new Pagos()
{
    Id = 5,
    FacturaId = 5,
    FechaPago = DateTime.Now.AddMonths(-1),
    Estado = "Rechazado"
});


// ======================================================
// ======================================================



var lista_metodoPago = new List<MetodosPago>();

lista_metodoPago.Add(new MetodosPago()
{
    Id = 1,
    NumCuotas = 2,
    Nombre = "Efectivo",
    Descripcion = "Pago realizado en dinero fisico",
    Activo = true
});

lista_metodoPago.Add(new MetodosPago()
{
    Id = 2,
    NumCuotas = 4,
    Nombre = "Tarjeta Credito",
    Descripcion = "Pago con tarjeta de credito bancaria",
    Activo = true
});

lista_metodoPago.Add(new MetodosPago()
{
    Id = 3,
    NumCuotas = 4,
    Nombre = "Tarjeta Debito",
    Descripcion = "Pago con tarjeta debito bancaria",
    Activo = true
});

lista_metodoPago.Add(new MetodosPago()
{
    Id = 4,
    NumCuotas = 24,
    Nombre = "Transferencia",
    Descripcion = "Pago mediante transferencia bancaria",
    Activo = true
});

lista_metodoPago.Add(new MetodosPago()
{
    Id = 5,
    NumCuotas = 12,
    Nombre = "Pago Movil",
    Descripcion = "Pago mediante aplicacion movil",
    Activo = true
});


// ======================================================
// ======================================================



var lista_garantias = new List<Garantias>();

lista_garantias.Add(new Garantias()
{
    Id = 1,
    ProductosId = 1,
    FechaInicio = DateTime.Now,
    FechaFin = DateTime.Now.AddYears(1),
    Estado = "Activa",
    ClientesId = 1
});

lista_garantias.Add(new Garantias()
{
    Id = 2,
    ProductosId = 6,
    FechaInicio = DateTime.Now,
    FechaFin = DateTime.Now.AddMonths(6),
    Estado = "Activa",
    ClientesId = 1
});

lista_garantias.Add(new Garantias()
{
    Id = 3,
    ProductosId = 2,
    FechaInicio = DateTime.Now,
    FechaFin = DateTime.Now.AddMonths(4),
    Estado = "Activa",
    ClientesId = 2
});

lista_garantias.Add(new Garantias()
{
    Id = 4,
    ProductosId = 4,
    FechaInicio = DateTime.Now.AddYears(-1),
    FechaFin = DateTime.Now.AddMonths(-1),
    Estado = "Activa",
    ClientesId = 3
});

lista_garantias.Add(new Garantias()
{
    Id = 5,
    ProductosId = 8,
    FechaInicio = DateTime.Now.AddMonths(-3),
    FechaFin = DateTime.Now.AddMonths(2),
    Estado = "Inactiva",
    ClientesId = 2
});

// ======================================================
// ======================================================

Console.WriteLine("Bienvenido a la tienda de música!");

while (true)
{
    Console.WriteLine("Seleccione una opción:");
    Console.WriteLine("1. Ver empleados activos");
    Console.WriteLine("2. Stock de un producto específico");
    Console.WriteLine("3. Ver facturas mayores a 500000");
    Console.WriteLine("4. Ver factura de clientes por IDs");
    Console.WriteLine("5. Verificar garantia");
    Console.WriteLine("6. Salarios Empleados");
    Console.WriteLine("7. Cuantos dias de garantia le quedan a clientes activos");
    Console.WriteLine("8. Salir");

    string opcion = Console.ReadLine();
    calculos calculo = new calculos();

    switch (opcion)
    {
        case "1":
            Console.WriteLine("Mostrando empleados...");
                foreach(var Personas in lista_empleados.Where(x => x.Activo))
                {
                    Console.WriteLine("Id persona: "+Personas.Id + " | " + 
                    "Cedula persona: "+Personas.Cedula+ " | " +
                    "Id Nombre: "+Personas.Nombre+ " | " +
                    "Id Numero_ARL: "+Personas.Numero_ARL+ " | " +
                    "Id FechaIngreso: "+Personas.FechaIngreso+ " | " +
                    "Id Cargo: "+Personas.Cargo 
                    );
                }
            break;
        case "2":
            Console.WriteLine("Stock de un producto específico...");

         
            if(true)
            {
                foreach (var inventarios in lista_inventarios.Where(x => x.StockDisponible > 0))
                {
                    
                    Console.WriteLine(inventarios.Id + " | " +
                        inventarios.StockDisponible + " | " +
                        inventarios.FechaActualizacion + " | " +
                        inventarios.UbicacionBodega + " | " +
                        inventarios.ProductoId
                    );
                }

            }
  
            


            break;
        case "3":
            Console.WriteLine("Ver facturas mayores a 500000");

                foreach (var factura in lista_facturas.Where(x => x.Total > 500000.00m))
            {
                Console.WriteLine(factura.Id + " | " +
                    factura.Codigo + " | " +
                    factura.Fecha + " | " +
                    factura.ClienteId + " | " +
                    factura.Total + " | " +
                    "Total a pagar:  "+calculo.descuento(factura) + " | " + "Se le aplico:" + "  " +calculo.CuantoDescuento(factura)+ "  " + "de descuento" 
                );
            }   

            break;
        case "4":
            Console.WriteLine("Ver factura por IDs cliente.");
            
                foreach (var factura in lista_facturas)
                {
                    Console.WriteLine("Factura: " + factura.Codigo);
                    Console.WriteLine("Fecha: " + factura.Fecha);
                    Console.WriteLine("Cliente ID: " + factura.ClienteId);
                    Console.WriteLine("Edad: " + calculo.EdadCliente (lista_clientes.FirstOrDefault(x => x.Id == factura.ClienteId))+ " años");
                    Console.WriteLine("Total: " + factura.Total);
                    Console.WriteLine("Detalles:");
                    foreach (var detalle in lista_detalleFacturas.Where(x => x.FacturaId == factura.Id))
                    {
                        Console.WriteLine("- Producto ID: " + detalle.ProductoId);
                        Console.WriteLine("  Cantidad: " + detalle.Cantidad);
                        Console.WriteLine("  Precio Unitario: " + detalle.PrecioUnitario);
                        Console.WriteLine("  Subtotal: " + detalle.Subtotal);
                    }
                    Console.WriteLine();
                }

            break;
        case "5":
                Console.WriteLine("Verificar garantía.");

                foreach (var garantia in lista_garantias)
                {
                    if (garantia.Estado == "Activa" &&
                        garantia.FechaFin >= DateTime.Now)
                    {
                    
                        Console.WriteLine("Producto " + garantia.ProductosId + " - Garantia valida hasta: " + garantia.FechaFin.ToString("dd/MM/yyyy"));

                    
                    }
                    else
                    {
               
                        Console.WriteLine("Producto " + garantia.ProductosId + " - Garantía no activa o vencida ");
                    }
                }

                break;
            case "6":
                   
                    foreach (var empleado in lista_empleados)
                    {
                        Console.WriteLine("Nombre: " + empleado.Nombre + " Salario: " + calculo.CalcularSalario(empleado));
                    }

            break;
               case "7":
   
                Console.WriteLine("Cuantos dias de garantia le quedan a clientes activos");
      
                foreach (var garantia in lista_garantias)
                {
                    int dias = calculo.DiasRestantesGarantia(garantia);
                     if(dias < 0)
                    {
                        Console.WriteLine("Garantia ID: " + garantia.Id + " - Garantía vencida");
                    }else
                    Console.WriteLine("Garantia ID: " + garantia.Id + " - Dias restantes: " + dias);
               
                }    
                break;


            return;
              case "8":
            Console.WriteLine("Gracias por visitar la tienda de música!");

            return;
        default:
            Console.WriteLine("Opción no válida, por favor intente de nuevo.");
            break;
    }
        
}


// ======================================================
// ======================================================

public class calculos
{
    public double CalcularSalario(Empleados empleado)
    {
        double valorDia = 50000;
        int diasTrabajados = (DateTime.Now - empleado.FechaIngreso).Days;
        return valorDia * diasTrabajados;
    }

    public int DiasRestantesGarantia(Garantias garantia)
    {
        
        return (garantia.FechaFin - DateTime.Now).Days;
    }

    public decimal descuento(Facturas factura)
    {

        decimal descuento= 0.10m;
        if(factura.Total > 100000m)
        {
            
            return factura.Total - (factura.Total * descuento);

        }
        else
        {
            return 0;
        }

    }

    public decimal CuantoDescuento(Facturas factura)
    {   

        return factura.Total * 0.10m;
    }

    public int EdadCliente(Clientes cliente)
    {
        int edad = DateTime.Now.Year - cliente.Fecha_Nacimiento.Year;
        
        if (DateTime.Now.DayOfYear < cliente.Fecha_Nacimiento.DayOfYear)
        {
            edad = edad - 1;
        }
        return edad;
    }
}

// ======================================================
// ======================================================



public abstract class Personas
{
    public int Id { get; set; }
    public string? Cedula { get; set; }
    public string? Nombre { get; set; }
    public string? Direccion { get; set; }
    public string? Genero { get; set; }
}


public class Empleados : Personas
{
    public int Numero_Banco { get; set; }
    public int Numero_ARL { get; set; }
    public string? Cargo { get; set; }
    public DateTime FechaIngreso { get; set; }
    public bool Activo { get; set; }
    public int ValorDia { get; set;}
    public int DiasTrabajados { get; set; }
    public List<Facturas>? Facturas { get; set; } 
}

public class Clientes : Personas
{
    public string? Correo { get; set; }
    public DateTime Fecha_Nacimiento { get; set; }
    public string? Profesion { get; set; }
    public bool EsMusico { get; set; }
    public string? MarcaFav { get; set; }


    public List<Facturas>? Facturas { get; set; }
    public List<Garantias>? Garantias { get; set; }

}

public class Proveedores
{
    public int Id { get; set; }
    public string? Codigo { get; set; }
    public string? Nombre_Empresa { get; set; }
    public int Telefono { get; set; }
    public string? Correo { get; set; }


    public List<Productos>? Productos { get; set; }
}

public abstract class Productos{
    public int Id { get; set; }
    public string? Codigo { get; set; }
    public string? Nombre { get; set; }
    public decimal Precio { get; set; }

   
    public int ProveedorId { get; set; }
    public Proveedores? _Proveedor { get; set; }


    public List<DetalleFacturas>? Detalles { get; set; }
    public List<Inventarios>? Inventario { get; set; }
    public List<Garantias>? Garantia { get; set; }

}

public class AlbumesClasicos : Productos
{
    public string? Compositor { get; set; }
    public string? Interprete { get; set; }
    public string? Orquesta { get; set; }
    public bool Grabaciones_en_vivo { get; set; }
    public string? Epoca_Musical { get; set;}


}

public class AlbumesPop : Productos
{
    public int Cantidad_Canciones { get; set; }
    public string? Featuring { get; set; }
    public int Nominaciones { get; set; }
    public string? SelloDiscografico { get; set; }
    public int DuracionMinutos { get; set; }
}

public class AlbumesReggaeton : Productos
{
    public bool Explicito { get; set; }
    public string? Idioma { get; set; }
    public string? Productor { get; set; }
    public string? ColabDestacadas { get; set; }
    public string? EstiloReggaeton { get; set; }
}

public class AlbumesRock : Productos
{
    public string? Autor { get; set; }
    public int Año_Lanzamiento { get; set; }
    public string? Sello_Discografico { get; set; }
    public string? SubgeneroRock { get; set; }
    public bool EdicionRemaster { get; set; }
}

public class InstrumentosCuerdas : Productos
{
    public string? Marca { get; set; }
    public string? Color { get; set; }
    public string? Material { get; set; }
    public int CantidadCuerdas { get; set; }
    public bool IncluyeEstuche { get; set; }
}

public class InstrumentosAire : Productos
{
    public string? Tipo { get; set; }
    public int Año_Fabricacion { get; set; }
    public double Peso { get; set; }
    public string? Afinacion { get; set; }
    public string? MaterialBoquilla { get; set; }
}

public class InstrumentosPercusion : Productos
{
    public string? Tipo { get; set; }
    public string? Tamaño { get; set; }
    public double Peso { get; set; }
    public string? MaterialParche { get; set; }
    public bool IncluyeBaquetas { get; set; }
}

public class Bafles : Productos
{
    public string? Tamaño { get; set; }
    public int Decibeles { get; set; }
    public string? Marca { get; set; }
    public int PotenciaWatts { get; set; }
    public bool Bluetooth { get; set; }
}

public class Accesorios : Productos
{
    public string? Tipo { get; set; }
    public string? Color { get; set; }
    public string? Tamaño { get; set; }
    public string? Compatibilidad { get; set; }
    public string? HechoEn { get; set;}
}


public class Facturas
{
    public int Id { get; set; }
    public string? Codigo { get; set; }

    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }

  
    public int ClienteId { get; set; }
    public Clientes? _Cliente { get; set; }

  
    public int EmpleadoId { get; set; }
    public Empleados? _Empleado { get; set; }

  
    public List<DetalleFacturas>? Detalles { get; set; }
    public List<Pagos>? pagos { get; set;}
    public List<Garantias>? Garantias { get; set; }
}

public class DetalleFacturas
{
    public int Id { get; set; }
    public int Cantidad { get; set; }
    public decimal Subtotal { get; set; }

    public decimal PrecioUnitario { get; set; }

 
    public int FacturaId { get; set; }
    public Facturas? _Factura { get; set; }

  
    public int ProductoId { get; set; }
    public Productos? _Producto { get; set; }

}

public class Pagos
{
    public int Id { get; set; }
    public DateTime FechaPago { get; set; }

    public string? Estado { get; set; }
    public int FacturaId { get; set; }
    public Facturas? _factura { get; set; }
    public int MetodoPagoId { get; set; }
    public MetodosPago? _MetodoPago { get; set; }
}

public class MetodosPago
{
    public int Id { get; set; }
    public int NumCuotas { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public bool Activo { get; set; }
    public List<Pagos>? pago { get; set; }
}

public class Inventarios
{
    public int Id { get; set; }
    public int StockDisponible { get; set; }
    public DateTime FechaActualizacion { get; set; }
    public string? UbicacionBodega { get; set; }
    public int ProductoId { get; set; }
    public Productos? _Producto { get; set; }}

public class Garantias
{
    public int Id { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public string? Estado { get; set; } 
    public String? DescripcionDaño { get; set; }
    public int FacturaId { get; set; }
    public Facturas? _Factura { get; set; }
    public int ProductosId { get; set; } 
    public Productos? _Producto { get; set; }
    public int ClientesId { get; set; }
    public Clientes? _Cliente { get; set; }
}