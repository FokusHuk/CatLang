USE [CatLang]
GO

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
GO

ALTER TABLE [dbo].[StudiedWords]  WITH CHECK ADD  CONSTRAINT [FK_StudiedWords_Users] FOREIGN KEY([UserId])
    REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[StudiedWords] CHECK CONSTRAINT [FK_StudiedWords_Users]
GO

ALTER TABLE [dbo].[StudiedWords]  WITH CHECK ADD  CONSTRAINT [FK_StudiedWords_Words] FOREIGN KEY([WordId])
    REFERENCES [dbo].[Words] ([Id])
GO

ALTER TABLE [dbo].[StudiedWords] CHECK CONSTRAINT [FK_StudiedWords_Words]
GO