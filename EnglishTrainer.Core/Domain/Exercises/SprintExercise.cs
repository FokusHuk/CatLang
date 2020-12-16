using System;
using System.Collections.Generic;
using System.Linq;

namespace EnglishTrainer.Core.Domain.Exercises
{
	public class SprintExercise
	{
		public SprintExercise(Guid exerciseId, Guid userId, IEnumerable<SprintExerciseTask> exerciseTasks)
		{
			ExerciseId = exerciseId;
			UserId = userId;
			ExerciseTasks = new List<SprintExerciseTask>(exerciseTasks);
		}
		
		public Guid ExerciseId { get; }
		
		public Guid UserId { get; }
		
		public List<SprintExerciseTask> ExerciseTasks { get; }

		public SprintExerciseStatus Status() => new SprintExerciseStatus(
			ExerciseId,
			ExerciseTasks.Count(task => task.IsCompleted),
			ExerciseTasks.Count(task => !task.IsCompleted),
			ExerciseTasks.TrueForAll(task => task.IsCompleted),
			ExerciseTasks.FirstOrDefault(task => !task.IsCompleted));

		public void CommitAnswer(string original, bool answer)
		{
			ExerciseTasks.Single(task => task.Original == original).Answer = answer;
		}
		
		public SprintExerciseResult Result() => new SprintExerciseResult(
			ExerciseTasks.Count(task => task.Answer == task.Correct),
			ExerciseTasks.Count(task => task.Answer != task.Correct),
			ExerciseTasks
			.Select(task => new SprintExerciseTaskResult(
				task.Original,
				task.Translation,
				task.Correct,
				task.Answer,
				task.Correct == task.Answer)));
	}
}