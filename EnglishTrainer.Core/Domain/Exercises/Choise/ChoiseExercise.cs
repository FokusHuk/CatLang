using System;
using System.Collections.Generic;
using System.Linq;
using EnglishTrainer.Core.Domain.Exceptions;

namespace EnglishTrainer.Core.Domain.Exercises.Choise
{
    public class ChoiceExercise
    {
        public ChoiceExercise(Guid exerciseId, Guid userId, IEnumerable<ChoiceExerciseTask> exerciseTasks)
        {
            ExerciseId = exerciseId;
            UserId = userId;
            ExerciseTasks = new List<ChoiceExerciseTask>(exerciseTasks);
        }
        
        public Guid ExerciseId { get; }
		
        public Guid UserId { get; }
        
        public List<ChoiceExerciseTask> ExerciseTasks { get; }
        
        public ChoiceExerciseStatus Status() => new ChoiceExerciseStatus(
            ExerciseId,
            ExerciseTasks.Count(task => task.IsCompleted),
            ExerciseTasks.Count(task => !task.IsCompleted),
            ExerciseTasks.TrueForAll(task => task.IsCompleted),
            ExerciseTasks.FirstOrDefault(task => !task.IsCompleted));
        
        public void CommitAnswer(string original, string answer)
        {
            if (ExerciseTasks.All(task => task.IsCompleted))
                throw new AllExerciseTasksCompletedException(ExerciseId);

            if (!ExerciseTasks
                .Where(task => !task.IsCompleted)
                .Select(task => task.Original)
                .Contains(original))
                throw new ExerciseTasksWordNotFoundException(ExerciseId, original);
			
            ExerciseTasks.Single(task => task.Original == original).Answer = answer;
        }
        
        public ChoiceExerciseResult Result() => new ChoiceExerciseResult(
            ExerciseTasks.Count(task => task.Answer == task.Correct),
            ExerciseTasks.Count(task => task.Answer != task.Correct),
            ExerciseTasks
                .Select(task => new ChoiceExerciseTaskResult(
                    task.Original,
                    task.Translations,
                    task.Correct,
                    task.Answer,
                    task.Correct == task.Answer)));
    }
}