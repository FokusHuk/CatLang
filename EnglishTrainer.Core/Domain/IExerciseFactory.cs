using System;
using EnglishTrainer.Core.Domain.Exercises;
using EnglishTrainer.Core.Domain.Exercises.Choise;

namespace EnglishTrainer.Core.Domain
{
	public interface IExerciseFactory
	{
		SprintExercise CreateSprintExercise(Guid userId, Guid exerciseId);
		ChoiceExercise CreateChoiceExercise(Guid userId, Guid exerciseId);
	}
}