using System;

namespace EnglishTrainer.Core.Domain.Exercises
{
    public class ExerciseStatus<TOption, TAnswer>
    {
        public ExerciseStatus(
            Guid exerciseId, 
            int tasksDone, 
            int tasksLeft,
            bool isFinished,
            ExerciseTask<TOption, TAnswer> currentTask)
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
        public ExerciseTask<TOption, TAnswer> CurrentTask { get; }
    }
}