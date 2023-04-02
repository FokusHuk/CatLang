USE [CatLang]

if not exists (select * from sys.tables where name='Sets')
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

ALTER TABLE [dbo].[Sets]  WITH CHECK ADD  CONSTRAINT [FK_Sets_Users] FOREIGN KEY([UserId])
    REFERENCES [dbo].[Users] ([Id])

ALTER TABLE [dbo].[Sets] CHECK CONSTRAINT [FK_Sets_Users]