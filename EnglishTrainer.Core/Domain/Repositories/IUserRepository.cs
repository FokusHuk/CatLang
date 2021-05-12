using System;
using System.Collections.Generic;
using EnglishTrainer.Core.Domain.Entities;

namespace EnglishTrainer.Core.Domain.Repositories
{
	public interface IUserRepository
	{
		List<User> GetAll();
		User GetById(Guid userId);
		User GetByLogin(string login);
		void Create(User user);
	}
}
