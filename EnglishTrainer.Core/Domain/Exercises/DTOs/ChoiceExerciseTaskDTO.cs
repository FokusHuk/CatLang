using EnglishTrainer.Core.Domain.Exercises.Choise;

namespace EnglishTrainer.Core.Domain.Exercises.DTOs
{
    public class ChoiceExerciseTaskDTO
    {
        public string Original { get; set; }

        public string[] Translations { get; set; }

        public ChoiceExerciseTaskDTO(string original, string[] translations)
        {
            Original = original;
            Translations = translations;
        }

        public static ChoiceExerciseTaskDTO Create(ChoiceExerciseTask task)
        {
            return task != null ? new ChoiceExerciseTaskDTO(
                    task.Original,
                    task.Translations)
                : null;
        }
    }
}