using System;
using EnglishTrainer.Core.Domain.Exercises;

namespace EnglishTrainer.Core.Application
{
	public interface IExerciseService
	{
		ConformityExercise CreateConformityExercise(ExerciseFormat format, Guid setId);
		ChoiceExercise CreateChoiceExercise(ExerciseFormat format, Guid setId);
		void CommitConformityAnswer(ExerciseFormat format, Guid exerciseId, Guid setId, int wordId, string taskAnswer,
			bool answer);
		public void CommitChoiceAnswer(ExerciseFormat format, Guid exerciseId, Guid setId, int wordId,
			string chosenAnswer);
		ExerciseResult FinishExercise(Guid exerciseId, ExerciseFormat format);
	}
}
