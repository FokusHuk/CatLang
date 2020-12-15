using System;
using System.Collections.Generic;

namespace TranslationTrainer.Domain.Entities
{
	public interface IUser
	{
		Guid Id { get; }
		Credentials Credentials { get; }
		IEnumerable<StudiedWord> StudiedWords { get; }
		void MarkStudied(Word word, bool correctTranslationChosen);
	}
}