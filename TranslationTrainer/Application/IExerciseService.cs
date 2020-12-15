using System;
using TranslationTrainer.Domain;
using TranslationTrainer.Domain.Exercises;

namespace TranslationTrainer.Application
{
	public interface IExerciseService
	{
		SprintExerciseStatus StartSprintExercise(Guid userId);
		SprintExerciseStatus CommitSprintExerciseAnswer(Guid userId, Guid exerciseId, string original, bool isCorrect);
		ExerciseResult FinishExercise(Guid exerciseId);
	}
}