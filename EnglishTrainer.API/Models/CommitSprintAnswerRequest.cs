using System;

namespace EnglishTrainer.API.Models
{
    public class CommitSprintAnswerRequest
    {
        public Guid ExerciseId { get; set; }
        public string Word { get; set; }
        public bool Answer { get; set; }
    }
}