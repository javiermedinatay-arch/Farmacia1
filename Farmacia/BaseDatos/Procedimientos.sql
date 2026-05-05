CREATE PROCEDURE farm.usp_RegistrarVentaCompleta
    @idcliente INT,
    @idempleado INT,
    @tipo_comprobante NVARCHAR(50),
    @total_venta DECIMAL(10,2),
    @metodo_pago NVARCHAR(50),
    @detalles farm.DetalleVentaType READONLY -- Recibe la lista del DataGridView
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1. Insertar la Venta principal
        DECLARE @idventa_generada INT;
        
        INSERT INTO farm.venta (idcliente, idempleado, tipo_comprobante, total_venta, estado_pago)
        VALUES (@idcliente, @idempleado, @tipo_comprobante, @total_venta, 'Pagado');

        SET @idventa_generada = SCOPE_IDENTITY();

        -- 2. Insertar el Pago relacionado
        INSERT INTO farm.pago (idventa, metodo_pago, monto_pagado)
        VALUES (@idventa_generada, @metodo_pago, @total_venta);

        -- 3. Insertar Detalles y Actualizar Stock
        INSERT INTO farm.detalle_venta (idventa, idproducto, cantidad, precio_unitario)
        SELECT @idventa_generada, idproducto, cantidad, precio_unitario
        FROM @detalles;

        -- 4. Actualizar Stock en la tabla Producto
        UPDATE p
        SET p.stock_actual = p.stock_actual - d.cantidad
        FROM farm.producto p
        INNER JOIN @detalles d ON p.idproducto = d.idproducto;

        COMMIT TRANSACTION;
        PRINT 'Venta procesada exitosamente.';
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
    END CATCH
END;
GO

CREATE TYPE farm.DetalleVentaType AS TABLE (
    idproducto INT,
    cantidad INT,
    precio_unitario DECIMAL(10,2)
);
GO