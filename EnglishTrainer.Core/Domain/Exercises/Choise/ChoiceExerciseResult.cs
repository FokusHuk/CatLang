using System.Collections.Generic;

namespace EnglishTrainer.Core.Domain.Exercises.Choise
{
    public class ChoiceExerciseResult
    {
        public int CorrectTasksCount { get; }
        public int IncorrectTasksCount { get; }
        public List<ChoiceExerciseTaskResult> Tasks { get; }

        public ChoiceExerciseResult(int correctTasksCount, int incorrectTasksCount, IEnumerable<ChoiceExerciseTaskResult> tasks)
        {
            CorrectTasksCount = correctTasksCount;
            IncorrectTasksCount = incorrectTasksCount;
            Tasks = new List<ChoiceExerciseTaskResult>(tasks);
        }
    }
}