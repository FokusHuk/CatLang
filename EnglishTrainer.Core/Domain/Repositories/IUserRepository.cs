using System;
using EnglishTrainer.Core.Domain.Entities;

namespace EnglishTrainer.Core.Domain.Repositories
{
	public interface IUserRepository
	{
		User GetById(Guid userId);
		User GetByLogin(string login);
		void Create(User user);
	}
}
