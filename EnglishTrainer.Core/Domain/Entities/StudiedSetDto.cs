using System;

namespace EnglishTrainer.Core.Domain.Entities
{
    public class StudiedSetDto
    {
        public StudiedSetDto(int id, Guid setId, Guid userId, int attemptsCount, bool isStudied)
        {
            Id = id;
            SetId = setId;
            UserId = userId;
            AttemptsCount = attemptsCount;
            IsStudied = isStudied;
        }
        
        public int Id { get; }
        public Guid SetId { get; }
        public Guid UserId { get; }
        public int AttemptsCount { get; set; }
        public bool IsStudied { get; set; }
    }
}
