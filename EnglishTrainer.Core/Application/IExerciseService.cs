using System;
using EnglishTrainer.Core.Domain.Exercises;

namespace EnglishTrainer.Core.Application
{
	public interface IExerciseService
	{
		ConformityExercise CreateConformityExercise(ExerciseFormat format, Guid setId);
		ChoiceExercise CreateChoiceExercise(ExerciseFormat format, Guid setId);
		void CommitExerciseAnswer(Guid exerciseId, Guid setId, int wordId, string chosenAnswer);
		ExerciseResult FinishExercise(Guid exerciseId);
	}
}
