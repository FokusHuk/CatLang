namespace EnglishTrainer.Core.Domain.Exercises
{
    public class ExerciseTask<TPossibleAnswer, TUserAnswer>
    {
        public ExerciseTask(string original, TPossibleAnswer translations, TUserAnswer correct, bool isCompleted = false)
        {
            Original = original;
            PossibleAnswer = translations;
            Correct = correct;
            IsCompleted = isCompleted;
        }
        
        public string Original { get; }
        
        public TPossibleAnswer PossibleAnswer { get; }
        
        public TUserAnswer Correct { get; }

        public TUserAnswer Answer
        {
            get => _answer;
            set
            {
                _answer = value;
                IsCompleted = true;
            }
        }

        public bool IsCompleted { get; private set; }

        private TUserAnswer _answer;
    }
}