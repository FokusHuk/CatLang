using System;
using System.Collections.Generic;
using EnglishTrainer.Core.Domain.Exercises;

namespace EnglishTrainer.Core.Domain.Repositories
{
    public interface IExerciseWordsRepository
    {
        List<ExerciseWordDto> GetExerciseWordsByExerciseId(Guid exerciseId);
        void AddExerciseWord(ExerciseWordDto exerciseWordDto);
        void DeleteExerciseWordsByExerciseId(Guid exerciseId);
    }
}