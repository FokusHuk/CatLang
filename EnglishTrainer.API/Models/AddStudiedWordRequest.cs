using System;

namespace EnglishTrainer.API.Models
{
    public class AddStudiedWordRequest
    {
        public AddStudiedWordRequest()
        {
            
        }
        
        public AddStudiedWordRequest(Guid userId, int wordId, int correctAnswers, int incorrectAnswers, DateTime lastAppearanceDate)
        {
            UserId = userId;
            WordId = wordId;
            CorrectAnswers = correctAnswers;
            IncorrectAnswers = incorrectAnswers;
            LastAppearanceDate = lastAppearanceDate;
        }
        
        public Guid UserId { get; set; }
        public int WordId { get; set; }
        public int CorrectAnswers { get; set; }
        public int IncorrectAnswers { get; set; }
        public DateTime LastAppearanceDate { get; set; }
    }
}
