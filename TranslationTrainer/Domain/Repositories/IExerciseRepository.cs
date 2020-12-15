using System;
using TranslationTrainer.Domain.Exercises;

namespace TranslationTrainer.Domain
{
	public interface IExerciseRepository
	{
		void SaveExercise(SprintExercise exercise);
	}
}