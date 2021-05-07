using System;
using System.Collections.Generic;

namespace EnglishTrainer.Core.Domain.Exercises
{
    public class ChoiceExercise
    {
        public ChoiceExercise(Guid id, Guid setId, List<ChoiceExerciseTask> tasks)
        {
            Id = id;
            SetId = setId;
            Tasks = tasks;
        }
        
        public Guid Id { get; }
        public Guid SetId { get; }
        public List<ChoiceExerciseTask> Tasks { get; }
    }
}
