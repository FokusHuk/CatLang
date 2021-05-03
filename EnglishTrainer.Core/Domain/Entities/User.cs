using System;
using System.Collections.Generic;

namespace EnglishTrainer.Core.Domain.Entities
{
	public class User
	{
		public User(Guid id, Credentials credentials, IEnumerable<StudiedWord> studiedWords)
		{
			Id = id;
			Credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
		}

		public Guid Id { get; }

		public Credentials Credentials { get; }
	}
}
