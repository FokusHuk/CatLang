using System.Collections.Generic;

namespace EnglishTrainer.Core.Domain.Exercises
{
    public class SprintExerciseResult
    {
        public int CorrectTasksCount { get; }
        public int IncorrectTasksCount { get; }
        public List<SprintExerciseTaskResult> Tasks { get; }

        public SprintExerciseResult(int correctTasksCount, int incorrectTasksCount, IEnumerable<SprintExerciseTaskResult> tasks)
        {
            CorrectTasksCount = correctTasksCount;
            IncorrectTasksCount = incorrectTasksCount;
            Tasks = new List<SprintExerciseTaskResult>(tasks);
        }
    }
}