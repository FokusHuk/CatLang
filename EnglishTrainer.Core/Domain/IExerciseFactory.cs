using System;
using EnglishTrainer.Core.Domain.Exercises;

namespace EnglishTrainer.Core.Domain
{
	public interface IExerciseFactory
	{
		Exercise<string, bool> CreateSprintExercise(Guid userId, Guid exerciseId);
		Exercise<string[], string> CreateChoiceExercise(Guid userId, Guid exerciseId);
	}
}