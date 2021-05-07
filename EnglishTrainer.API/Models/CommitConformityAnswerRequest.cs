using System;
using EnglishTrainer.Core.Domain.Exercises;

namespace EnglishTrainer.API.Models
{
    public class CommitConformityAnswerRequest
    {
        public CommitConformityAnswerRequest()
        {
            
        }
        
        public CommitConformityAnswerRequest(
            ExerciseFormat exerciseFormat, 
            Guid exerciseId, 
            Guid setId, 
            int wordId, 
            string taskAnswer, 
            bool userChoice)
        {
            ExerciseFormat = exerciseFormat;
            ExerciseId = exerciseId;
            SetId = setId;
            WordId = wordId;
            TaskAnswer = taskAnswer;
            UserChoice = userChoice;
        }

        public ExerciseFormat ExerciseFormat { get; set; }
        public Guid ExerciseId {get;set;}
        public Guid SetId {get;set;}
        public int WordId {get;set;}
        public string TaskAnswer {get;set;}
        public bool UserChoice {get;set;}
    }
}
