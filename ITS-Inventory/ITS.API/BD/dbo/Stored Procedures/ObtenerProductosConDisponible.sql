CREATE PROCEDURE ObtenerProductosConDisponible
AS
BEGIN
    SELECT 
        p.Id,
        p.Descripcion,
        p.Marca,
        p.CategoriaId,
        ISNULL(SUM(CASE WHEN m.TipoMovimiento = 'IN' THEN m.Cantidad ELSE 0 END),0) AS TotalEntradas,
        ISNULL(SUM(CASE WHEN m.TipoMovimiento = 'OUT' THEN m.Cantidad ELSE 0 END),0) AS TotalSalidas,
        ISNULL(SUM(CASE WHEN m.TipoMovimiento = 'IN' THEN m.Cantidad ELSE 0 END),0) - 
        ISNULL(SUM(CASE WHEN m.TipoMovimiento = 'OUT' THEN m.Cantidad ELSE 0 END),0) AS Disponible
    FROM Producto p
    LEFT JOIN MovimientoInventario m ON p.Id = m.ProductoId
    GROUP BY p.Id, p.Descripcion, p.Marca, p.CategoriaId
END