using System;

namespace EnglishTrainer.Core.Domain.Exercises
{
    public class ExerciseStatus<TPossibleAnswer, TUserAnswer>
    {
        public ExerciseStatus(
            Guid exerciseId, 
            int tasksDone, 
            int tasksLeft,
            bool isFinished,
            ExerciseTask<TPossibleAnswer, TUserAnswer> currentTask)
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
        public ExerciseTask<TPossibleAnswer, TUserAnswer> CurrentTask { get; }
    }
}