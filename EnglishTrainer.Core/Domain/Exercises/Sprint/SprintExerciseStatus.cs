using System;

namespace EnglishTrainer.Core.Domain.Exercises
{
    public class SprintExerciseStatus
    {
        public SprintExerciseStatus(
            Guid exerciseId, 
            int wordsDone, 
            int wordsLeft,
            bool isFinished,
            SprintExerciseTask currentTask)
        {
            ExerciseId = exerciseId;
            WordsDone = wordsDone;
            WordsLeft = wordsLeft;
            IsFinished = isFinished;
            CurrentTask = currentTask;
        }
        
        public Guid ExerciseId { get; }
        public int WordsDone { get; }
        public int WordsLeft { get; }
        public bool IsFinished { get; }
        public SprintExerciseTask CurrentTask { get; }
    }
}