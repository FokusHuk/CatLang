using System;
using System.Collections.Generic;
using EnglishTrainer.Core.Domain.Exceptions;
using EnglishTrainer.Core.Domain.Exercises;
using EnglishTrainer.Core.Domain.Exercises.Choise;
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

		
		public void SaveExercise(ChoiceExercise exercise)
		{
			_choiceExerciseDictionary[exercise.ExerciseId] = exercise;
		}

		public ChoiceExercise GetChoiceExercise(Guid exerciseId)
		{
			if (!_choiceExerciseDictionary.ContainsKey(exerciseId))
				throw new ExerciseNotFoundException(exerciseId);
				
			return _choiceExerciseDictionary[exerciseId];
		}

		public void DeleteChoiceExercise(Guid exerciseId)
		{
			if (!_choiceExerciseDictionary.ContainsKey(exerciseId))
				throw new ExerciseNotFoundException(exerciseId);
			
			_choiceExerciseDictionary.Remove(exerciseId);
		}
		
		private readonly Dictionary<Guid, SprintExercise> _sprintExerciseDictionary =
			new Dictionary<Guid, SprintExercise>();
		
		private readonly Dictionary<Guid, ChoiceExercise> _choiceExerciseDictionary =
			new Dictionary<Guid, ChoiceExercise>();
	}
}