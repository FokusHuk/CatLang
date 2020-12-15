using System.Collections.Generic;
using EnglishTrainer.Core.Domain.Entities;

namespace EnglishTrainer.Core.Domain.Repositories
{
	public interface IWordsRepository
	{
		IEnumerable<Word> LoadAll();
	}
}