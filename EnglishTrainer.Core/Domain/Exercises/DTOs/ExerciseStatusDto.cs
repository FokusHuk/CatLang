using System;

namespace EnglishTrainer.Core.Domain.Exercises.DTOs
{
    public class ExerciseStatusDto<TPossibleAnswer, TUserAnswer> 
    {
        public Guid ExerciseId { get; set; }
        public int TasksDone { get; set; }
        public int TasksLeft { get; set; }
        public bool IsFinished { get; set; }
        public ExerciseTaskDto<TPossibleAnswer, TUserAnswer> CurrentTask { get; set; }

        public ExerciseStatusDto(
            Guid exerciseId, 
            int tasksDone, 
            int tasksLeft, 
            bool isFinished, 
            ExerciseTaskDto<TPossibleAnswer, TUserAnswer>  currentTask)
        {
            ExerciseId = exerciseId;
            TasksDone = tasksDone;
            TasksLeft = tasksLeft;
            IsFinished = isFinished;
            CurrentTask = currentTask;
        }

        public static ExerciseStatusDto<TPossibleAnswer, TUserAnswer>  Create(ExerciseStatus<TPossibleAnswer, TUserAnswer>  status)
        {
            return new ExerciseStatusDto<TPossibleAnswer, TUserAnswer>(
                status.ExerciseId,
                status.TasksDone,
                status.TasksLeft,
                status.IsFinished,
                ExerciseTaskDto<TPossibleAnswer, TUserAnswer>.Create(status.CurrentTask));
        }
    }
}