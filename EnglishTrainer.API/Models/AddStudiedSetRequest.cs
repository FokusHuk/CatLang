using System;

namespace EnglishTrainer.API.Models
{
    public class AddStudiedSetRequest
    {
        public AddStudiedSetRequest(int correctAnswers)
        {
            CorrectAnswers = correctAnswers;
        }
        
        public AddStudiedSetRequest(Guid userId, Guid setId, int correctAnswers)
        {
            UserId = userId;
            SetId = setId;
            CorrectAnswers = correctAnswers;
        }
        public Guid UserId { get; set; }
        public Guid SetId { get; set; }
        public int CorrectAnswers { get; set; }
    }
}
