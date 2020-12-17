namespace EnglishTrainer.Core.Domain.Exercises
{
    public class ExerciseTask<TOption, TAnswer>
    {
        public ExerciseTask(string original, TOption translations, TAnswer correct, bool isCompleted = false)
        {
            Original = original;
            PossibleAnswer = translations;
            Correct = correct;
            IsCompleted = isCompleted;
        }
        
        public string Original { get; }
        
        public TOption PossibleAnswer { get; }
        
        public TAnswer Correct { get; }

        public TAnswer Answer
        {
            get => _answer;
            set
            {
                _answer = value;
                IsCompleted = true;
            }
        }

        public bool IsCompleted { get; private set; }

        private TAnswer _answer;
    }
}