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