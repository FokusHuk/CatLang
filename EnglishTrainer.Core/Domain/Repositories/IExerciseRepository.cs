using System;
using EnglishTrainer.Core.Domain.Exercises;
using EnglishTrainer.Core.Domain.Exercises.Choise;

namespace EnglishTrainer.Core.Domain.Repositories
{
	public interface IExerciseRepository
	{
		void SaveExercise(SprintExercise exercise);
		SprintExercise GetSprintExercise(Guid exerciseId);
		void DeleteSprintExercise(Guid exerciseId);

		void SaveExercise(ChoiceExercise exercise);
		ChoiceExercise GetChoiceExercise(Guid exerciseId);
		void DeleteChoiceExercise(Guid exerciseId);
	}
}