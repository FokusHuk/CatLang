using System;
using System.Collections.Generic;
using EnglishTrainer.Core.Domain.Entities;

namespace EnglishTrainer.Core.Domain.Repositories
{
    public interface ISetRepository
    {
        List<WordsSetDto> GetAll();
        WordsSetDto GetById(Guid setId);
        void Create(WordsSetDto setDto);
        void UpdateSet(WordsSetDto setDto);
    }
}
