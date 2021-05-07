using System;
using System.Collections.Generic;

namespace EnglishTrainer.API.Models
{
    public class CommitExerciseAnswerRequest
    {
        public CommitExerciseAnswerRequest()
        {
            
        }
        
        public CommitExerciseAnswerRequest(Guid exerciseId, Guid setId, int wordId, string chosenAnswer)
        {
            ExerciseId = exerciseId;
            SetId = setId;
            WordId = wordId;
            ChosenAnswer = chosenAnswer;
        }
        
        public Guid ExerciseId {get;set;}
        public Guid SetId {get;set;}
        public int WordId {get;set;}
        public string ChosenAnswer {get;set;}
    }
}
