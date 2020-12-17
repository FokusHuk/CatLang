using System;
using EnglishTrainer.Core.Domain;
using EnglishTrainer.Core.Domain.Exercises;
using EnglishTrainer.Core.Domain.Exercises.DTOs;
using EnglishTrainer.Core.Domain.Repositories;

namespace EnglishTrainer.Core.Application
{
	public class ExerciseService : IExerciseService
	{
		public ExerciseService(
			IExerciseFactory factory,
			IExerciseRepositories exerciseRepositories)
		{
			_factory = factory ?? throw new ArgumentNullException(nameof(factory));
			_exerciseRepositories = exerciseRepositories ?? throw new ArgumentNullException(nameof(exerciseRepositories));
		}

		public ExerciseStatusDto<string, bool> StartSprintExercise(Guid userId)
		{
			var exerciseId = Guid.NewGuid();
			var exercise = _factory.CreateSprintExercise(userId, exerciseId);
			_exerciseRepositories.ForSprint().Save(exercise);
			return ExerciseStatusDto<string, bool>.Create(exercise.Status());
		}

		public ExerciseStatusDto<string, bool> CommitSprintExerciseAnswer(
			Guid userId, 
			Guid exerciseId, 
			string original, 
			bool answer)
		{
			var exercise = _exerciseRepositories.ForSprint().Get(exerciseId);
			exercise.CommitAnswer(original, answer);
			_exerciseRepositories.ForSprint().Save(exercise);
			return ExerciseStatusDto<string, bool>.Create(exercise.Status());
		}

		public ExerciseResult<string, bool> FinishSprintExercise(Guid exerciseId)
		{
			var exercise = _exerciseRepositories.ForSprint().Get(exerciseId);
			var result = exercise.Result();
			_exerciseRepositories.ForSprint().Delete(exerciseId);
			return result;
		}

		
		public ExerciseStatusDto<string[], string> StartChoiceExercise(Guid userId)
		{
			var exerciseId = Guid.NewGuid();
			var exercise = _factory.CreateChoiceExercise(userId, exerciseId);
			_exerciseRepositories.ForChoice().Save(exercise);
			return ExerciseStatusDto<string[], string>.Create(exercise.Status());
		}

		public ExerciseStatusDto<string[], string> CommitChoiceExerciseAnswer(
			Guid userId, 
			Guid exerciseId, 
			string original, 
			string answer)
		{
			var exercise = _exerciseRepositories.ForChoice().Get(exerciseId);
			exercise.CommitAnswer(original, answer);
			_exerciseRepositories.ForChoice().Save(exercise);
			return ExerciseStatusDto<string[], string>.Create(exercise.Status());
		}

		public ExerciseResult<string[], string> FinishChoiceExercise(Guid exerciseId)
		{
			var exercise = _exerciseRepositories.ForChoice().Get(exerciseId);
			var result = exercise.Result();
			_exerciseRepositories.ForChoice().Delete(exerciseId);
			return result;
		}

		private readonly IExerciseFactory _factory;

		private readonly IExerciseRepositories _exerciseRepositories;
	}
}
