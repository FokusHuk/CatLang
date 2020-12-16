using System;

namespace EnglishTrainer.Core.Domain.Exercises.DTOs
{
    public class SprintExerciseStatusDTO
    {
        public Guid ExerciseId { get; set; }
        public int WordsDone { get; set; }
        public int WordsLeft { get; set; }
        public bool IsFinished { get; set; }
        public SprintExerciseTaskDTO CurrentTask { get; set; }

        public SprintExerciseStatusDTO(Guid exerciseId, int wordsDone, int wordsLeft, bool isFinished, SprintExerciseTaskDTO currentTask)
        {
            ExerciseId = exerciseId;
            WordsDone = wordsDone;
            WordsLeft = wordsLeft;
            IsFinished = isFinished;
            CurrentTask = currentTask;
        }

        public static SprintExerciseStatusDTO Create(SprintExerciseStatus status)
        {
            return new SprintExerciseStatusDTO(
                status.ExerciseId,
                status.WordsDone,
                status.WordsLeft,
                status.IsFinished,
                SprintExerciseTaskDTO.Create(status.CurrentTask));
        }
    }
}