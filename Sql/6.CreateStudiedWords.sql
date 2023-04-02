USE [CatLang]

if not exists (select * from sys.tables where name='StudiedWords')
CREATE TABLE [dbo].[StudiedWords](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [UserId] [uniqueidentifier] NOT NULL,
    [WordId] [int] NOT NULL,
    [CorrectAnswers] [int] NOT NULL,
    [IncorrectAnswers] [int] NOT NULL,
    [LastAppearanceDate] [date] NOT NULL,
    [Status] [smallint] NOT NULL,
    [RiskFactor] [real] NOT NULL,
    CONSTRAINT [PK_StudiedWords] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY]

ALTER TABLE [dbo].[StudiedWords]  WITH CHECK ADD  CONSTRAINT [FK_StudiedWords_Users] FOREIGN KEY([UserId])
    REFERENCES [dbo].[Users] ([Id])

ALTER TABLE [dbo].[StudiedWords] CHECK CONSTRAINT [FK_StudiedWords_Users]

ALTER TABLE [dbo].[StudiedWords]  WITH CHECK ADD  CONSTRAINT [FK_StudiedWords_Words] FOREIGN KEY([WordId])
    REFERENCES [dbo].[Words] ([Id])

ALTER TABLE [dbo].[StudiedWords] CHECK CONSTRAINT [FK_StudiedWords_Words]