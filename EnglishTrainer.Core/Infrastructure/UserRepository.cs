using System;
using System.Linq;
using EnglishTrainer.Core.Domain.Entities;
using EnglishTrainer.Core.Domain.Repositories;

namespace EnglishTrainer.Core.Infrastructure
{
	public class UserRepository : IUserRepository
	{
		public IUser Load(Guid userId)
		{
			return new User(
				userId,
				Credentials.FromLoginAndPassword("login", "password"),
				Enumerable.Empty<StudiedWord>());
		}

		public IUser Load(string login)
		{
			return new User(
				Guid.NewGuid(),
				Credentials.FromLoginAndPassword("login", "password"),
				Enumerable.Empty<StudiedWord>());
		}

		public void Save(IUser user)
		{
			
		}
	}
}