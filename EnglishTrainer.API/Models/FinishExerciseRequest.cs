using System;
using EnglishTrainer.Core.Domain.Exercises;

namespace EnglishTrainer.API.Models
{
    public class FinishExerciseRequest
    {
        public FinishExerciseRequest()
        {
            
        }
        
        public FinishExerciseRequest(Guid userId, Guid exerciseId, ExerciseFormat exerciseFormat)
        {
            UserId = userId;
            ExerciseId = exerciseId;
            ExerciseFormat = exerciseFormat;
        }
        
        public Guid UserId { get; set; }        
        public Guid ExerciseId {get;set;}
        public ExerciseFormat ExerciseFormat {get;set;}
    }
}
