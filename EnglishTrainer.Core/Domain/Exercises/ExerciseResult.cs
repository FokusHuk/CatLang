using System.Collections.Generic;

namespace EnglishTrainer.Core.Domain.Exercises
{
    public class ExerciseResult<TPossibleAnswer, TUserAnswer>
    {
        public int CorrectTasksCount { get; }
        public int IncorrectTasksCount { get; }
        public List<ExerciseTaskResult<TPossibleAnswer, TUserAnswer>> Tasks { get; }

        public ExerciseResult(
            int correctTasksCount, 
            int incorrectTasksCount, 
            IEnumerable<ExerciseTaskResult<TPossibleAnswer, TUserAnswer>> tasks)
        {
            CorrectTasksCount = correctTasksCount;
            IncorrectTasksCount = incorrectTasksCount;
            Tasks = new List<ExerciseTaskResult<TPossibleAnswer, TUserAnswer>>(tasks);
        }
    }
}