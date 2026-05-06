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

-- Vista para el ComboBox de Empleados
CREATE VIEW farm.vw_ListarEmpleados AS
SELECT idempleado, (nombres + ' ' + apellidos) AS nombre_completo, idcargo
FROM farm.empleado;
GO

-- Vista para el ComboBox de Clientes
CREATE VIEW farm.vw_ListarClientes AS
SELECT idcliente, (nombres + ' ' + apellidos) AS nombre_completo, dni
FROM farm.cliente;
GO

-- Vista para el ComboBox de Productos y validación de Stock
CREATE VIEW farm.vw_ListarProductos AS
SELECT p.idproducto, p.nombre_producto, p.precio_venta, p.stock_actual, 
       m.nombre_marca, c.nombre_categoria
FROM farm.producto p
INNER JOIN farm.marca m ON p.idmarca = m.idmarca
INNER JOIN farm.categoria c ON p.idcategoria = c.idcategoria
WHERE p.estado = 1;
GO

CREATE VIEW farm.vw_ResumenVentas AS
SELECT 
    v.idventa,
    v.fecha_venta,
    (c.nombres + ' ' + c.apellidos) AS cliente,
    (e.nombres + ' ' + e.apellidos) AS vendedor,
    v.tipo_comprobante,
    v.total_venta,
    p.metodo_pago
FROM farm.venta v
INNER JOIN farm.cliente c ON v.idcliente = c.idcliente
INNER JOIN farm.empleado e ON v.idempleado = e.idempleado
INNER JOIN farm.pago p ON v.idventa = p.idventa;
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