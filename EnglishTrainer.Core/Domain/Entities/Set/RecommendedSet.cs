using System;

namespace EnglishTrainer.Core.Domain.Entities
{
    public class RecommendedSet
    {
        public RecommendedSet(int id, Guid setId, Guid userId, int offersCount, DateTime lastAppearanceDate)
        {
            Id = id;
            SetId = setId;
            UserId = userId;
            OffersCount = offersCount;
            LastAppearanceDate = lastAppearanceDate;
        }

        public RecommendedSet(Guid setId, Guid userId, int offersCount, DateTime lastAppearanceDate)
        {
            Id = 0;
            SetId = setId;
            UserId = userId;
            OffersCount = offersCount;
            LastAppearanceDate = lastAppearanceDate;
        }

        public RecommendedSet()
        {
            
        }
        
        public int Id { get; }
        public Guid SetId { get; }
        public Guid UserId { get; }
        public int OffersCount { get; set; }
        public DateTime LastAppearanceDate { get; set; }
    }
}
