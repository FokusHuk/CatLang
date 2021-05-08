using System;
using System.Collections.Generic;
using EnglishTrainer.Core.Domain.Entities;

namespace EnglishTrainer.Core.Domain.Repositories
{
	public interface IWordsRepository
	{
		List<Word> GetAll();
		Word GetById(int wordId);
		void Create(Word word);
		List<Word> GetSetWords(Guid setId);
		void AddSetWord(Guid setId, int wordId);
		StudiedWordDto GetStudiedWord(Guid userId, int wordId);
		List<StudiedWordDto> GetStudiedWordsByUserId(Guid userId);
		void UpdateStudiedWord(StudiedWordDto studiedWordDto);
		void AddStudiedWord(StudiedWordDto studiedWordDto);
	}
}
