using System;
using System.Collections.Generic;
using EnglishTrainer.Core.Domain.Entities;

namespace EnglishTrainer.Core.Domain.Repositories
{
    public interface IStudiedSetsRepository
    {
        List<StudiedSetDto> GetStudiedSetsBySetId(Guid setId);
        List<StudiedSetDto> GetStudiedSetsByUserId(Guid userId);
        StudiedSetDto GetStudiedSet(Guid userId, Guid setId);
        void UpdateStudiedSet(StudiedSetDto studiedSetDto);
        void AddStudiedSet(StudiedSetDto studiedSetDto);
    }
}
