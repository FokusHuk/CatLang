using System;
using EnglishTrainer.Core.Domain;
using EnglishTrainer.Core.Domain.Entities;
using EnglishTrainer.Core.Domain.Repositories;
using EnglishTrainer.Core.Infrastructure;

namespace EnglishTrainer.Core.Application
{
	public class UserService : IUserService
	{
		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
		}

		public void CreateUser(string username, string login, string password)
		{
			var passwordHash = _hashingPassword.HashPassword(password);
			var userId = Guid.NewGuid();

			var user = new User(userId, username, login, passwordHash);
			
			_userRepository.Create(user);
		}

		public bool LoginUser(string login, string password)
		{
			var user = _userRepository.GetByLogin(login);

			return _hashingPassword.Verify(password, user.PasswordHash);
		}

		private readonly IUserRepository _userRepository;
		private readonly IHashingPassword _hashingPassword = new ShaHashing();
	}
}
