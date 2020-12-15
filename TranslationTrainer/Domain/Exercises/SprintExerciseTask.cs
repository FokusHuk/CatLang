using System;

namespace TranslationTrainer.Domain.Exercises
{
    public class SprintExerciseTask
    {
        public SprintExerciseTask(
            Guid exerciseId,
            string original,
            string translation,
            bool correct,
            bool isCompleted = false)
        {
            ExerciseId = exerciseId;
            Original = original;
            Translation = translation;
            Correct = correct;
            IsCompleted = isCompleted;
        }

        public Guid ExerciseId { get; }

        public string Original { get; }

        public string Translation { get; }

        public bool Correct { get; }

        public bool Answer
        {
            get => _answer;
            set
            {
                _answer = value;
                IsCompleted = true;
            }
        }

        public bool IsCompleted { get; private set; }

        private bool _answer;
    }
}