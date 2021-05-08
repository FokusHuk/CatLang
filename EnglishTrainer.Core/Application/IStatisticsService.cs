using System;
using System.Collections.Generic;
using EnglishTrainer.Core.Domain.Exercises;

namespace EnglishTrainer.Core.Application
{
    public interface IStatisticsService
    {
        void UpdateUserStudiedWords(Guid userId, List<ExerciseWordDto> newStudiedWords);
        void UpdateUserStudiedSet(Guid userId, List<ExerciseWordDto> newStudiedWords);
    }
}
