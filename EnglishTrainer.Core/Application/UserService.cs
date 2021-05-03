using System;
using System.Collections.Generic;
using EnglishTrainer.Core.Domain.Entities;
using EnglishTrainer.Core.Domain.Repositories;

namespace EnglishTrainer.Core.Application
{
	public class UserService : IUserService
	{
		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
		}

		public Guid RegisterUser(string username, string login, string password)
		{
			if (username == null) throw new ArgumentNullException(nameof(username));
			if (password == null) throw new ArgumentNullException(nameof(password));

			var userId = Guid.NewGuid();
			var credentials = Credentials.FromLoginAndPassword(login, password);
			var user = new User(userId, username, credentials);
			_userRepository.Create(user);

			return userId;
		}

		public IEnumerable<StudiedWord> GetStudiedWords(Guid userId)
		{
			// TODO
			return null;
		}

		private readonly IUserRepository _userRepository;
	}
}