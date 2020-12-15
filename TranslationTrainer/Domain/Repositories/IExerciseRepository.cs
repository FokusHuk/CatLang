using System;
using TranslationTrainer.Domain.Exercises;

namespace TranslationTrainer.Domain
{
	public interface IExerciseRepository
	{
		void SaveExercise(SprintExercise exercise);
		SprintExercise GetSprintExercise(Guid exerciseId);
		void DeleteSprintExercise(Guid exerciseId);
	}
}