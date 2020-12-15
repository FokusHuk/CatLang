using System;

namespace TranslationTrainer.Domain.Exercises
{
    public class SprintExerciseTask
    {
        public Guid ExerciseId { get; }
        public string Original { get; }
        public string Translation { get; }
        public bool Correct { get; }
        public bool Answer { get; }

        public SprintExerciseTask(Guid exerciseId, string original, string translation, bool correct, bool answer)
        {
            ExerciseId = exerciseId;
            Original = original;
            Translation = translation;
            Correct = correct;
            Answer = answer;
        }
    }
}