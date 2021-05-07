using System;
using System.Security.Authentication;
using EnglishTrainer.Core.Domain.Entities;
using EnglishTrainer.Core.Domain.Features;
using EnglishTrainer.Core.Domain.Repositories;

namespace EnglishTrainer.Core.Application
{
	public class UserService : IUserService
	{
		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
		}

		public Guid CreateUser(string username, string login, string password)
		{
			var passwordHash = _hashingPassword.HashPassword(password);
			var userId = Guid.NewGuid();

			var user = new User(userId, username, login, passwordHash);
			
			_userRepository.Create(user);

			return userId;
		}

		public User LoginUser(string login, string password)
		{
			var user = _userRepository.GetByLogin(login);

			if (!_hashingPassword.Verify(password, user.PasswordHash))
				throw new AuthenticationException(user.Username);

			return user;
		}

		private readonly IUserRepository _userRepository;
		private readonly IHashingPassword _hashingPassword = new ShaHashing();
	}
}
