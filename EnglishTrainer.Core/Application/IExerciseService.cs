using System;
using EnglishTrainer.Core.Domain.Exercises;
using EnglishTrainer.Core.Domain.Exercises.DTOs;

namespace EnglishTrainer.Core.Application
{
	public interface IExerciseService
	{
		ExerciseStatusDto<string, bool> StartSprintExercise(Guid userId);
		ExerciseStatusDto<string, bool> CommitSprintExerciseAnswer(Guid userId, Guid exerciseId, string original, bool isCorrect);
		ExerciseResult<string, bool> FinishSprintExercise(Guid exerciseId);
		
		ExerciseStatusDto<string[], string> StartChoiceExercise(Guid userId);
		ExerciseStatusDto<string[], string> CommitChoiceExerciseAnswer(Guid userId, Guid exerciseId, string original, string answer);
		ExerciseResult<string[], string> FinishChoiceExercise(Guid exerciseId);
	}
}