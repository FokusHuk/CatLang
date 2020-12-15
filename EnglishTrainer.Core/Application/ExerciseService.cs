using System;
using System.Collections.Generic;
using EnglishTrainer.Core.Domain;
using EnglishTrainer.Core.Domain.Exercises;
using EnglishTrainer.Core.Domain.Repositories;

namespace EnglishTrainer.Core.Application
{
	public class ExerciseService : IExerciseService
	{
		public ExerciseService(
			IExerciseFactory factory,
			IExerciseRepository repository)
		{
			_factory = factory ?? throw new ArgumentNullException(nameof(factory));
			_exerciseRepository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public SprintExerciseStatus StartSprintExercise(Guid userId)
		{
			var exerciseId = Guid.NewGuid();
			var exercise = _factory.CreateSprintExercise(userId, exerciseId);
			_exerciseRepository.SaveExercise(exercise);
			return exercise.Status;
		}

		public SprintExerciseStatus CommitSprintExerciseAnswer(
			Guid userId, 
			Guid exerciseId, 
			string original, 
			bool answer)
		{
			var exercise = _exerciseRepository.GetSprintExercise(exerciseId);
			exercise.CommitAnswer(original, answer);
			_exerciseRepository.SaveExercise(exercise);
			return exercise.Status;
		}

		public IEnumerable<SprintExerciseResult> FinishSprintExercise(Guid exerciseId)
		{
			var exercise = _exerciseRepository.GetSprintExercise(exerciseId);
			var result = exercise.Result;
			_exerciseRepository.DeleteSprintExercise(exerciseId);
			return result;
		}

		private readonly IExerciseFactory _factory;

		private readonly IExerciseRepository _exerciseRepository;
	}
}
