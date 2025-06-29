CREATE TABLE [dbo].[Producto] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Descripcion]   NVARCHAR (200) NOT NULL,
    [Marca]         NVARCHAR (100) NULL,
    [CategoriaId]   INT            NULL,
    [TotalEntradas] INT            DEFAULT ((0)) NULL,
    [TotalSalidas]  INT            DEFAULT ((0)) NULL,
    [Disponible]    AS             ([TotalEntradas]-[TotalSalidas]) PERSISTED,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CategoriaId]) REFERENCES [dbo].[Categoria] ([Id])
);

