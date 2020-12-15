using System;
using TranslationTrainer.Domain;

namespace TranslationTrainer.Application
{
	public interface IExerciseService
	{
		ExerciseResult StartExercise(Guid userId);

		ExerciseResult FinishExercise(Guid exerciseId);

		ExerciseResult CommitCurrentWord(Guid exerciseId, bool isCorrect);
	}
}