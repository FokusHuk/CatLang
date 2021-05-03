using System;
using System.Linq;
using EnglishTrainer.Core.Domain.Entities;
using EnglishTrainer.Core.Domain.Repositories;

namespace EnglishTrainer.Core.Infrastructure
{
	public class UserRepository : IUserRepository
	{
		public User GetById(Guid userId)
		{
			return new User(
				userId,
				Credentials.FromLoginAndPassword("login", "password"));
		}

		public User GetByLogin(string login)
		{
			return new User(
				Guid.NewGuid(),
				Credentials.FromLoginAndPassword("login", "password"));
		}

		public void Create(User user)
		{
			
		}
	}
}
