using System;
using EnglishTrainer.Core.Domain.Exercises;

namespace EnglishTrainer.Core.Domain.Repositories
{
	public interface IExerciseRepository
	{
		void SaveExercise(SprintExercise exercise);
		SprintExercise GetSprintExercise(Guid exerciseId);
		void DeleteSprintExercise(Guid exerciseId);
	}
}