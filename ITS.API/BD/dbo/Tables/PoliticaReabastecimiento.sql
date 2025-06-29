CREATE TABLE [dbo].[PoliticaReabastecimiento] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [ProductoId]   INT NOT NULL,
    [Minimo]       INT NOT NULL,
    [PedirAntesDe] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ProductoId]) REFERENCES [dbo].[Producto] ([Id])
);

