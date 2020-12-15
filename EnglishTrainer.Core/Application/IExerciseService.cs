using System;
using System.Collections.Generic;
using EnglishTrainer.Core.Domain.Exercises;

namespace EnglishTrainer.Core.Application
{
	public interface IExerciseService
	{
		SprintExerciseStatus StartSprintExercise(Guid userId);
		SprintExerciseStatus CommitSprintExerciseAnswer(Guid userId, Guid exerciseId, string original, bool isCorrect);
		IEnumerable<SprintExerciseResult> FinishSprintExercise(Guid exerciseId);
	}
}