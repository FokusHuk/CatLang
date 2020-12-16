using System;

namespace EnglishTrainer.Core.Domain.Exercises.DTOs
{
    public class SprintExerciseStatusDTO
    {
        public Guid ExerciseId { get; set; }
        public int TasksDone { get; set; }
        public int TasksLeft { get; set; }
        public bool IsFinished { get; set; }
        public SprintExerciseTaskDTO CurrentTask { get; set; }

        public SprintExerciseStatusDTO(Guid exerciseId, int tasksDone, int tasksLeft, bool isFinished, SprintExerciseTaskDTO currentTask)
        {
            ExerciseId = exerciseId;
            TasksDone = tasksDone;
            TasksLeft = tasksLeft;
            IsFinished = isFinished;
            CurrentTask = currentTask;
        }

        public static SprintExerciseStatusDTO Create(SprintExerciseStatus status)
        {
            return new SprintExerciseStatusDTO(
                status.ExerciseId,
                status.TasksDone,
                status.TasksLeft,
                status.IsFinished,
                SprintExerciseTaskDTO.Create(status.CurrentTask));
        }
    }
}