using System;

namespace EnglishTrainer.Core.Domain.Entities
{
	public class User
	{
		public User(Guid id, string username, Credentials credentials)
		{
			Id = id;
			Username = username;
			Credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
		}

		public Guid Id { get; }
		public string Username { get; set; }
		public Credentials Credentials { get; }
	}
}
