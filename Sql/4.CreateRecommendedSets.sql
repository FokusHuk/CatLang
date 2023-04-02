USE [CatLang]

if not exists (select * from sys.tables where name='RecommendedSets')
CREATE TABLE [dbo].[RecommendedSets](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [SetId] [uniqueidentifier] NOT NULL,
    [UserId] [uniqueidentifier] NOT NULL,
    [OffersCount] [int] NOT NULL,
    [LastAppearanceDate] [date] NOT NULL,
    CONSTRAINT [PK_RecommendedSets] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY]

ALTER TABLE [dbo].[RecommendedSets]  WITH CHECK ADD  CONSTRAINT [FK_RecommendedSets_Sets] FOREIGN KEY([SetId])
    REFERENCES [dbo].[Sets] ([Id])

ALTER TABLE [dbo].[RecommendedSets] CHECK CONSTRAINT [FK_RecommendedSets_Sets]

ALTER TABLE [dbo].[RecommendedSets]  WITH CHECK ADD  CONSTRAINT [FK_RecommendedSets_Users] FOREIGN KEY([UserId])
    REFERENCES [dbo].[Users] ([Id])

ALTER TABLE [dbo].[RecommendedSets] CHECK CONSTRAINT [FK_RecommendedSets_Users]
