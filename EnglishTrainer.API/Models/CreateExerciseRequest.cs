using System;
using EnglishTrainer.Core.Domain.Exercises;

namespace EnglishTrainer.API.Models
{
    public class CreateExerciseRequest
    {
        public CreateExerciseRequest()
        {
            
        }
        
        public CreateExerciseRequest(ExerciseFormat exerciseFormat, Guid setId)
        {
            ExerciseFormat = exerciseFormat;
            SetId = setId;
        }
        
        public ExerciseFormat ExerciseFormat {get;set;}
        public Guid SetId {get;set;}
    }
}
