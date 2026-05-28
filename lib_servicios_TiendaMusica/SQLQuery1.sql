

CREATE DATABASE proyecto_TiendaMusica_Software
GO
USE proyecto_TiendaMusica_Software
GO



CREATE TABLE Personas (
    Id        INT           IDENTITY(1,1) PRIMARY KEY,
    Cedula    VARCHAR(50)   NOT NULL,
    Nombre    VARCHAR(100)  NOT NULL,
    Direccion VARCHAR(150)  NOT NULL,
    Genero    VARCHAR(20)   NOT NULL
);

CREATE TABLE Empleados (
    Id             INT          PRIMARY KEY,
    Numero_Banco   VARCHAR(10)  NOT NULL,
    Numero_ARL     VARCHAR(15)  NOT NULL,
    Cargo          VARCHAR(100) NOT NULL,
    FechaIngreso   DATETIME2    NOT NULL,
    Activo         BIT          NOT NULL,
    ValorDia       INT          NOT NULL,
    DiasTrabajados INT          NOT NULL,
    FOREIGN KEY (Id) REFERENCES Personas(Id)
);

CREATE TABLE Clientes (
    Id               INT          PRIMARY KEY,
    Correo           VARCHAR(100) NOT NULL,
    Fecha_Nacimiento DATETIME2    NOT NULL,
    Profesion        VARCHAR(100) NOT NULL,
    EsMusico         BIT          NOT NULL,
    MarcaFav         VARCHAR(100) NOT NULL,
    FOREIGN KEY (Id) REFERENCES Personas(Id)
);


CREATE TABLE Proveedores (
    Id             INT          IDENTITY(1,1) PRIMARY KEY,
    Codigo         VARCHAR(50)  NOT NULL,
    Nombre_Empresa VARCHAR(100) NOT NULL,
    Telefono       VARCHAR(20)  NOT NULL,
    Correo         VARCHAR(100) NOT NULL
);



CREATE TABLE Productos (
    Id          INT           IDENTITY(1,1) PRIMARY KEY,
    Codigo      VARCHAR(50)   NOT NULL,
    Nombre      VARCHAR(100)  NOT NULL,
    Precio      DECIMAL(10,2) NOT NULL,
    ProveedorId INT           NOT NULL,
    FOREIGN KEY (ProveedorId) REFERENCES Proveedores(Id)
);



CREATE TABLE AlbumesClasicos (
    Id                  INT          PRIMARY KEY,
    Compositor          VARCHAR(100) NOT NULL,
    Interprete          VARCHAR(100) NOT NULL,
    Orquesta            VARCHAR(100) NOT NULL,
    Grabaciones_en_vivo BIT          NOT NULL,
    Epoca_Musical       VARCHAR(100) NOT NULL,
    FOREIGN KEY (Id) REFERENCES Productos(Id)
);

CREATE TABLE AlbumesPop (
    Id                 INT          PRIMARY KEY,
    Cantidad_Canciones INT          NOT NULL,
    Featuring          VARCHAR(100) NOT NULL,
    Nominaciones       INT          NOT NULL,
    SelloDiscografico  VARCHAR(100) NOT NULL,
    DuracionMinutos    INT          NOT NULL,
    FOREIGN KEY (Id) REFERENCES Productos(Id)
);

CREATE TABLE AlbumesReggaeton (
    Id              INT          PRIMARY KEY,
    Explicito       BIT          NOT NULL,
    Idioma          VARCHAR(50)  NOT NULL,
    Productor       VARCHAR(100) NOT NULL,
    ColabDestacadas VARCHAR(100) NOT NULL,
    EstiloReggaeton VARCHAR(100) NOT NULL,
    FOREIGN KEY (Id) REFERENCES Productos(Id)
);

CREATE TABLE AlbumesRock (
    Id                 INT          PRIMARY KEY,
    Autor              VARCHAR(100) NOT NULL,
    Año_Lanzamiento    INT          NOT NULL,   
    Sello_Discografico VARCHAR(100) NOT NULL,
    SubgeneroRock      VARCHAR(100) NOT NULL,
    EdicionRemaster    BIT          NOT NULL,
    FOREIGN KEY (Id) REFERENCES Productos(Id)
);

CREATE TABLE InstrumentosCuerdas (
    Id              INT          PRIMARY KEY,
    Marca           VARCHAR(100) NOT NULL,
    Color           VARCHAR(50)  NOT NULL,
    Material        VARCHAR(100) NOT NULL,
    CantidadCuerdas INT          NOT NULL,
    IncluyeEstuche  BIT          NOT NULL,
    FOREIGN KEY (Id) REFERENCES Productos(Id)
);

CREATE TABLE InstrumentosAire (
    Id               INT           PRIMARY KEY,
    Tipo             VARCHAR(100)  NOT NULL,
    Año_Fabricacion  INT           NOT NULL,    
    Peso             DECIMAL(8,2)  NOT NULL,
    Afinacion        VARCHAR(50)   NOT NULL,
    MaterialBoquilla VARCHAR(100)  NOT NULL,
    FOREIGN KEY (Id) REFERENCES Productos(Id)
);

CREATE TABLE InstrumentosPercusion (
    Id              INT           PRIMARY KEY,
    Tipo            VARCHAR(100)  NOT NULL,
    Tamaño          VARCHAR(50)   NOT NULL,
    Peso            DECIMAL(8,2)  NOT NULL,
    MaterialParche  VARCHAR(100)  NOT NULL,
    IncluyeBaquetas BIT           NOT NULL,
    FOREIGN KEY (Id) REFERENCES Productos(Id)
);

CREATE TABLE Bafles (
    Id            INT          PRIMARY KEY,
    Tamaño        VARCHAR(50)  NOT NULL,
    Decibeles     INT          NOT NULL,
    Marca         VARCHAR(100) NOT NULL,
    PotenciaWatts INT          NOT NULL,
    Bluetooth     BIT          NOT NULL,
    FOREIGN KEY (Id) REFERENCES Productos(Id)
);

CREATE TABLE Accesorios (
    Id             INT          PRIMARY KEY,
    Tipo           VARCHAR(100) NOT NULL,
    Color          VARCHAR(50)  NOT NULL,
    Tamaño         VARCHAR(50)  NOT NULL,
    Compatibilidad VARCHAR(100) NOT NULL,
    HechoEn        VARCHAR(100) NOT NULL,
    FOREIGN KEY (Id) REFERENCES Productos(Id)
);



CREATE TABLE MetodosPago (
    Id          INT          IDENTITY(1,1) PRIMARY KEY,
    NumCuotas   INT          NOT NULL,
    Nombre      VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(150) NOT NULL,
    Activo      BIT          NOT NULL
);

CREATE TABLE Facturas (
    Id         INT           IDENTITY(1,1) PRIMARY KEY,
    Codigo     VARCHAR(50)   NOT NULL,
    Fecha      DATETIME2     NOT NULL,
    Total      DECIMAL(10,2) NOT NULL,
    ClienteId  INT           NOT NULL,
    EmpleadoId INT           NOT NULL,
    FOREIGN KEY (ClienteId)  REFERENCES Clientes(Id),
    FOREIGN KEY (EmpleadoId) REFERENCES Empleados(Id)
);

CREATE TABLE DetalleFacturas (
    Id             INT           IDENTITY(1,1) PRIMARY KEY,
    Cantidad       INT           NOT NULL,
    Subtotal       DECIMAL(10,2) NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    FacturaId      INT           NOT NULL,
    ProductoId     INT           NOT NULL,
    FOREIGN KEY (FacturaId)  REFERENCES Facturas(Id),
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
);

CREATE TABLE Pagos (
    Id           INT           IDENTITY(1,1) PRIMARY KEY,
    FechaPago    DATETIME2     NOT NULL,
    Estado       VARCHAR(50)   NOT NULL,
    FacturaId    INT           NOT NULL,
    MetodoPagoId INT           NOT NULL,
    FOREIGN KEY (FacturaId)    REFERENCES Facturas(Id),
    FOREIGN KEY (MetodoPagoId) REFERENCES MetodosPago(Id)
);



CREATE TABLE Inventarios (
    Id                 INT          IDENTITY(1,1) PRIMARY KEY,
    StockDisponible    INT          NOT NULL,
    FechaActualizacion DATETIME2    NOT NULL,
    UbicacionBodega    VARCHAR(100) NOT NULL,
    ProductoId         INT          NOT NULL,
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
);

CREATE TABLE Garantias (
    Id              INT          IDENTITY(1,1) PRIMARY KEY,
    FechaInicio     DATETIME2    NOT NULL,
    FechaFin        DATETIME2    NOT NULL,
    Estado          VARCHAR(50)  NOT NULL,
    DescripcionDano VARCHAR(150) NOT NULL,  
    FacturaId       INT          NOT NULL,
    ProductoId      INT          NOT NULL,
    ClienteId       INT          NOT NULL,
    FOREIGN KEY (FacturaId)  REFERENCES Facturas(Id),
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id),
    FOREIGN KEY (ClienteId)  REFERENCES Clientes(Id)
);

CREATE TABLE Reseñas (
    Id           INT           IDENTITY(1,1) PRIMARY KEY,
    Calificacion INT           NOT NULL,
    Comentario   VARCHAR(300)  NOT NULL,
    FechaReseña  DATETIME2     NOT NULL,
    Verificada   BIT           NOT NULL,
    Titulo       VARCHAR(150)  NOT NULL,
    ClienteId    INT           NOT NULL,
    ProductoId   INT           NOT NULL,
    FOREIGN KEY (ClienteId)  REFERENCES Clientes(Id),
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
);

CREATE TABLE Reparaciones (
    Id           INT           IDENTITY(1,1) PRIMARY KEY,
    Descripcion  VARCHAR(300)  NOT NULL,
    FechaIngreso DATETIME2     NOT NULL,
    FechaEntrega DATETIME2     NOT NULL,
    Costo        DECIMAL(10,2) NOT NULL,
    Estado       VARCHAR(50)   NOT NULL,
    ClienteId    INT           NOT NULL,
    EmpleadoId   INT           NOT NULL,
    ProductoId   INT           NULL,
    FOREIGN KEY (ClienteId)  REFERENCES Clientes(Id),
    FOREIGN KEY (EmpleadoId) REFERENCES Empleados(Id),
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
);



CREATE TABLE Roles (
    Id     INT          IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50)  NOT NULL,
    Activo BIT          NOT NULL
);

CREATE TABLE Usuarios (
    Id            INT           IDENTITY(1,1) PRIMARY KEY,
    Username      VARCHAR(50)   NOT NULL UNIQUE,
    Password      VARCHAR(255)  NOT NULL,
    Activo        BIT           NOT NULL,
    FechaCreacion DATETIME2     NOT NULL,
    EmpleadoId    INT           NULL,
    FOREIGN KEY (EmpleadoId) REFERENCES Empleados(Id)
);

CREATE TABLE UsuarioRoles (
    UsuarioId INT NOT NULL,
    RolId     INT NOT NULL,
    PRIMARY KEY (UsuarioId, RolId),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id),
    FOREIGN KEY (RolId)     REFERENCES Roles(Id)
);

CREATE TABLE Auditorias (
    Id          INT           IDENTITY(1,1) PRIMARY KEY,
    Entidad     VARCHAR(100)  NOT NULL,
    Accion      VARCHAR(20)   NOT NULL,
    Descripcion VARCHAR(500)  NOT NULL,
    Fecha       DATETIME2     NOT NULL,
    UsuarioId   INT           NULL,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);
GO



INSERT INTO Roles (Nombre, Activo) VALUES ('Administrador', 1);
INSERT INTO Roles (Nombre, Activo) VALUES ('Vendedor',      1);
INSERT INTO Roles (Nombre, Activo) VALUES ('Bodeguero',     1);
INSERT INTO Roles (Nombre, Activo) VALUES ('Soporte',       1);
INSERT INTO Roles (Nombre, Activo) VALUES ('Cliente',       1);


INSERT INTO MetodosPago (NumCuotas, Nombre, Descripcion, Activo)
    VALUES (1,  'Efectivo',        'Pago en efectivo de contado',              1);
INSERT INTO MetodosPago (NumCuotas, Nombre, Descripcion, Activo)
    VALUES (1,  'Tarjeta Debito',  'Pago con tarjeta debito',                  1);
INSERT INTO MetodosPago (NumCuotas, Nombre, Descripcion, Activo)
    VALUES (12, 'Tarjeta Credito', 'Pago con tarjeta credito hasta 12 cuotas', 1);
INSERT INTO MetodosPago (NumCuotas, Nombre, Descripcion, Activo)
    VALUES (1,  'Transferencia',   'Transferencia bancaria',                   1);


INSERT INTO Proveedores (Codigo, Nombre_Empresa, Telefono, Correo) VALUES
('PROV-001', 'Sony Music Colombia',    '3001234567', 'ventas@sonymusic.com.co'),
('PROV-002', 'Gibson Instruments',     '3109876543', 'colombia@gibson.com'),
('PROV-003', 'Yamaha Colombia',        '3207654321', 'ventas@yamaha.com.co'),
('PROV-004', 'Universal Music Group',  '3156789012', 'comercial@universal.com.co'),
('PROV-005', 'Fender Latin America',   '3004567890', 'ventas@fender.com.co');
GO




INSERT INTO Productos (Codigo, Nombre, Precio, ProveedorId) VALUES
('ALB-CL-001', 'La Novena Sinfonia',        85000.00, 1),
('ALB-CL-002', 'Las Cuatro Estaciones',     75000.00, 1),
('ALB-CL-003', 'Requiem en Re Menor',       90000.00, 4);

INSERT INTO AlbumesClasicos (Id, Compositor, Interprete, Orquesta, Grabaciones_en_vivo, Epoca_Musical) VALUES
(1, 'Ludwig van Beethoven', 'Herbert von Karajan', 'Filarmonica de Berlin',  0, 'Romanticismo'),
(2, 'Antonio Vivaldi',      'Itzhak Perlman',      'Israel Philharmonic',    1, 'Barroco'),
(3, 'Wolfgang Mozart',      'Karl Bohm',            'Filarmonica de Viena',  0, 'Clasicismo');


INSERT INTO Productos (Codigo, Nombre, Precio, ProveedorId) VALUES
('ALB-POP-001', 'Midnights',       120000.00, 4),
('ALB-POP-002', 'Renaissance',     115000.00, 1),
('ALB-POP-003', 'Harrys House',    110000.00, 4);

INSERT INTO AlbumesPop (Id, Cantidad_Canciones, Featuring, Nominaciones, SelloDiscografico, DuracionMinutos) VALUES
(4, 13, 'Lana Del Rey', 13, 'Republic Records', 44),
(5, 16, 'Jay-Z',        32, 'Columbia Records', 55),
(6, 13, 'Kid Harpoon',  10, 'Columbia Records', 42);


INSERT INTO Productos (Codigo, Nombre, Precio, ProveedorId) VALUES
('ALB-REG-001', 'El Ultimo Tour del Mundo', 95000.00, 1),
('ALB-REG-002', 'Jose',                     90000.00, 4),
('ALB-REG-003', 'Legendaddy',               88000.00, 4);

INSERT INTO AlbumesReggaeton (Id, Explicito, Idioma, Productor, ColabDestacadas, EstiloReggaeton) VALUES
(7,  1, 'Español', 'MAG',         'Drake, Ed Sheeran', 'Trap Latino'),
(8,  1, 'Español', 'Tainy',       'Myke Towers',       'Reggaeton Moderno'),
(9,  0, 'Español', 'Daddy Yankee','Ozuna, Bad Bunny',  'Reggaeton Clasico');


INSERT INTO Productos (Codigo, Nombre, Precio, ProveedorId) VALUES
('ALB-ROC-001', 'Back in Black',               105000.00, 4),
('ALB-ROC-002', 'Rumours',                     100000.00, 4),
('ALB-ROC-003', 'The Dark Side of the Moon',   110000.00, 4);

INSERT INTO AlbumesRock (Id, Autor, Año_Lanzamiento, Sello_Discografico, SubgeneroRock, EdicionRemaster) VALUES
(10, 'AC/DC',         1980, 'Atlantic Records', 'Hard Rock',       1),
(11, 'Fleetwood Mac', 1977, 'Warner Bros',      'Soft Rock',       1),
(12, 'Pink Floyd',    1973, 'Harvest Records',  'Rock Progresivo', 1);


INSERT INTO Productos (Codigo, Nombre, Precio, ProveedorId) VALUES
('INST-CU-001', 'Guitarra Fender Stratocaster', 4500000.00, 5),
('INST-CU-002', 'Guitarra Gibson Les Paul',     5200000.00, 2),
('INST-CU-003', 'Bajo Fender Jazz Bass',        3800000.00, 5);

INSERT INTO InstrumentosCuerdas (Id, Marca, Color, Material, CantidadCuerdas, IncluyeEstuche) VALUES
(13, 'Fender', 'Sunburst', 'Aliso', 6, 1),
(14, 'Gibson', 'Cherry',   'Caoba', 6, 1),
(15, 'Fender', 'Negro',    'Aliso', 4, 0);

INSERT INTO Productos (Codigo, Nombre, Precio, ProveedorId) VALUES
('INST-AI-001', 'Saxofon Alto Yamaha',        2800000.00, 3),
('INST-AI-002', 'Trompeta Bach Stradivarius', 3200000.00, 3),
('INST-AI-003', 'Flauta Traversa Pearl',      1500000.00, 3);

INSERT INTO InstrumentosAire (Id, Tipo, Año_Fabricacion, Peso, Afinacion, MaterialBoquilla) VALUES
(16, 'Saxofon',  2022, 1.20, 'Mi Bemol', 'Metal dorado'),
(17, 'Trompeta', 2021, 1.10, 'Si Bemol', 'Metal plateado'),
(18, 'Flauta',   2023, 0.45, 'Do',       'Plata de ley');


INSERT INTO Productos (Codigo, Nombre, Precio, ProveedorId) VALUES
('INST-PE-001', 'Bateria Pearl Export', 4200000.00, 3),
('INST-PE-002', 'Cajon Flamenco Meinl',  350000.00, 3),
('INST-PE-003', 'Congas LP Aspire',      890000.00, 3);

INSERT INTO InstrumentosPercusion (Id, Tipo, Tamaño, Peso, MaterialParche, IncluyeBaquetas) VALUES
(19, 'Bateria', 'Completa', 35.00, 'Remo Ambassador', 1),
(20, 'Cajon',   'Mediano',   5.50, 'Abeto',           0),
(21, 'Congas',  'Par',       8.20, 'Cuero natural',   0);


INSERT INTO Productos (Codigo, Nombre, Precio, ProveedorId) VALUES
('BAF-001', 'Bafle JBL EON615',    1800000.00, 1),
('BAF-002', 'Bafle QSC K12.2',     2400000.00, 1),
('BAF-003', 'Bafle Yamaha DBR15',  1650000.00, 3);

INSERT INTO Bafles (Id, Tamaño, Decibeles, Marca, PotenciaWatts, Bluetooth) VALUES
(22, '15 pulgadas', 132, 'JBL',    1000, 0),
(23, '12 pulgadas', 131, 'QSC',    2000, 0),
(24, '15 pulgadas', 132, 'Yamaha',  800, 1);


INSERT INTO Productos (Codigo, Nombre, Precio, ProveedorId) VALUES
('ACC-001', 'Correa Levys Cuero',  180000.00, 2),
('ACC-002', 'Pedal Boss DS-1',     320000.00, 3),
('ACC-003', 'Afinador Korg CA-50',  85000.00, 3);

INSERT INTO Accesorios (Id, Tipo, Color, Tamaño, Compatibilidad, HechoEn) VALUES
(25, 'Correa',   'Cafe',   'Universal', 'Guitarra, Bajo',         'Canada'),
(26, 'Pedal',    'Naranja','Estandar',  'Guitarra electrica',     'Japon'),
(27, 'Afinador', 'Negro',  'Compacto',  'Todos los instrumentos', 'Japon');
GO



INSERT INTO Inventarios (StockDisponible, FechaActualizacion, UbicacionBodega, ProductoId) VALUES
(15, GETDATE(), 'Estante A-1', 1),
(12, GETDATE(), 'Estante A-1', 2),
(10, GETDATE(), 'Estante A-1', 3),
(20, GETDATE(), 'Estante A-2', 4),
(18, GETDATE(), 'Estante A-2', 5),
(15, GETDATE(), 'Estante A-2', 6),
(25, GETDATE(), 'Estante A-3', 7),
(22, GETDATE(), 'Estante A-3', 8),
(20, GETDATE(), 'Estante A-3', 9),
(14, GETDATE(), 'Estante A-4', 10),
(12, GETDATE(), 'Estante A-4', 11),
(10, GETDATE(), 'Estante A-4', 12),
(5,  GETDATE(), 'Vitrina B-1', 13),
(3,  GETDATE(), 'Vitrina B-1', 14),
(4,  GETDATE(), 'Vitrina B-1', 15),
(6,  GETDATE(), 'Vitrina B-2', 16),
(4,  GETDATE(), 'Vitrina B-2', 17),
(8,  GETDATE(), 'Vitrina B-2', 18),
(3,  GETDATE(), 'Bodega C-1',  19),
(10, GETDATE(), 'Bodega C-1',  20),
(6,  GETDATE(), 'Bodega C-1',  21),
(4,  GETDATE(), 'Bodega C-2',  22),
(3,  GETDATE(), 'Bodega C-2',  23),
(5,  GETDATE(), 'Bodega C-2',  24),
(30, GETDATE(), 'Estante D-1', 25),
(15, GETDATE(), 'Estante D-1', 26),
(25, GETDATE(), 'Estante D-1', 27);
GO



INSERT INTO Personas (Cedula, Nombre, Direccion, Genero)
VALUES ('1000000001', 'Administrador Sistema', 'Aurum Sound HQ', 'Masculino');


INSERT INTO Empleados (Id, Numero_Banco, Numero_ARL, Cargo, FechaIngreso,
                       Activo, ValorDia, DiasTrabajados)
VALUES (1, '0000000001', 'ARL-00001', 'Administrador',
        GETDATE(), 1, 100000, 0);


INSERT INTO Usuarios (Username, Password, Activo, FechaCreacion, EmpleadoId)
VALUES ('admin', '123456', 1, GETDATE(), 1);


INSERT INTO UsuarioRoles (UsuarioId, RolId) VALUES (1, 1);
GO