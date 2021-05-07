using System;
using EnglishTrainer.Core.Domain.Exercises;

namespace EnglishTrainer.Core.Domain
{
	public interface IExerciseFactory
	{
		ConformityExercise GetConformityExercise(ExerciseFormat format, Guid setId);
		ChoiceExercise GetChoiceExercise(ExerciseFormat format, Guid setId);
	}
}