using System;
using TranslationTrainer.Domain.Exercises;

namespace TranslationTrainer.Domain
{
	public interface IExerciseFactory
	{
		SprintExercise CreateSprintExercise(Guid userId, Guid exerciseId);
	}
}