USE [CatLang]

if not exists (select * from sys.tables where name='DatabaseMigrations')
CREATE TABLE [dbo].[DatabaseMigrations](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Version] [int] NOT NULL,
    [Date] [date] NOT NULL,
    CONSTRAINT [PK_DatabaseMigrations] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY]
