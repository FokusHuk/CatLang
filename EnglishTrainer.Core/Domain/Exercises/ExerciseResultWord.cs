namespace EnglishTrainer.Core.Domain.Exercises
{
    public class ExerciseResultWord
    {
        public ExerciseResultWord(string chosenAnswer, string correctAnswer)
        {
            ChosenAnswer = chosenAnswer;
            CorrectAnswer = correctAnswer;
        }
        
        public string ChosenAnswer { get; }
        public string CorrectAnswer { get; }
    }
}
