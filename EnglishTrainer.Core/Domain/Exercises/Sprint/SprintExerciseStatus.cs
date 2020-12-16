using System;

namespace EnglishTrainer.Core.Domain.Exercises
{
    public class SprintExerciseStatus
    {
        public SprintExerciseStatus(
            Guid exerciseId, 
            int tasksDone, 
            int tasksLeft,
            bool isFinished,
            SprintExerciseTask currentTask)
        {
            ExerciseId = exerciseId;
            TasksDone = tasksDone;
            TasksLeft = tasksLeft;
            IsFinished = isFinished;
            CurrentTask = currentTask;
        }
        
        public Guid ExerciseId { get; }
        public int TasksDone { get; }
        public int TasksLeft { get; }
        public bool IsFinished { get; }
        public SprintExerciseTask CurrentTask { get; }
    }
}