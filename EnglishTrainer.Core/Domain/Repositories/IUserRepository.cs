using System;
using EnglishTrainer.Core.Domain.Entities;

namespace EnglishTrainer.Core.Domain.Repositories
{
	public interface IUserRepository
	{
		User Load(Guid userId);
		User Load(string login);
		void Save(User user);
	}
}