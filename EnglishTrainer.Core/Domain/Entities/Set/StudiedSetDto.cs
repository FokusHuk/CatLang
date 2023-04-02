using System;

namespace EnglishTrainer.Core.Domain.Entities
{
    public class StudiedSetDto
    {
        public StudiedSetDto(int id, Guid setId, Guid userId, int attemptsCount, bool isStudied, int correctAnswers, int answersCount)
        {
            Id = id;
            SetId = setId;
            UserId = userId;
            AttemptsCount = attemptsCount;
            IsStudied = isStudied;
            CorrectAnswers = correctAnswers;
            AnswersCount = answersCount;
        }
        
        public StudiedSetDto(Guid setId, Guid userId, int correctAnswers, bool isStudied = false)
        {
            Id = 0;
            SetId = setId;
            UserId = userId;
            CorrectAnswers = correctAnswers;
            AnswersCount = 1;
            AttemptsCount = 1;
            IsStudied = isStudied;
        }

        public StudiedSetDto()
        {
            
        }
        
        public int Id { get; }
        public Guid SetId { get; }
        public Guid UserId { get; }
        public int AttemptsCount { get; set; }
        public bool IsStudied { get; set; }
        public int CorrectAnswers { get; set; }
        public int AnswersCount { get; set; }
    }
}
