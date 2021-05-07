using System;
using System.Collections.Generic;

namespace EnglishTrainer.Core.Domain.Exercises
{
    public class ConformityExercise
    {
        public ConformityExercise(Guid id, Guid setId, List<ConformityExerciseTask> tasks)
        {
            Id = id;
            SetId = setId;
            Tasks = tasks;
        }
        
        public Guid Id { get; }
        public Guid SetId { get; }
        public List<ConformityExerciseTask> Tasks { get; }
    }
}
