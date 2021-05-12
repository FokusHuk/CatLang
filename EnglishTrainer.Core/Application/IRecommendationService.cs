using System;
using System.Collections.Generic;

namespace EnglishTrainer.Core.Application
{
    public interface IRecommendationService
    {
        List<Guid> GetByUserId(Guid userId);
        void Generate();
    }
}
