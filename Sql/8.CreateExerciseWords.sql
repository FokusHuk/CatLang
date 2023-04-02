USE [CatLang]
GO

CREATE TABLE [dbo].[ExerciseWords](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [ExerciseId] [uniqueidentifier] NOT NULL,
    [SetId] [uniqueidentifier] NOT NULL,
    [WordId] [int] NOT NULL,
    [Answer] [nvarchar](100) NOT NULL,
    [Date] [date] NOT NULL,
    [IsCorrect] [bit] NOT NULL,
    CONSTRAINT [PK_ExerciseWords] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ExerciseWords]  WITH CHECK ADD  CONSTRAINT [FK_ExerciseWords_Sets] FOREIGN KEY([SetId])
    REFERENCES [dbo].[Sets] ([Id])
GO

ALTER TABLE [dbo].[ExerciseWords] CHECK CONSTRAINT [FK_ExerciseWords_Sets]
GO

ALTER TABLE [dbo].[ExerciseWords]  WITH CHECK ADD  CONSTRAINT [FK_ExerciseWords_Words] FOREIGN KEY([WordId])
    REFERENCES [dbo].[Words] ([Id])
GO

ALTER TABLE [dbo].[ExerciseWords] CHECK CONSTRAINT [FK_ExerciseWords_Words]
GO
