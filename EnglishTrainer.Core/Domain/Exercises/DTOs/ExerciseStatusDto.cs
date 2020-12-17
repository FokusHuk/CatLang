using System;

namespace EnglishTrainer.Core.Domain.Exercises.DTOs
{
    public class ExerciseStatusDto<TOption, TAnswer> 
    {
        public Guid ExerciseId { get; set; }
        public int TasksDone { get; set; }
        public int TasksLeft { get; set; }
        public bool IsFinished { get; set; }
        public ExerciseTaskDto<TOption, TAnswer> CurrentTask { get; set; }

        public ExerciseStatusDto(
            Guid exerciseId, 
            int tasksDone, 
            int tasksLeft, 
            bool isFinished, 
            ExerciseTaskDto<TOption, TAnswer>  currentTask)
        {
            ExerciseId = exerciseId;
            TasksDone = tasksDone;
            TasksLeft = tasksLeft;
            IsFinished = isFinished;
            CurrentTask = currentTask;
        }

        public static ExerciseStatusDto<TOption, TAnswer>  Create(ExerciseStatus<TOption, TAnswer>  status)
        {
            return new ExerciseStatusDto<TOption, TAnswer>(
                status.ExerciseId,
                status.TasksDone,
                status.TasksLeft,
                status.IsFinished,
                ExerciseTaskDto<TOption, TAnswer>.Create(status.CurrentTask));
        }
    }
}