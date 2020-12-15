using System;
using TranslationTrainer.Domain;
using TranslationTrainer.Domain.Exercises;

namespace TranslationTrainer.Application
{
	public class ExerciseService : IExerciseService
	{
		public ExerciseService(
			IExerciseFactory factory, 
			IExerciseFinisher finisher,
			IExerciseRepository repository, IExerciseTasksRepository tasksRepository)
		{
			_factory = factory ?? throw new ArgumentNullException(nameof(factory));
			_finisher = finisher ?? throw new ArgumentNullException(nameof(finisher));
			_exerciseRepository = repository ?? throw new ArgumentNullException(nameof(repository));
			_tasksRepository = tasksRepository;
		}

		public SprintExerciseStatus StartSprintExercise(Guid userId)
		{
			var exerciseId = Guid.NewGuid();
			var exercise = _factory.CreateSprintExercise(userId, exerciseId);
			
			_exerciseRepository.SaveExercise(exercise);

			return exercise.Status;
		}

		//public ExerciseStatusOld StartExercise(Guid userId)
		//{
		//	var exercise = _factory.Create(userId);
		//	_exerciseRepository.SaveExercise(exercise);
		//	return exercise.Status;
		//}
//
		//public ExerciseResult FinishExercise(Guid exerciseId)
		//{
		//	var exerciseResults = _finisher.FinishExercise(exerciseId);
		//	return exerciseResults;
		//}
//
		//public ExerciseStatusOld CommitCurrentWord(Guid exerciseId, bool isCorrect)
		//{
		//	var exercise = _exerciseRepository.GetExercise(exerciseId);
		//	exercise.CommitCurrentTranslation(isCorrect);
		//	_exerciseRepository.SaveExercise(exercise);
		//	return exercise.Status;
		//}

		private readonly IExerciseFactory _factory;
		private readonly IExerciseFinisher _finisher;
		private readonly IExerciseRepository _exerciseRepository;
		private readonly IExerciseTasksRepository _tasksRepository;
		public ExerciseResult StartExercise(Guid userId)
		{
			throw new NotImplementedException();
		}

		public ExerciseResult FinishExercise(Guid exerciseId)
		{
			throw new NotImplementedException();
		}

		public ExerciseResult CommitCurrentWord(Guid exerciseId, bool isCorrect)
		{
			throw new NotImplementedException();
		}
	}
}
