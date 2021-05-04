using System.Collections.Generic;
using EnglishTrainer.Core.Domain.Entities;

namespace EnglishTrainer.Core.Domain.Repositories
{
	public interface IWordsRepository
	{
		List<Word> GetAll();
		Word GetById(int id);
		void Create(Word word);
	}
}
