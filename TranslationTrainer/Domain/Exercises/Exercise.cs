using System;

namespace TranslationTrainer.Domain.Exercises
{
    public class Exercise
    {
        public Guid ExerciseId { get; }
        public Guid UserId { get; }
        public ExerciseType ExerciseType { get; }

        public Exercise(Guid exerciseId, Guid userId, ExerciseType exerciseType)
        {
            ExerciseId = exerciseId;
            UserId = userId;
            ExerciseType = exerciseType;
        }
    }
}