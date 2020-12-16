using System;

namespace EnglishTrainer.API.Models
{
    public class CommitChoiceAnswerRequest
    {
        public Guid ExerciseId { get; set; }
        public string Word { get; set; }
        public string Answer { get; set; }
    }
}