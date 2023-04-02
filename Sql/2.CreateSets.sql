USE [CatLang]
GO

CREATE TABLE [dbo].[Sets](
    [Id] [uniqueidentifier] NOT NULL,
    [UserId] [uniqueidentifier] NOT NULL,
    [AverageStudyTime] [real] NOT NULL,
    [StudyTopic] [nvarchar](100) NOT NULL,
    [Popularity] [int] NOT NULL,
    [Efficiency] [real] NOT NULL,
    [Complexity] [real] NOT NULL,
    CONSTRAINT [PK_Sets] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Sets]  WITH CHECK ADD  CONSTRAINT [FK_Sets_Users] FOREIGN KEY([UserId])
    REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[Sets] CHECK CONSTRAINT [FK_Sets_Users]
GO