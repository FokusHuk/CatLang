USE [CatLang]

if not exists (select * from sys.tables where name='SetWords')
CREATE TABLE [dbo].[SetWords](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [WordId] [int] NOT NULL,
    [SetId] [uniqueidentifier] NOT NULL,
    CONSTRAINT [PK_SetWords] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY]

ALTER TABLE [dbo].[SetWords]  WITH CHECK ADD  CONSTRAINT [FK_SetWords_Sets] FOREIGN KEY([SetId])
    REFERENCES [dbo].[Sets] ([Id])

ALTER TABLE [dbo].[SetWords] CHECK CONSTRAINT [FK_SetWords_Sets]

ALTER TABLE [dbo].[SetWords]  WITH CHECK ADD  CONSTRAINT [FK_SetWords_Words] FOREIGN KEY([WordId])
    REFERENCES [dbo].[Words] ([Id])

ALTER TABLE [dbo].[SetWords] CHECK CONSTRAINT [FK_SetWords_Words]
