using System;
using System.Collections.Generic;
using TranslationTrainer.Domain;
using TranslationTrainer.Domain.Exercises;

namespace TranslationTrainer.Infrastructure
{
	public class ExerciseRepository : IExerciseRepository
	{
		public void SaveExercise(SprintExercise exercise)
		{
			_sprintExerciseDictionary[exercise.ExerciseId] = exercise;
		}

		public SprintExercise GetSprintExercise(Guid exerciseId)
		{
			return _sprintExerciseDictionary[exerciseId];
		}

		public void DeleteSprintExercise(Guid exerciseId)
		{
			_sprintExerciseDictionary.Remove(exerciseId);
		}

		private readonly Dictionary<Guid, SprintExercise> _sprintExerciseDictionary =
			new Dictionary<Guid, SprintExercise>();
	}
}