CREATE DATABASE bancocap

GO

USE bancocap

CREATE TABLE [Cliente] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(80) NOT NULL,
    [CPF] nvarchar(15) NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Conta] (
    [Id] int NOT NULL IDENTITY,
    [Hash] nvarchar(max) NOT NULL,
    [IdCliente] int NOT NULL,
    CONSTRAINT [PK_Conta] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Conta_Cliente_IdCliente] FOREIGN KEY ([IdCliente]) REFERENCES [Cliente] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Operacao] (
    [Id] int NOT NULL IDENTITY,
    [DataHora] datetime2 NOT NULL,
    [Valor] float NOT NULL,
    [Tipo] char NOT NULL,
    [IdContaOrigem] int NULL,
    [IdContaDestino] int NULL,
    CONSTRAINT [PK_Operacao] PRIMARY KEY ([Id])
);

GO

CREATE INDEX [IX_Conta_IdCliente] ON [Conta] ([IdCliente]);

GO

