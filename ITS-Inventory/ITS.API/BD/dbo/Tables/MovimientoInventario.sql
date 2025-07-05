CREATE TABLE [dbo].[MovimientoInventario] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [ProductoId]     INT            NOT NULL,
    [Descripcion]    NVARCHAR (200) NULL,
    [Ticket]         NVARCHAR (50)  NULL,
    [Tecnico]        NVARCHAR (100) NULL,
    [Fecha]          DATETIME       DEFAULT (getdate()) NULL,
    [Cantidad]       INT            NOT NULL,
    [TipoMovimiento] NVARCHAR (10)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([TipoMovimiento]='OUT' OR [TipoMovimiento]='IN'),
    FOREIGN KEY ([ProductoId]) REFERENCES [dbo].[Producto] ([Id])
);

