using System;

namespace EnglishTrainer.Core.Domain.Exceptions
{
	public class ExerciseNotFoundException : Exception
	{
		public ExerciseNotFoundException(Guid exerciseId) 
			: base($"Упражнение с Id {exerciseId} не найдено.")
		{
		}
	}
}