using System;
using EnglishTrainer.Core.Domain.Exercises;

namespace EnglishTrainer.API.Models
{
    public class FinishExerciseRequest
    {
        public FinishExerciseRequest()
        {
            
        }
        
        public FinishExerciseRequest(Guid exerciseId, ExerciseFormat exerciseFormat)
        {
            ExerciseId = exerciseId;
            ExerciseFormat = exerciseFormat;
        }
        
        public Guid ExerciseId {get;set;}
        public ExerciseFormat ExerciseFormat {get;set;}
    }
}
