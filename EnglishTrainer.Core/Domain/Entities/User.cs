using System;

namespace EnglishTrainer.Core.Domain.Entities
{
	public class User
	{
		public User(Guid id, string username, string login, string passwordHash)
		{
			Id = id;
			Username = username;
			Login = login;
			PasswordHash = passwordHash;
		}

		public User()
		{
			
		}

		public Guid Id { get; }
		public string Username { get; set; }
		public string Login { get; }
		public string PasswordHash { get; }
	}
}
