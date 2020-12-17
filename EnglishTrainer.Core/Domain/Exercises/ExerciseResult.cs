using System.Collections.Generic;

namespace EnglishTrainer.Core.Domain.Exercises
{
    public class ExerciseResult<TOption, TAnswer>
    {
        public int CorrectTasksCount { get; }
        public int IncorrectTasksCount { get; }
        public List<ExerciseTaskResult<TOption, TAnswer>> Tasks { get; }

        public ExerciseResult(
            int correctTasksCount, 
            int incorrectTasksCount, 
            IEnumerable<ExerciseTaskResult<TOption, TAnswer>> tasks)
        {
            CorrectTasksCount = correctTasksCount;
            IncorrectTasksCount = incorrectTasksCount;
            Tasks = new List<ExerciseTaskResult<TOption, TAnswer>>(tasks);
        }
    }
}