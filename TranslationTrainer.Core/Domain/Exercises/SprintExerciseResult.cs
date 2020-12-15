namespace TranslationTrainer.Domain.Exercises
{
    public class SprintExerciseResult
    {
        public string Original { get; }
        public string Translation { get; }
        public bool CorrectAnswer { get; }
        public bool UserAnswer { get; }
        public bool IsUserAnswerCorrect { get; }

        public SprintExerciseResult(string original, string translation, bool correctAnswer, bool userAnswer, bool isUserAnswerCorrect)
        {
            Original = original;
            Translation = translation;
            CorrectAnswer = correctAnswer;
            UserAnswer = userAnswer;
            IsUserAnswerCorrect = isUserAnswerCorrect;
        }
    }
}