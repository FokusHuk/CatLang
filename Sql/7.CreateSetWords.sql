USE [CatLang]
GO

CREATE TABLE [dbo].[SetWords](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [WordId] [int] NOT NULL,
    [SetId] [uniqueidentifier] NOT NULL,
    CONSTRAINT [PK_SetWords] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SetWords]  WITH CHECK ADD  CONSTRAINT [FK_SetWords_Sets] FOREIGN KEY([SetId])
    REFERENCES [dbo].[Sets] ([Id])
GO

ALTER TABLE [dbo].[SetWords] CHECK CONSTRAINT [FK_SetWords_Sets]
GO

ALTER TABLE [dbo].[SetWords]  WITH CHECK ADD  CONSTRAINT [FK_SetWords_Words] FOREIGN KEY([WordId])
    REFERENCES [dbo].[Words] ([Id])
GO

ALTER TABLE [dbo].[SetWords] CHECK CONSTRAINT [FK_SetWords_Words]
GO
