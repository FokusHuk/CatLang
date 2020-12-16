using System;

namespace EnglishTrainer.Core.Domain.Exceptions
{
    public class ExerciseTasksWordNotFoundException: Exception
    {
        public ExerciseTasksWordNotFoundException(Guid exerciseId, string original)
        : base($"Упражнение с Id {exerciseId} не содержит слова \"{original}\" в своих заданиях.")
        {
        }
    }
}