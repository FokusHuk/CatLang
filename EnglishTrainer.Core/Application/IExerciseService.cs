using System;
using System.Collections.Generic;
using EnglishTrainer.Core.Domain.Exercises;
using EnglishTrainer.Core.Domain.Exercises.Choise;
using EnglishTrainer.Core.Domain.Exercises.DTOs;

namespace EnglishTrainer.Core.Application
{
	public interface IExerciseService
	{
		SprintExerciseStatusDTO StartSprintExercise(Guid userId);
		SprintExerciseStatusDTO CommitSprintExerciseAnswer(Guid userId, Guid exerciseId, string original, bool isCorrect);
		SprintExerciseResult FinishSprintExercise(Guid exerciseId);
		
		ChoiceExerciseStatusDTO StartChoiceExercise(Guid userId);
		ChoiceExerciseStatusDTO CommitChoiceExerciseAnswer(Guid userId, Guid exerciseId, string original, string answer);
		ChoiceExerciseResult FinishChoiceExercise(Guid exerciseId);
	}
}