USE [CatLang]
GO

CREATE TABLE [dbo].[UserStudiedSets](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [SetId] [uniqueidentifier] NOT NULL,
    [UserId] [uniqueidentifier] NOT NULL,
    [AttemptsCount] [int] NOT NULL,
    [IsStudied] [bit] NOT NULL,
    [CorrectAnswers] [int] NOT NULL,
    [AnswersCount] [int] NOT NULL,
    CONSTRAINT [PK_UserStudiedSets] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserStudiedSets]  WITH CHECK ADD  CONSTRAINT [FK_UserStudiedSets_Sets] FOREIGN KEY([SetId])
    REFERENCES [dbo].[Sets] ([Id])
GO

ALTER TABLE [dbo].[UserStudiedSets] CHECK CONSTRAINT [FK_UserStudiedSets_Sets]
GO

ALTER TABLE [dbo].[UserStudiedSets]  WITH CHECK ADD  CONSTRAINT [FK_UserStudiedSets_Users] FOREIGN KEY([UserId])
    REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[UserStudiedSets] CHECK CONSTRAINT [FK_UserStudiedSets_Users]
GO