USE [CatLang]

if not exists (select * from sys.tables where name='Words')
CREATE TABLE [dbo].[Words](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Original] [nvarchar](100) NOT NULL,
    [Translation] [nvarchar](100) NOT NULL,
    CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY]