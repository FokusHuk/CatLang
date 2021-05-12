using System;
using System.Collections.Generic;
using EnglishTrainer.Core.Domain.Entities;

namespace EnglishTrainer.Core.Domain.Repositories
{
    public interface IRecommendedSetsRepository
    {
        List<RecommendedSet> GetAll();
        List<RecommendedSet> GetByUserId(Guid userId);
        void UpdateSet(RecommendedSet recommendedSet);
        void Create(RecommendedSet recommendedSet);
    }
}
