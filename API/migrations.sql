IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Authors] (
    [id] int NOT NULL IDENTITY,
    [name] nvarchar(max) NOT NULL,
    [lastname] nvarchar(max) NOT NULL,
    [birthdate] datetime2 NOT NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([id])
);
GO

CREATE TABLE [Clients] (
    [id] int NOT NULL IDENTITY,
    [name] nvarchar(max) NOT NULL,
    [lastname] nvarchar(max) NOT NULL,
    [birthdate] datetime2 NOT NULL,
    [Phone] int NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([id])
);
GO

CREATE TABLE [Genres] (
    [id] int NOT NULL IDENTITY,
    [name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Genres] PRIMARY KEY ([id])
);
GO

CREATE TABLE [Rents] (
    [id] int NOT NULL IDENTITY,
    [rent_date] datetime2 NOT NULL,
    [return_date] datetime2 NULL,
    [ClientId] int NOT NULL,
    CONSTRAINT [PK_Rents] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Rents_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Books] (
    [id] int NOT NULL IDENTITY,
    [title] nvarchar(max) NOT NULL,
    [subtitle] nvarchar(max) NOT NULL,
    [AuthorId] int NOT NULL,
    [GenreId] int NOT NULL,
    [publishDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Books_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Books_Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [RentBooks] (
    [BooksId] int NOT NULL,
    [RentsId] int NOT NULL,
    CONSTRAINT [PK_RentBooks] PRIMARY KEY ([BooksId], [RentsId]),
    CONSTRAINT [FK_RentBooks_Books_BooksId] FOREIGN KEY ([BooksId]) REFERENCES [Books] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_RentBooks_Rents_RentsId] FOREIGN KEY ([RentsId]) REFERENCES [Rents] ([id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Books_AuthorId] ON [Books] ([AuthorId]);
GO

CREATE INDEX [IX_Books_GenreId] ON [Books] ([GenreId]);
GO

CREATE INDEX [IX_RentBooks_RentsId] ON [RentBooks] ([RentsId]);
GO

CREATE INDEX [IX_Rents_ClientId] ON [Rents] ([ClientId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240927020247_Initial', N'8.0.4');
GO

COMMIT;
GO

