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

-- =============================================
-- 6. OBJETOS DE PROGRAMACIÓN (TIPOS Y VISTAS)
-- =============================================

-- Tipo de tabla para el carrito de compras desde C#
CREATE TYPE farm.DetalleVentaType AS TABLE (
    idproducto INT,
    cantidad INT,
    precio_unitario DECIMAL(10,2)
);
GO

-- Vista para el ComboBox de Productos
CREATE VIEW farm.vw_ListarProductos AS
SELECT idproducto, nombre_producto, precio_venta, stock_actual, laboratorio 
FROM farm.producto WHERE estado = 1;
GO

-- Vista para el ComboBox de Clientes
CREATE VIEW farm.vw_ListarClientes AS
SELECT idcliente, (nombres + ' ' + apellidos) AS nombre_completo, dni FROM farm.cliente;
GO

-- Vista para el Historial de Ventas (Botón Detalle)
CREATE VIEW farm.vw_ResumenVentas AS
SELECT 
    V.idventa AS [Nro Venta],
    V.fecha_venta,
    (C.nombres + ' ' + C.apellidos) AS [Cliente],
    (E.nombres + ' ' + E.apellidos) AS [Empleado],
    V.tipo_comprobante AS [Documento],
    V.total_venta AS [Total],
    P.metodo_pago AS [Pago]
FROM farm.venta V
INNER JOIN farm.cliente C ON V.idcliente = C.idcliente
INNER JOIN farm.empleado E ON V.idempleado = E.idempleado
INNER JOIN farm.pago P ON V.idventa = P.idventa;
GO

-- =============================================
-- 7. PROCEDIMIENTOS ALMACENADOS
-- =============================================

CREATE PROCEDURE farm.usp_RegistrarVentaCompleta
    @idcliente INT,
    @idempleado INT,
    @tipo_comprobante NVARCHAR(50),
    @total_venta DECIMAL(10,2),
    @metodo_pago NVARCHAR(50),
    @detalles farm.DetalleVentaType READONLY
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        DECLARE @idv INT;

        INSERT INTO farm.venta (idcliente, idempleado, tipo_comprobante, total_venta)
        VALUES (@idcliente, @idempleado, @tipo_comprobante, @total_venta);

        SET @idv = SCOPE_IDENTITY();

        INSERT INTO farm.pago (idventa, metodo_pago, monto_pagado)
        VALUES (@idv, @metodo_pago, @total_venta);

        INSERT INTO farm.detalle_venta (idventa, idproducto, cantidad, precio_unitario)
        SELECT @idv, idproducto, cantidad, precio_unitario FROM @detalles;

        UPDATE p SET p.stock_actual = p.stock_actual - d.cantidad
        FROM farm.producto p INNER JOIN @detalles d ON p.idproducto = d.idproducto;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- =============================================
-- 8. CARGA INICIAL DE DATOS (DATA SEED)
-- =============================================

-- Datos Maestros
INSERT INTO farm.cargo (nombre_cargo) VALUES ('Administrador'), ('Vendedor');
INSERT INTO farm.categoria (nombre_categoria) VALUES ('Analgésicos'), ('Antibióticos'), ('Vitaminas');
INSERT INTO farm.marca (nombre_marca) VALUES ('Genfar'), ('Bayer'), ('Mifarma');
INSERT INTO farm.unidad_medida (nombre_unidad, abreviatura) VALUES ('Tableta', 'Tab'), ('Frasco', 'Frs');

-- Personal y Clientes
INSERT INTO farm.empleado (nombres, apellidos, idcargo, telefono, correo, sueldo, fecha_contrato)
VALUES ('Diego', 'García', 1, '987654321', 'diego@farmacia.com', 2500.00, '2026-01-15');

INSERT INTO farm.cliente (nombres, apellidos, dni, direccion, telefono)
VALUES ('Público', 'General', '00000000', 'Calle S/N', '000000000');

-- Productos Iniciales
INSERT INTO farm.producto (nombre_producto, precio_venta, stock_actual, laboratorio, idcategoria, idmarca, idunidad_medida)
VALUES 
('Paracetamol 500mg', 0.50, 100, 'Bayer', 1, 2, 1),
('Amoxicilina 250mg', 12.50, 45, 'Genfar', 2, 1, 1),
('Vitamina C', 1.20, 150, 'Mifarma', 3, 3, 1);
GO