namespace EnglishTrainer.Core.Domain.Exercises
{
    public class ExerciseTaskResult<TOption, TAnswer>
    {
        public string Original { get; }
        public TOption PossibleAnswer { get; }
        public TAnswer CorrectAnswer { get; }
        public TAnswer UserAnswer { get; }
        public bool IsUserAnswerCorrect { get; }

        public ExerciseTaskResult(string original, 
            TOption possibleAnswer, 
            TAnswer correctAnswer, 
            TAnswer userAnswer, 
            bool isUserAnswerCorrect)
        {
            Original = original;
            PossibleAnswer = possibleAnswer;
            CorrectAnswer = correctAnswer;
            UserAnswer = userAnswer;
            IsUserAnswerCorrect = isUserAnswerCorrect;
        }
    }
}