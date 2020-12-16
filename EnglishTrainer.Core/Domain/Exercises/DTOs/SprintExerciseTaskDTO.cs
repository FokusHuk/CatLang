namespace EnglishTrainer.Core.Domain.Exercises.DTOs
{
    public class SprintExerciseTaskDTO
    {
        public string Original { get; set; }

        public string Translation { get; set; }

        public SprintExerciseTaskDTO(string original, string translation)
        {
            Original = original;
            Translation = translation;
        }

        public static SprintExerciseTaskDTO Create(SprintExerciseTask task)
        {
            return task != null ? new SprintExerciseTaskDTO(
                task.Original,
                task.Translation)
                : null;
        }
    }
}