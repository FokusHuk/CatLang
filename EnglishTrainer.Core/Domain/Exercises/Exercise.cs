using System;
using System.Collections.Generic;
using System.Linq;
using EnglishTrainer.Core.Domain.Exceptions;

namespace EnglishTrainer.Core.Domain.Exercises
{
    public class Exercise<TOption, TAnswer>
    {
        public Exercise(Guid exerciseId, 
            Guid userId, 
            ExerciseType type, 
            IEnumerable<ExerciseTask<TOption, TAnswer>> exerciseTasks)
        {
            ExerciseId = exerciseId;
            UserId = userId;
            Type = type;
            ExerciseTasks = new List<ExerciseTask<TOption, TAnswer>>(exerciseTasks);
        }
		
        public Guid ExerciseId { get; }
		
        public Guid UserId { get; }
        
        public ExerciseType Type { get; }
		
        public List<ExerciseTask<TOption, TAnswer>> ExerciseTasks { get; }

        public ExerciseStatus<TOption, TAnswer> Status() => new ExerciseStatus<TOption, TAnswer>(
            ExerciseId,
            ExerciseTasks.Count(task => task.IsCompleted),
            ExerciseTasks.Count(task => !task.IsCompleted),
            ExerciseTasks.TrueForAll(task => task.IsCompleted),
            ExerciseTasks.FirstOrDefault(task => !task.IsCompleted));

        public void CommitAnswer(string original, TAnswer answer)
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
		
        public ExerciseResult<TOption, TAnswer> Result() => new ExerciseResult<TOption, TAnswer>(
            ExerciseTasks.Count(task => Equals(task.Answer, task.Correct)),
            ExerciseTasks.Count(task => !Equals(task.Answer, task.Correct)),
            ExerciseTasks
                .Select(task => new ExerciseTaskResult<TOption, TAnswer>(
                    task.Original,
                    task.PossibleAnswer,
                    task.Correct,
                    task.Answer,
                    Equals(task.Correct, task.Answer))));
    }
}