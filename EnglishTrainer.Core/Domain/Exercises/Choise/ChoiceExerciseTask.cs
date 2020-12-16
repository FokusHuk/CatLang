namespace EnglishTrainer.Core.Domain.Exercises.Choise
{
    public class ChoiceExerciseTask
    {
        public ChoiceExerciseTask(string original, string[] translations, string correct, bool isCompleted = false)
        {
            Original = original;
            Translations = translations;
            Correct = correct;
            IsCompleted = isCompleted;
        }
        
        public string Original { get; }
        
        public string[] Translations { get; }
        
        public string Correct { get; }

        public string Answer
        {
            get => _answer;
            set
            {
                _answer = value;
                IsCompleted = true;
            }
        }

        public bool IsCompleted { get; private set; }

        private string _answer;
    }
}