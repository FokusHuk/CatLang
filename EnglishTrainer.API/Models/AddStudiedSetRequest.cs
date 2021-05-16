using System;

namespace EnglishTrainer.API.Models
{
    public class AddStudiedSetRequest
    {
        public AddStudiedSetRequest(int correctAnswers)
        {
            CorrectAnswers = correctAnswers;
        }
        
        public AddStudiedSetRequest(Guid setId, int correctAnswers)
        {
            SetId = setId;
            CorrectAnswers = correctAnswers;
        }
        public Guid SetId { get; set; }
        public int CorrectAnswers { get; set; }
    }
}
