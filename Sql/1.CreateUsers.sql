USE [CatLang]

if not exists (select * from sys.tables where name='Users')
CREATE TABLE [dbo].[Users](
    [Id] [uniqueidentifier] NOT NULL,
    [Username] [nvarchar](50) NOT NULL,
    [Login] [nvarchar](50) NOT NULL,
    [PasswordHash] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY]