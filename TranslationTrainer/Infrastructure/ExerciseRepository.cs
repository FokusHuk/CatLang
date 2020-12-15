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

		private readonly Dictionary<Guid, SprintExercise> _sprintExerciseDictionary =
			new Dictionary<Guid, SprintExercise>();
	}
}