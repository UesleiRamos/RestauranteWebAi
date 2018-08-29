IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [tbRestaurante] (
    [Id] int NOT NULL IDENTITY,
    [Descricao] nvarchar(100) NOT NULL,
    CONSTRAINT [Id] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [tbPrato] (
    [Id] int NOT NULL IDENTITY,
    [Descricao] nvarchar(100) NOT NULL,
    [restautaneID] int NOT NULL,
    CONSTRAINT [Id] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_tbPrato_tbRestaurante_restautaneID] FOREIGN KEY ([restautaneID]) REFERENCES [tbRestaurante] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_tbPrato_restautaneID] ON [tbPrato] ([restautaneID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180829021342_InitialCreate', N'2.2.0-preview1-35029');

GO

