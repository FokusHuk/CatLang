﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using EnglishTrainer.Core.Domain.Entities;
using EnglishTrainer.Core.Domain.Repositories;

namespace EnglishTrainer.Core.Infrastructure
{
    public class RecommendedSetsRepository: IRecommendedSetsRepository
    {
        private readonly IDbConnection _connection;
        
        public RecommendedSetsRepository(IDbConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }
        
        public List<RecommendedSet> GetAll()
        {
            var result = _connection
                .Query<RecommendedSet>(@"select * from RecommendedSets")
                .ToList();

            return result;
        }
        
        public List<RecommendedSet> GetByUserId(Guid userId)
        {
            var result = _connection
                .Query<RecommendedSet>(@"select * from RecommendedSets
                                    where UserId = @UserId",
                    new {UserId = userId})
                .ToList();

            return result;
        }

        public void UpdateSet(RecommendedSet recommendedSet)
        {
            _connection
                .Query<RecommendedSet>(@"update RecommendedSets
                            set 
                                OffersCount = @OffersCount,
                                LastAppearanceDate = @LastAppearanceDate
                            where Id = @Id",
                    new
                    {
                        Id = recommendedSet.Id,
                        OffersCount = recommendedSet.OffersCount,
                        LastAppearanceDate = recommendedSet.LastAppearanceDate
                    });
        }

        public void Create(RecommendedSet recommendedSet)
        {
            _connection
                .Query<RecommendedSet>(@"insert into RecommendedSets
                (SetId, UserId, OffersCount, LastAppearanceDate) 
                values (@SetId, @UserId, @OffersCount, @LastAppearanceDate)",
                    new
                    {
                        SetId = recommendedSet.SetId,
                        UserId = recommendedSet.UserId,
                        OffersCount = recommendedSet.OffersCount,
                        LastAppearanceDate = recommendedSet.LastAppearanceDate
                    });
        }
    }
}
