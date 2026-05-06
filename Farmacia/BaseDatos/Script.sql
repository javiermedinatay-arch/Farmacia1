-- =============================================
-- 1. CREACIÓN DE LA BASE DE DATOS
-- =============================================
USE master;
GO

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'FarmaciaDB')
BEGIN
    ALTER DATABASE FarmaciaDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE FarmaciaDB;
END
GO

CREATE DATABASE FarmaciaDB;
GO

USE FarmaciaDB;
GO

CREATE SCHEMA farm;
GO

-- =============================================
-- 2. TABLAS MAESTRAS (Nivel 0)
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
-- 3. PERSONAS (CLIENTES Y EMPLEADOS)
-- =============================================
CREATE TABLE farm.cliente (
    idcliente INT IDENTITY(1,1) PRIMARY KEY,
    nombres NVARCHAR(100) NOT NULL,
    apellidos NVARCHAR(100) NOT NULL,
    dni CHAR(8) NOT NULL UNIQUE,
    direccion NVARCHAR(255),
    telefono NVARCHAR(15)
);

CREATE TABLE farm.empleado (
    idempleado INT IDENTITY(1,1) PRIMARY KEY,
    nombres NVARCHAR(100) NOT NULL,
    apellidos NVARCHAR(100) NOT NULL,
    idcargo INT NOT NULL,
    telefono NVARCHAR(15),
    correo NVARCHAR(100),
    sueldo DECIMAL(10,2) NOT NULL CHECK (sueldo >= 0),
    fecha_contrato DATE NOT NULL,
    CONSTRAINT fk_empleado_cargo FOREIGN KEY (idcargo) REFERENCES farm.cargo(idcargo)
);

-- =============================================
-- 4. PRODUCTOS E INVENTARIO
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
    idcategoria INT REFERENCES farm.categoria(idcategoria),
    idmarca INT REFERENCES farm.marca(idmarca),
    idunidad_medida INT REFERENCES farm.unidad_medida(idunidad_medida)
);

-- =============================================
-- 5. VENTAS Y PAGOS
-- =============================================
CREATE TABLE farm.venta (
    idventa INT IDENTITY(1,1) PRIMARY KEY,
    idcliente INT NOT NULL REFERENCES farm.cliente(idcliente),
    idempleado INT NOT NULL REFERENCES farm.empleado(idempleado),
    fecha_venta DATETIME2 DEFAULT SYSUTCDATETIME(),
    tipo_comprobante NVARCHAR(50) NOT NULL,
    total_venta DECIMAL(10,2) NOT NULL DEFAULT 0,
    estado_pago NVARCHAR(20) DEFAULT 'Pagado'
);

CREATE TABLE farm.detalle_venta (
    iddetalle_venta INT IDENTITY(1,1) PRIMARY KEY,
    idventa INT NOT NULL REFERENCES farm.venta(idventa),
    idproducto INT NOT NULL REFERENCES farm.producto(idproducto),
    cantidad INT NOT NULL CHECK (cantidad > 0),
    precio_unitario DECIMAL(10,2) NOT NULL,
    subtotal AS (cantidad * precio_unitario) PERSISTED
);

CREATE TABLE farm.pago (
    idpago INT IDENTITY(1,1) PRIMARY KEY,
    idventa INT NOT NULL REFERENCES farm.venta(idventa),
    fecha_pago DATETIME2 DEFAULT SYSUTCDATETIME(),
    metodo_pago NVARCHAR(50) NOT NULL,
    monto_pagado DECIMAL(10,2) NOT NULL CHECK (monto_pagado > 0),
    referencia_operacion NVARCHAR(100)
);
GO