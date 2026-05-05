-- =============================================
-- 1. CREACIÓN DE BASE DE DATOS
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'FarmaciaDB')
BEGIN
    CREATE DATABASE FarmaciaDB;
END
GO

USE FarmaciaDB;
GO

-- =============================================
-- 2. ESQUEMA Y SEGURIDAD INICIAL
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'farm')
BEGIN
    EXEC('CREATE SCHEMA farm');
END
GO
-- =============================================
-- 3. TABLAS MAESTRAS (Nivel 0)
-- =============================================
CREATE TABLE farm.categoria (
    idcategoria INT IDENTITY(1,1) PRIMARY KEY,
    nombre_categoria NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(200),
    fecha_creacion DATETIME2 DEFAULT SYSUTCDATETIME()
);

CREATE TABLE farm.marca (
    idmarca INT IDENTITY(1,1) PRIMARY KEY,
    nombre_marca NVARCHAR(100) NOT NULL,
    fecha_creacion DATETIME2 DEFAULT SYSUTCDATETIME()
);

CREATE TABLE farm.unidad_medida (
    idunidad_medida INT IDENTITY(1,1) PRIMARY KEY,
    nombre_unidad NVARCHAR(50) NOT NULL,
    abreviatura NVARCHAR(10)
);

CREATE TABLE farm.cargo (
    idcargo INT IDENTITY(1,1) PRIMARY KEY,
    nombre_cargo NVARCHAR(50) NOT NULL UNIQUE
);

-- =============================================
-- 4. ENTIDADES DE PERSONAS
-- =============================================
CREATE TABLE farm.proveedor (
    idproveedor INT IDENTITY(1,1) PRIMARY KEY,
    nombre_proveedor NVARCHAR(100) NOT NULL,
    ruc CHAR(11) NOT NULL UNIQUE,
    direccion NVARCHAR(255),
    telefono NVARCHAR(15),
    correo NVARCHAR(100)
);

CREATE TABLE farm.empleado (
    idempleado INT IDENTITY(1,1) PRIMARY KEY,
    nombres NVARCHAR(100) NOT NULL,
    apellidos NVARCHAR(100) NOT NULL,
    idcargo INT NOT NULL, -- Relacionado con tabla cargo
    telefono NVARCHAR(15),
    correo NVARCHAR(100),
    sueldo DECIMAL(10,2) NOT NULL CHECK (sueldo >= 0),
    fecha_contrato DATE NOT NULL,
    CONSTRAINT fk_empleado_cargo FOREIGN KEY (idcargo) REFERENCES farm.cargo(idcargo)
);

CREATE TABLE farm.cliente (
    idcliente INT IDENTITY(1,1) PRIMARY KEY,
    nombres NVARCHAR(100) NOT NULL,
    apellidos NVARCHAR(100) NOT NULL, -- Corregido typo 'pellidos'
    dni CHAR(8) NOT NULL UNIQUE,
    direccion NVARCHAR(255),
    telefono NVARCHAR(15)
);

-- =============================================
-- 5. PRODUCTOS E INVENTARIO
-- =============================================
CREATE TABLE farm.producto (
    idproducto INT IDENTITY(1,1) PRIMARY KEY,
    nombre_producto NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(255),
    precio_venta DECIMAL(10,2) NOT NULL CHECK (precio_venta > 0),
    stock_actual INT NOT NULL DEFAULT 0 CHECK (stock_actual >= 0),
    fecha_vencimiento DATE,
    laboratorio NVARCHAR(100),
    estado BIT DEFAULT 1,
    idcategoria INT,
    idmarca INT,
    idunidad_medida INT,
    CONSTRAINT fk_producto_categoria FOREIGN KEY (idcategoria) REFERENCES farm.categoria(idcategoria),
    CONSTRAINT fk_producto_marca FOREIGN KEY (idmarca) REFERENCES farm.marca(idmarca),
    CONSTRAINT fk_producto_unidad FOREIGN KEY (idunidad_medida) REFERENCES farm.unidad_medida(idunidad_medida)
);

CREATE TABLE farm.almacen (
    idalmacen INT IDENTITY(1,1) PRIMARY KEY,
    nombre_almacen NVARCHAR(100) NOT NULL,
    ubicacion NVARCHAR(255),
    capacidad_max INT CHECK (capacidad_max >= 0)
);

CREATE TABLE farm.inventario (
    idinventario INT IDENTITY(1,1) PRIMARY KEY,
    idalmacen INT NOT NULL,
    idproducto INT NOT NULL,
    cantidad INT NOT NULL CHECK (cantidad >= 0),
    stock_minimo INT NOT NULL DEFAULT 5,
    stock_maximo INT NOT NULL,
    fecha_actualizacion DATETIME2 DEFAULT SYSUTCDATETIME(),
    CONSTRAINT fk_inventario_almacen FOREIGN KEY (idalmacen) REFERENCES farm.almacen(idalmacen),
    CONSTRAINT fk_inventario_producto FOREIGN KEY (idproducto) REFERENCES farm.producto(idproducto)
);

-- =============================================
-- 6. PROCESO DE COMPRAS
-- =============================================
CREATE TABLE farm.compra (
    idcompra INT IDENTITY(1,1) PRIMARY KEY,
    idproveedor INT NOT NULL,
    idempleado INT NOT NULL,
    fecha_compra DATETIME2 DEFAULT SYSUTCDATETIME(),
    numero_factura NVARCHAR(20) NOT NULL,
    total_compra DECIMAL(10,2) NOT NULL DEFAULT 0,
    estado BIT DEFAULT 1,
    CONSTRAINT fk_compra_proveedor FOREIGN KEY (idproveedor) REFERENCES farm.proveedor(idproveedor),
    CONSTRAINT fk_compra_empleado FOREIGN KEY (idempleado) REFERENCES farm.empleado(idempleado)
);

CREATE TABLE farm.detalle_compra (
    iddetalle_compra INT IDENTITY(1,1) PRIMARY KEY,
    idcompra INT NOT NULL,
    idproducto INT NOT NULL,
    cantidad INT NOT NULL CHECK (cantidad > 0),
    precio_compra DECIMAL(10,2) NOT NULL CHECK (precio_compra > 0),
    subtotal AS (cantidad * precio_compra) PERSISTED,
    CONSTRAINT fk_detallecompra_compra FOREIGN KEY (idcompra) REFERENCES farm.compra(idcompra),
    CONSTRAINT fk_detallecompra_producto FOREIGN KEY (idproducto) REFERENCES farm.producto(idproducto)
);
-- =============================================
-- 7. PROCESO DE VENTAS Y PAGOS
-- =============================================
CREATE TABLE farm.venta (
    idventa INT IDENTITY(1,1) PRIMARY KEY,
    idcliente INT NOT NULL,
    idempleado INT NOT NULL,
    fecha_venta DATETIME2 DEFAULT SYSUTCDATETIME(),
    tipo_comprobante NVARCHAR(50) NOT NULL, -- Boleta, Factura
    total_venta DECIMAL(10,2) NOT NULL DEFAULT 0 CHECK (total_venta >= 0),
    estado_pago NVARCHAR(20) DEFAULT 'Pendiente', -- Pendiente, Pagado, Anulado
    CONSTRAINT fk_venta_cliente FOREIGN KEY (idcliente) REFERENCES farm.cliente(idcliente),
    CONSTRAINT fk_venta_empleado FOREIGN KEY (idempleado) REFERENCES farm.empleado(idempleado)
);
CREATE TABLE farm.detalle_venta (
    iddetalle_venta INT IDENTITY(1,1) PRIMARY KEY,
    idventa INT NOT NULL,
    idproducto INT NOT NULL,
    cantidad INT NOT NULL CHECK (cantidad > 0),
    precio_unitario DECIMAL(10,2) NOT NULL,
    subtotal AS (cantidad * precio_unitario) PERSISTED,
    CONSTRAINT fk_detalleventa_venta FOREIGN KEY (idventa) REFERENCES farm.venta(idventa),
    CONSTRAINT fk_detalleventa_producto FOREIGN KEY (idproducto) REFERENCES farm.producto(idproducto)
);

-- NUEVA TABLA: PAGO
CREATE TABLE farm.pago (
    idpago INT IDENTITY(1,1) PRIMARY KEY,
    idventa INT NOT NULL,
    fecha_pago DATETIME2 DEFAULT SYSUTCDATETIME(),
    metodo_pago NVARCHAR(50) NOT NULL, -- Efectivo, Tarjeta, Yape/Plin
    monto_pagado DECIMAL(10,2) NOT NULL CHECK (monto_pagado > 0),
    referencia_operacion NVARCHAR(100), -- Nro de operación bancaria
    CONSTRAINT fk_pago_venta FOREIGN KEY (idventa) REFERENCES farm.venta(idventa)
);

-- =============================================
-- 8. SEGURIDAD DE USUARIOS
-- =============================================
CREATE TABLE farm.usuario (
    idusuario INT IDENTITY(1,1) PRIMARY KEY,
    idempleado INT NOT NULL UNIQUE,
    username NVARCHAR(20) NOT NULL UNIQUE,
    password_hash VARBINARY(256) NOT NULL,
    estado BIT DEFAULT 1,
    ultimo_acceso DATETIME2,
    CONSTRAINT fk_usuario_empleado FOREIGN KEY (idempleado) REFERENCES farm.empleado(idempleado)
);
GO