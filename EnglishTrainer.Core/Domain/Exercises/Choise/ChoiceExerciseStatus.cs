using System;

namespace EnglishTrainer.Core.Domain.Exercises.Choise
{
    public class ChoiceExerciseStatus
    {
        public ChoiceExerciseStatus(Guid exerciseId, int tasksDone, int tasksLeft, bool isFinished, ChoiceExerciseTask currentTask)
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
        public ChoiceExerciseTask CurrentTask { get; }
    }
}