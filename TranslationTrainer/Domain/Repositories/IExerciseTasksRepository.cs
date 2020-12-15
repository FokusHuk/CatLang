using System;
using System.Collections.Generic;
using TranslationTrainer.Domain.Exercises;

namespace TranslationTrainer.Domain
{
    public interface IExerciseTasksRepository
    {
        IEnumerable<SprintExerciseTask> GetSprintExerciseTasks(Guid exerciseId);
        void SaveSprintExerciseTasks(IEnumerable<SprintExerciseTask> exerciseTasks);
    }
}