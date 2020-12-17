namespace EnglishTrainer.Core.Domain.Exercises
{
    public class ExerciseTaskResult<TPossibleAnswer, TUserAnswer>
    {
        public string Original { get; }
        public TPossibleAnswer PossibleAnswer { get; }
        public TUserAnswer CorrectAnswer { get; }
        public TUserAnswer UserAnswer { get; }
        public bool IsUserAnswerCorrect { get; }

        public ExerciseTaskResult(string original, 
            TPossibleAnswer possibleAnswer, 
            TUserAnswer correctAnswer, 
            TUserAnswer userAnswer, 
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