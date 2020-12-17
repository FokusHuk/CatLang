namespace EnglishTrainer.Core.Domain.Exercises.DTOs
{
    public class ExerciseTaskDto<TPossibleAnswer, TUserAnswer>
    {
         public string Original { get; set; }

        public TPossibleAnswer PossibleAnswer { get; set; }

        public ExerciseTaskDto(string original, TPossibleAnswer possibleAnswer)
        {
            Original = original;
            PossibleAnswer = possibleAnswer;
        }

        public static ExerciseTaskDto<TPossibleAnswer, TUserAnswer> Create(ExerciseTask<TPossibleAnswer, TUserAnswer> task)
        {
            return task != null ? new ExerciseTaskDto<TPossibleAnswer, TUserAnswer>(
                task.Original,
                task.PossibleAnswer)
                : null;
        }
    }
}