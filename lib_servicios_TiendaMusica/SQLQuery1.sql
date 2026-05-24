

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
    Año_Lanzamiento    SMALLINT     NOT NULL,
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
    Año_Fabricacion  SMALLINT      NOT NULL,
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


INSERT INTO Roles (Nombre, Activo) VALUES ('Administrador', 1);
INSERT INTO Roles (Nombre, Activo) VALUES ('Vendedor',      1);
INSERT INTO Roles (Nombre, Activo) VALUES ('Bodeguero',     1);
INSERT INTO Roles (Nombre, Activo) VALUES ('Soporte',       1);


INSERT INTO MetodosPago (NumCuotas, Nombre, Descripcion, Activo)
    VALUES (1,  'Efectivo',        'Pago en efectivo de contado',              1);
INSERT INTO MetodosPago (NumCuotas, Nombre, Descripcion, Activo)
    VALUES (1,  'Tarjeta Debito',  'Pago con tarjeta debito',                  1);
INSERT INTO MetodosPago (NumCuotas, Nombre, Descripcion, Activo)
    VALUES (12, 'Tarjeta Credito', 'Pago con tarjeta credito hasta 12 cuotas', 1);
INSERT INTO MetodosPago (NumCuotas, Nombre, Descripcion, Activo)
    VALUES (1,  'Transferencia',   'Transferencia bancaria',                   1);