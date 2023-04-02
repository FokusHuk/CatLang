USE [CatLang]

if not exists (select * from sys.tables where name='UserStudiedSets')
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

ALTER TABLE [dbo].[UserStudiedSets]  WITH CHECK ADD  CONSTRAINT [FK_UserStudiedSets_Sets] FOREIGN KEY([SetId])
    REFERENCES [dbo].[Sets] ([Id])

ALTER TABLE [dbo].[UserStudiedSets] CHECK CONSTRAINT [FK_UserStudiedSets_Sets]

ALTER TABLE [dbo].[UserStudiedSets]  WITH CHECK ADD  CONSTRAINT [FK_UserStudiedSets_Users] FOREIGN KEY([UserId])
    REFERENCES [dbo].[Users] ([Id])

ALTER TABLE [dbo].[UserStudiedSets] CHECK CONSTRAINT [FK_UserStudiedSets_Users]