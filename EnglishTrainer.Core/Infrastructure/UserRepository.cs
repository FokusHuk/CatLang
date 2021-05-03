using System;
using System.Data;
using System.Linq;
using Dapper;
using EnglishTrainer.Core.Domain.Entities;
using EnglishTrainer.Core.Domain.Repositories;

namespace EnglishTrainer.Core.Infrastructure
{
	public class UserRepository : IUserRepository
	{
		private readonly IDbConnection _connection;
		public UserRepository(IDbConnection connection)
		{
			_connection = connection ?? throw new ArgumentNullException(nameof(connection));
		}

		public User GetById(Guid userId)
		{
			var result = _connection
				.Query<User>(@"select * from LangTrainer.Users
                                    where Id = @Id",
					new {Id = userId})
				.ToList();

			return result.Single();
		}

		public User GetByLogin(string login)
		{
			var result = _connection
				.Query<User>(@"select * from LangTrainer.Users
                                    where Login = @Login",
					new {Login = login})
				.ToList();

			return result.Single();
		}

		public void Create(User user)
		{
			var a = _connection
				.Query<User>(@"insert into LangTrainer.Users
                (Id, Username, Login, PasswordHash) 
                VALUES (@Id, @Username, @Login, @PasswordHash)",
					new
					{
						Id = user.Id,
						Username = user.Username,
						Login = user.Credentials.Login,
						PasswordHash = user.Credentials.PasswordHash
					});
		}
	}
}
