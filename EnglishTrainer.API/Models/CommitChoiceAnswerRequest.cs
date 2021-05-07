using System;
using EnglishTrainer.Core.Domain.Exercises;

namespace EnglishTrainer.API.Models
{
    public class CommitChoiceAnswerRequest
    {
        public CommitChoiceAnswerRequest()
        {
            
        }
        
        public CommitChoiceAnswerRequest(
            ExerciseFormat exerciseFormat, 
            Guid exerciseId, 
            Guid setId, 
            int wordId, 
            string chosenAnswer)
        {
            ExerciseFormat = exerciseFormat;
            ExerciseId = exerciseId;
            SetId = setId;
            WordId = wordId;
            ChosenAnswer = chosenAnswer;
        }

        public ExerciseFormat ExerciseFormat { get; set; }
        public Guid ExerciseId {get;set;}
        public Guid SetId {get;set;}
        public int WordId {get;set;}
        public string ChosenAnswer {get;set;}
    }
}
