﻿using System;
using System.Collections.Generic;
using EnglishTrainer.Core.Domain.Exceptions;
using EnglishTrainer.Core.Domain.Exercises;
using EnglishTrainer.Core.Domain.Repositories;

namespace EnglishTrainer.Core.Infrastructure
{
	public class ExerciseRepository : IExerciseRepository
	{
		public void SaveExercise(SprintExercise exercise)
		{
			_sprintExerciseDictionary[exercise.ExerciseId] = exercise;
		}

		public SprintExercise GetSprintExercise(Guid exerciseId)
		{
			if (!_sprintExerciseDictionary.ContainsKey(exerciseId))
				throw new ExerciseNotFoundException(exerciseId);
				
			return _sprintExerciseDictionary[exerciseId];
		}

		public void DeleteSprintExercise(Guid exerciseId)
		{
			if (!_sprintExerciseDictionary.ContainsKey(exerciseId))
				throw new ExerciseNotFoundException(exerciseId);
			
			_sprintExerciseDictionary.Remove(exerciseId);
		}

		private readonly Dictionary<Guid, SprintExercise> _sprintExerciseDictionary =
			new Dictionary<Guid, SprintExercise>();
	}
}