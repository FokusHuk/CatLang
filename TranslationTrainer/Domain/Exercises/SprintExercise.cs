using System;
using System.Collections.Generic;
using System.Linq;

namespace TranslationTrainer.Domain.Exercises
{
	public class SprintExercise
	{
		public SprintExercise(Guid exerciseId, Guid userId, IEnumerable<SprintExerciseTask> exerciseTasks)
		{
			ExerciseId = exerciseId;
			UserId = userId;
			ExerciseTasks = exerciseTasks;
		}
		
		public Guid ExerciseId { get; }
		
		public Guid UserId { get; }
		
		public IEnumerable<SprintExerciseTask> ExerciseTasks { get; }

		public SprintExerciseStatus Status => new SprintExerciseStatus(
			ExerciseId,
			ExerciseTasks.Count(task => task.Answer == null),
			ExerciseTasks.Count(task => task.Answer != null),
			ExerciseTasks.Any(task => task.Answer != null),
			ExerciseTasks.FirstOrDefault(task => task.Answer == null));
	}
}