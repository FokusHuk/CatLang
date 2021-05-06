using System;

namespace EnglishTrainer.Core.Domain.Entities
{
    public class StudiedWordDto
    {
        public StudiedWordDto(
            int id,
            Guid userId,
            int wordId,
            int correctAnswers,
            int incorrectAnswers,
            DateTime lastAppearanceDate,
            StudyStatus status,
            double riskFactor)
        {
            Id = id;
            UserId = userId;
            WordId = wordId;
            CorrectAnswers = correctAnswers;
            IncorrectAnswers = incorrectAnswers;
            LastAppearanceDate = lastAppearanceDate;
            Status = status;
            RiskFactor = riskFactor;
        }

        public StudiedWordDto(
            Guid userId, 
            int wordId, 
            int correctAnswers, 
            int incorrectAnswers, 
            DateTime lastAppearanceDate)
        {
            Id = 0;
            UserId = userId;
            WordId = wordId;
            CorrectAnswers = correctAnswers;
            IncorrectAnswers = incorrectAnswers;
            LastAppearanceDate = lastAppearanceDate;
            Status = StudyStatus.New;
            RiskFactor = 50.0;
        }

        public int Id { get; }
        public Guid UserId { get; }
        public int WordId { get; }
        public int CorrectAnswers { get; set; }
        public int IncorrectAnswers { get; set; }
        public DateTime LastAppearanceDate { get; set; }
        public StudyStatus Status { get; set; }
        public double RiskFactor { get; set; }
    }
}
