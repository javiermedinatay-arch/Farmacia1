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