using System;
using TranslationTrainer.Domain.Entities;

namespace TranslationTrainer.Domain.Repositories
{
	public interface IUserRepository
	{
		IUser Load(Guid userId);
		IUser Load(string login);
		void Save(IUser user);
	}
}