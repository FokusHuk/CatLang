using System;
using EnglishTrainer.Core.Domain.Exercises.Choise;

namespace EnglishTrainer.Core.Domain.Exercises.DTOs
{
    public class ChoiceExerciseStatusDTO
    {
        public Guid ExerciseId { get; set; }
        public int TasksDone { get; set; }
        public int TasksLeft { get; set; }
        public bool IsFinished { get; set; }
        public ChoiceExerciseTaskDTO CurrentTask { get; set; }

        public ChoiceExerciseStatusDTO(
            Guid exerciseId, 
            int tasksDone, 
            int tasksLeft, 
            bool isFinished, 
            ChoiceExerciseTaskDTO currentTask)
        {
            ExerciseId = exerciseId;
            TasksDone = tasksDone;
            TasksLeft = tasksLeft;
            IsFinished = isFinished;
            CurrentTask = currentTask;
        }

        public static ChoiceExerciseStatusDTO Create(ChoiceExerciseStatus status)
        {
            return new ChoiceExerciseStatusDTO(
                status.ExerciseId,
                status.TasksDone,
                status.TasksLeft,
                status.IsFinished,
                ChoiceExerciseTaskDTO.Create(status.CurrentTask));
        }
    }
}