using System;
using System.Collections.Generic;
using EnglishTrainer.Core.Domain.Entities;

namespace EnglishTrainer.Core.Domain.Repositories
{
	public interface IWordsRepository
	{
		List<Word> GetAll();
		Word GetById(int id);
		void Create(Word word);
		List<Word> GetSetWords(Guid setId);
		void AddSetWord(Guid setId, int wordId);
		List<StudiedWordDto> GetStudiedWordsByUserId(Guid userId);
		void AddStudiedWord(StudiedWordDto studiedWordDto);
	}
}
