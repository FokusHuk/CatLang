using System;
using EnglishTrainer.Core.Domain.Entities;

namespace EnglishTrainer.Core.Domain.Repositories
{
	public interface IUserRepository
	{
		IUser Load(Guid userId);
		IUser Load(string login);
		void Save(IUser user);
	}
}