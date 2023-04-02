USE [CatLang]
GO

CREATE TABLE [dbo].[RecommendedSets](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [SetId] [uniqueidentifier] NOT NULL,
    [UserId] [uniqueidentifier] NOT NULL,
    [OffersCount] [int] NOT NULL,
    [LastAppearanceDate] [date] NOT NULL,
    CONSTRAINT [PK_RecommendedSets] PRIMARY KEY CLUSTERED ([Id] ASC)
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RecommendedSets]  WITH CHECK ADD  CONSTRAINT [FK_RecommendedSets_Sets] FOREIGN KEY([SetId])
    REFERENCES [dbo].[Sets] ([Id])
GO

ALTER TABLE [dbo].[RecommendedSets] CHECK CONSTRAINT [FK_RecommendedSets_Sets]
GO

ALTER TABLE [dbo].[RecommendedSets]  WITH CHECK ADD  CONSTRAINT [FK_RecommendedSets_Users] FOREIGN KEY([UserId])
    REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[RecommendedSets] CHECK CONSTRAINT [FK_RecommendedSets_Users]
GO
