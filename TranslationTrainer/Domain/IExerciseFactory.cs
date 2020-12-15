using System;
using System.Collections.Generic;
using TranslationTrainer.Domain.Exercises;

namespace TranslationTrainer.Domain
{
	public interface IExerciseFactory
	{
		SprintExercise CreateSprintExercise(Guid userId, Guid exerciseId);
	}
}