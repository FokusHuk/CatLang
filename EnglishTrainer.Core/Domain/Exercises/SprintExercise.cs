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
			ExerciseTasks.Count(task => task.IsCompleted),
			ExerciseTasks.Count(task => !task.IsCompleted),
			ExerciseTasks.Any(task => task.IsCompleted),
			ExerciseTasks.FirstOrDefault(task => !task.IsCompleted));

		public void CommitAnswer(string original, bool answer)
		{
			ExerciseTasks.Single(task => task.Original == original).Answer = answer;
		}
		
		public IEnumerable<SprintExerciseResult> Result => ExerciseTasks
			.Select(task => new SprintExerciseResult(
				task.Original,
				task.Translation,
				task.Correct,
				task.Answer,
				task.Correct == task.Answer));
	}
}