using System;
using System.Collections.Generic;
using EnglishTrainer.Core.Domain.Exceptions;
using EnglishTrainer.Core.Domain.Exercises;
using EnglishTrainer.Core.Domain.Repositories;

namespace EnglishTrainer.Core.Infrastructure
{
	public class ExerciseRepository<TPossibleAnswer, TUserAnswer> : IExerciseRepository<TPossibleAnswer, TUserAnswer>
	{
		public void Save(Exercise<TPossibleAnswer, TUserAnswer>  exercise)
		{
			_exerciseDictionary[exercise.ExerciseId] = exercise;
		}

		public Exercise<TPossibleAnswer, TUserAnswer> Get(Guid exerciseId)
		{
			if (!_exerciseDictionary.ContainsKey(exerciseId))
				throw new ExerciseNotFoundException(exerciseId);
				
			return _exerciseDictionary[exerciseId];
		}

		public void Delete(Guid exerciseId)
		{
			if (!_exerciseDictionary.ContainsKey(exerciseId))
				throw new ExerciseNotFoundException(exerciseId);
			
			_exerciseDictionary.Remove(exerciseId);
		}

		private readonly Dictionary<Guid, Exercise<TPossibleAnswer, TUserAnswer>> _exerciseDictionary =
			new Dictionary<Guid, Exercise<TPossibleAnswer, TUserAnswer>>();
	}
}