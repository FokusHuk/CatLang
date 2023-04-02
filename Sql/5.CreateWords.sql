USE [CatLang]
GO

CREATE TABLE [dbo].[Words](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Original] [nvarchar](100) NOT NULL,
    [Translation] [nvarchar](100) NOT NULL,
    CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY]
GO