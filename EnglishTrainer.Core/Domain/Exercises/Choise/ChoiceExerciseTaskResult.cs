namespace EnglishTrainer.Core.Domain.Exercises.Choise
{
    public class ChoiceExerciseTaskResult
    {
        public string Original { get; }
        public string[] Translations { get; }
        public string CorrectAnswer { get; }
        public string UserAnswer { get; }
        public bool IsUserAnswerCorrect { get; }

        public ChoiceExerciseTaskResult(
            string original, 
            string[] translations, 
            string correctAnswer, 
            string userAnswer, 
            bool isUserAnswerCorrect)
        {
            Original = original;
            Translations = translations;
            CorrectAnswer = correctAnswer;
            UserAnswer = userAnswer;
            IsUserAnswerCorrect = isUserAnswerCorrect;
        }
    }
}