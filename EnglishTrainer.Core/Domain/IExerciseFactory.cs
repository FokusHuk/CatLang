using System;
using EnglishTrainer.Core.Domain.Exercises;

namespace EnglishTrainer.Core.Domain
{
	public interface IExerciseFactory
	{
		SprintExercise CreateSprintExercise(Guid userId, Guid exerciseId);
	}
}