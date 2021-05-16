using System;

namespace EnglishTrainer.API.Models
{
    public class AddStudiedWordRequest
    {
        public AddStudiedWordRequest()
        {
            
        }
        
        public AddStudiedWordRequest(int wordId, int correctAnswers, int incorrectAnswers, DateTime lastAppearanceDate)
        {
            WordId = wordId;
            CorrectAnswers = correctAnswers;
            IncorrectAnswers = incorrectAnswers;
            LastAppearanceDate = lastAppearanceDate;
        }
        
        public int WordId { get; set; }
        public int CorrectAnswers { get; set; }
        public int IncorrectAnswers { get; set; }
        public DateTime LastAppearanceDate { get; set; }
    }
}
