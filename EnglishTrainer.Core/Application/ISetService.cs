using System;
using System.Collections.Generic;
using EnglishTrainer.Core.Domain.Entities;

namespace EnglishTrainer.Core.Application
{
    public interface ISetService
    {
        List<WordsSet> GetAllSets();
        WordsSet GetSetById(Guid setId);
        Guid CreateSet(Guid userId, string studyTopic, List<int> setWordsIds);
    }
}