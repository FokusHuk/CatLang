using System.Collections.Generic;
using TranslationTrainer.Domain.Entities;

namespace TranslationTrainer.Domain.Repositories
{
	public interface IWordsRepository
	{
		IEnumerable<Word> LoadAll();
	}
}