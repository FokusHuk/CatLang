USE [CatLang]
GO

CREATE TABLE [dbo].[DatabaseMigrations](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Version] [int] NOT NULL,
    [Date] [date] NOT NULL,
    CONSTRAINT [PK_DatabaseMigrations] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY]
GO
