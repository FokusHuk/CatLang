using System;
using EnglishTrainer.Core.Domain;
using EnglishTrainer.Core.Domain.Exercises;
using EnglishTrainer.Core.Domain.Exercises.Choise;
using EnglishTrainer.Core.Domain.Exercises.DTOs;
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

		public SprintExerciseStatusDTO StartSprintExercise(Guid userId)
		{
			var exerciseId = Guid.NewGuid();
			var exercise = _factory.CreateSprintExercise(userId, exerciseId);
			_exerciseRepository.SaveExercise(exercise);
			return SprintExerciseStatusDTO.Create(exercise.Status());
		}

		public SprintExerciseStatusDTO CommitSprintExerciseAnswer(
			Guid userId, 
			Guid exerciseId, 
			string original, 
			bool answer)
		{
			var exercise = _exerciseRepository.GetSprintExercise(exerciseId);
			exercise.CommitAnswer(original, answer);
			_exerciseRepository.SaveExercise(exercise);
			return SprintExerciseStatusDTO.Create(exercise.Status());
		}

		public SprintExerciseResult FinishSprintExercise(Guid exerciseId)
		{
			var exercise = _exerciseRepository.GetSprintExercise(exerciseId);
			var result = exercise.Result();
			_exerciseRepository.DeleteSprintExercise(exerciseId);
			return result;
		}
		
		
		public ChoiceExerciseStatusDTO StartChoiceExercise(Guid userId)
		{
			var exerciseId = Guid.NewGuid();
			var exercise = _factory.CreateChoiceExercise(userId, exerciseId);
			_exerciseRepository.SaveExercise(exercise);
			return ChoiceExerciseStatusDTO.Create(exercise.Status());
		}

		public ChoiceExerciseStatusDTO CommitChoiceExerciseAnswer(
			Guid userId, 
			Guid exerciseId, 
			string original, 
			string answer)
		{
			var exercise = _exerciseRepository.GetChoiceExercise(exerciseId);
			exercise.CommitAnswer(original, answer);
			_exerciseRepository.SaveExercise(exercise);
			return ChoiceExerciseStatusDTO.Create(exercise.Status());
		}

		public ChoiceExerciseResult FinishChoiceExercise(Guid exerciseId)
		{
			var exercise = _exerciseRepository.GetChoiceExercise(exerciseId);
			var result = exercise.Result();
			_exerciseRepository.DeleteChoiceExercise(exerciseId);
			return result;
		}

		private readonly IExerciseFactory _factory;

		private readonly IExerciseRepository _exerciseRepository;
	}
}
