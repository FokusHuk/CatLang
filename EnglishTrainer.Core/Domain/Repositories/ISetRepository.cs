using System;
using System.Collections.Generic;
using EnglishTrainer.Core.Domain.Entities;

namespace EnglishTrainer.Core.Domain.Repositories
{
    public interface ISetRepository
    {
        List<WordsSetDto> GetAll();
        WordsSetDto GetById(Guid id);
        void Create(WordsSetDto setDto);
    }
}