using System;

namespace EnglishTrainer.Core.Domain.Exceptions
{
    public class AllExerciseTasksCompletedException: Exception
    {
        public AllExerciseTasksCompletedException(Guid exerciseId) 
            : base($"Упражнение с Id {exerciseId} уже завершено.")
        {
        }
    }
}