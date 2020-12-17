namespace EnglishTrainer.Core.Domain.Exercises.DTOs
{
    public class ExerciseTaskDto<TOption, TAnswer>
    {
         public string Original { get; set; }

        public TOption PossibleAnswer { get; set; }

        public ExerciseTaskDto(string original, TOption possibleAnswer)
        {
            Original = original;
            PossibleAnswer = possibleAnswer;
        }

        public static ExerciseTaskDto<TOption, TAnswer> Create(ExerciseTask<TOption, TAnswer> task)
        {
            return task != null ? new ExerciseTaskDto<TOption, TAnswer>(
                task.Original,
                task.PossibleAnswer)
                : null;
        }
    }
}