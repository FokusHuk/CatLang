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
        List<StudiedSetDto> GetStudiedSetsBySetId(Guid setId);
        List<StudiedSetDto> GetStudiedSetsByUserId(Guid userId);
        StudiedSetDto GetStudiedSet(Guid userId, Guid setId);
        void AddStudiedSet(StudiedSetDto studiedSetDto);
    }
}