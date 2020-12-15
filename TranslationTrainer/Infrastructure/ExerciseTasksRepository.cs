using System;
using System.Collections.Generic;
using System.Linq;
using TranslationTrainer.Domain;
using TranslationTrainer.Domain.Exercises;

namespace TranslationTrainer.Infrastructure
{
    public class ExerciseTasksRepository: IExerciseTasksRepository
    {
        private readonly List<SprintExerciseTask> _sprintExerciseTasks = new List<SprintExerciseTask>();

        public IEnumerable<SprintExerciseTask> GetSprintExerciseTasks(Guid exerciseId)
        {
            return _sprintExerciseTasks.Where(task => task.ExerciseId == exerciseId);
        }

        public void SaveSprintExerciseTasks(IEnumerable<SprintExerciseTask> exerciseTasks)
        {
            _sprintExerciseTasks.AddRange(exerciseTasks);
        }
    }
}