-- ========================================
-- CREACIÓN DE BASE DE DATOS
-- ========================================
CREATE DATABASE ITSInventarioDB;
GO

USE ITSInventarioDB;
GO

-- ========================================
-- TABLA: Categoria
-- ========================================
CREATE TABLE Categoria (
    Id INT IDENTITY PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(200)
);
GO

-- Datos de ejemplo para Categoria
INSERT INTO Categoria (Nombre, Descripcion) VALUES
('Computo', 'Equipo de cómputo general'),
('Accesorios', 'Periféricos y accesorios'),
('Redes', 'Equipo de redes');
GO

-- ========================================
-- TABLA: Producto
-- ========================================
CREATE TABLE Producto (
    Id INT IDENTITY PRIMARY KEY,
    Descripcion NVARCHAR(200) NOT NULL,
    Marca NVARCHAR(100),
    CategoriaId INT FOREIGN KEY REFERENCES Categoria(Id),
    TotalEntradas INT DEFAULT 0,
    TotalSalidas INT DEFAULT 0,
    Disponible AS (TotalEntradas - TotalSalidas) PERSISTED
);
GO

-- Datos de ejemplo para Producto
INSERT INTO Producto (Descripcion, Marca, CategoriaId, TotalEntradas, TotalSalidas)
VALUES
('Laptop WYSE', 'WYSE', 1, 101, 81),
('Teclado USB', 'Genius', 2, 50, 30),
('Router Cisco', 'Cisco', 3, 25, 5);
GO

-- ========================================
-- TABLA: MovimientoInventario
-- ========================================
CREATE TABLE MovimientoInventario (
    Id INT IDENTITY PRIMARY KEY,
    ProductoId INT NOT NULL FOREIGN KEY REFERENCES Producto(Id),
    Descripcion NVARCHAR(200),
    Ticket NVARCHAR(50),
    Tecnico NVARCHAR(100),
    Fecha DATETIME DEFAULT GETDATE(),
    Cantidad INT NOT NULL,
    TipoMovimiento NVARCHAR(10) CHECK (TipoMovimiento IN ('IN', 'OUT'))
);
GO

-- Datos de ejemplo para MovimientoInventario
INSERT INTO MovimientoInventario (ProductoId, Descripcion, Ticket, Tecnico, Fecha, Cantidad, TipoMovimiento)
VALUES
(1, 'Entrega a usuario', '32232918', 'Jose D', '2025-06-24', 1, 'OUT'),
(2, 'Reposición stock', 'Update', 'Melanie', '2025-06-23', 3, 'IN'),
(3, 'Salida de mantenimiento', 'Ticket123', 'Carlos M', '2025-06-20', 2, 'OUT');
GO

-- ========================================
-- VERIFICACIÓN DE DATOS
-- ========================================
SELECT * FROM Categoria;
SELECT * FROM Producto;
SELECT * FROM MovimientoInventario;
GO

CREATE TABLE PedidoInventario (
    Id INT IDENTITY PRIMARY KEY,
    Articulo NVARCHAR(100),
    Cantidad INT,
    FechaPedido DATE,
    Condicion NVARCHAR(50)
);

INSERT INTO PedidoInventario (Articulo, Cantidad, FechaPedido, Condicion)
VALUES (N'Disipadores de Calor', 2, '2024-06-09', N'Entregado');


-- ========================================
-- TABLA: PoliticaReabastecimiento
-- ========================================
CREATE TABLE PoliticaReabastecimiento (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductoId INT NOT NULL FOREIGN KEY REFERENCES Producto(Id),
    Minimo INT NOT NULL,
    PedirAntesDe INT NOT NULL
);
GO


-- Datos de ejemplo
INSERT INTO PoliticaReabastecimiento (ProductoId, Minimo, PedirAntesDe)
VALUES (1, 15, 5);
GO

SELECT 
    P.Id,
    Pr.Descripcion AS Producto,
    P.Minimo,
    P.PedirAntesDe
FROM PoliticaReabastecimiento P
JOIN Producto Pr ON P.ProductoId = Pr.Id;
GO
