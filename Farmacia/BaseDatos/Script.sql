-- CREACIÓN DE BASE DE DATOS
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'FarmaciaDB')
CREATE DATABASE FarmaciaDB;
GO
USE FarmaciaDB;
GO

-- =============================================
-- TABLA: Categoria
-- =============================================
CREATE TABLE farm.categoria (
idcategoria INT IDENTITY(1,1) PRIMARY KEY,
 nombre_categoria VARCHAR(100) NOT NULL,

 descripcion VARCHAR(200),
 fecha_creacion DATETIME2 DEFAULT GETDATE()
);
-- =============================================
-- TABLA: Marca
-- =============================================
CREATE TABLE farm.marca (
idmarca INT IDENTITY(1,1) PRIMARY KEY,
 nombre_marca VARCHAR(100) NOT NULL,
 fecha_creacion DATETIME2 DEFAULT GETDATE()
);
-- =============================================
-- TABLA: Unidad de Medida
-- =============================================
CREATE TABLE farm.unidad_medida (
idunidad_medida INT IDENTITY(1,1) PRIMARY KEY,
 nombre_unidad VARCHAR(50) NOT NULL,
 abreviatura VARCHAR(10)
);
-- =============================================
-- TABLA: Producto
-- =============================================
CREATE TABLE farm.producto (
idproducto INT IDENTITY(1,1) PRIMARY KEY,
 nombre_producto VARCHAR(100) NOT NULL,
 descripcion VARCHAR(255),
 precio DECIMAL(10,2) NOT NULL CHECK (precio > 0),
 stock INT NOT NULL CHECK (stock >= 0),
 fecha_vencimiento DATE,
laboratorio VARCHAR(100),
 estado BIT DEFAULT 1,
 idcategoria INT,
idmarca INT,
idunidad_medida INT,
 CONSTRAINT fk_producto_categoria FOREIGN KEY (idcategoria) 
REFERENCES farm.categoria(idcategoria),
 CONSTRAINT fk_producto_marca FOREIGN KEY (idmarca) 
REFERENCES farm.marca(idmarca),
 CONSTRAINT fk_producto_unidad FOREIGN KEY (idunidad_medida) 
REFERENCES farm.unidad_medida(idunidad_medida)
);
-- =============================================
-- TABLA: Almacen
-- =============================================
CREATE TABLE farm.almacen (
idalmacen INT IDENTITY(1,1) PRIMARY KEY,
 nombre_almacen VARCHAR(100) NOT NULL,
 telefono VARCHAR(15),
 capacidad INT CHECK (capacidad >= 0)
);
-- =============================================
-- TABLA: Inventario
-- =============================================
CREATE TABLE farm.inventario (

idinventario INT IDENTITY(1,1) PRIMARY KEY,
 cantidad INT NOT NULL CHECK (cantidad >= 0),
 stock_minimo INT NOT NULL,
 stock_maximo INT NOT NULL,
 fecha_actualizacion DATETIME2 DEFAULT GETDATE(),
idalmacen INT NOT NULL,
idproducto INT NOT NULL,
 CONSTRAINT fk_inventario_almacen FOREIGN KEY (idalmacen)
REFERENCES farm.almacen(idalmacen),
 CONSTRAINT fk_inventario_producto FOREIGN KEY (idproducto)
REFERENCES farm.producto(idproducto)
);
-- =============================================
-- TABLA: Proveedor
-- =============================================
CREATE TABLE farm.proveedor (
idproveedor INT IDENTITY(1,1) PRIMARY KEY,
 nombre_proveedor VARCHAR(100) NOT NULL,
ruc CHAR(11) NOT NULL UNIQUE,
 direccion VARCHAR(100),
 telefono VARCHAR(15),
 correo VARCHAR(100)
);
-- =============================================
-- TABLA: Empleado
-- =============================================
CREATE TABLE farm.empleado (
idempleado INT IDENTITY(1,1) PRIMARY KEY,
 nombres VARCHAR(100) NOT NULL,
 apellidos VARCHAR(100) NOT NULL,
 cargo VARCHAR(100) NOT NULL,
 telefono VARCHAR(15),
 correo VARCHAR(100),
 sueldo DECIMAL(10,2) CHECK (sueldo >= 0),
 fecha_contrato DATE NOT NULL
);
-- =============================================
-- TABLA: Compra
-- =============================================
CREATE TABLE farm.compra (
idcompra INT IDENTITY(1,1) PRIMARY KEY,
 fecha_compra DATE NOT NULL,
 numero_factura VARCHAR(20) NOT NULL,
 total_compra DECIMAL(10,2) NOT NULL CHECK (total_compra >= 0),
idproveedor INT NOT NULL,
idempleado INT NOT NULL,
 estado BIT DEFAULT 1,
 CONSTRAINT fk_compra_proveedor FOREIGN KEY (idproveedor)
REFERENCES farm.proveedor(idproveedor),

 CONSTRAINT fk_compra_empleado FOREIGN KEY (idempleado)
REFERENCES farm.empleado(idempleado)
);
-- =============================================
-- TABLA: Detalle Compra
-- =============================================
CREATE TABLE farm.detalle_compra (
iddetalle_compra INT IDENTITY(1,1) PRIMARY KEY,
idcompra INT NOT NULL,
idproducto INT NOT NULL,
 cantidad INT NOT NULL CHECK (cantidad > 0),
 precio_compra DECIMAL(10,2) NOT NULL CHECK (precio_compra > 0),
 subtotal AS (cantidad * precio_compra) PERSISTED,
 CONSTRAINT fk_detallecompra_compra FOREIGN KEY (idcompra)
REFERENCES farm.compra(idcompra),
 CONSTRAINT fk_detallecompra_producto FOREIGN KEY (idproducto)
REFERENCES farm.producto(idproducto)
);
-- =============================================
-- TABLA: Cliente
-- =============================================
CREATE TABLE farm.cliente (
idcliente INT IDENTITY(1,1) PRIMARY KEY,
 nombres VARCHAR(100) NOT NULL,
 pellidos VARCHAR(100) NOT NULL,
 dni CHAR(8) NOT NULL UNIQUE,
 direccion VARCHAR(100),
 telefono VARCHAR(15)
);
-- =============================================
-- TABLA: Venta
-- =============================================
CREATE TABLE farm.venta (
idventa INT IDENTITY(1,1) PRIMARY KEY,
 fecha_venta DATETIME2 DEFAULT GETDATE(),
 tipo_comprobante VARCHAR(50) NOT NULL,
 total DECIMAL(10,2) NOT NULL CHECK (total >= 0),
idcliente INT NOT NULL,
idempleado INT NOT NULL,
 CONSTRAINT fk_venta_cliente FOREIGN KEY (idcliente)
REFERENCES farm.cliente(idcliente),
 CONSTRAINT fk_venta_empleado FOREIGN KEY (idempleado)
REFERENCES farm.empleado(idempleado)
);
-- =============================================
-- TABLA: Detalle Venta
-- =============================================
CREATE TABLE farm.detalle_venta (

iddetalle_venta INT IDENTITY(1,1) PRIMARY KEY,
 cantidad INT NOT NULL CHECK (cantidad > 0),
 precio_unitario DECIMAL(10,2) NOT NULL,
 subtotal AS (cantidad * precio_unitario) PERSISTED,
idventa INT NOT NULL,
idproducto INT NOT NULL,
 CONSTRAINT fk_detalleventa_venta FOREIGN KEY (idventa)
REFERENCES farm.venta(idventa),
 CONSTRAINT fk_detalleventa_producto FOREIGN KEY (idproducto)
REFERENCES farm.producto(idproducto)
);
-- =============================================
-- TABLA: Cargo
-- =============================================
CREATE TABLE farm.cargo (
idcargo INT IDENTITY(1,1) PRIMARY KEY,
 nombre_cargo VARCHAR(50) NOT NULL UNIQUE
);
-- =============================================
-- TABLA: Usuario
-- =============================================
CREATE TABLE farm.usuario (
idusuario INT IDENTITY(1,1) PRIMARY KEY,
 username VARCHAR(20) NOT NULL UNIQUE,
 password VARBINARY(256) NOT NULL, -- HASH
idempleado INT NOT NULL,
idcargo INT NOT NULL,
stado BIT DEFAULT 1,
 CONSTRAINT fk_usuario_empleado FOREIGN KEY (idempleado)
REFERENCES farm.empleado(idempleado),
 CONSTRAINT fk_usuario_cargo FOREIGN KEY (idcargo)
REFERENCES farm.cargo(idcargo)
);
