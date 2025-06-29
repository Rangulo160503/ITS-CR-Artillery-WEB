CREATE TABLE [dbo].[PedidoInventario] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Articulo]    NVARCHAR (100) NULL,
    [Cantidad]    INT            NULL,
    [FechaPedido] DATE           NULL,
    [Condicion]   NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

