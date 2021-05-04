using System;
using EnglishTrainer.Core.Domain.Entities;

namespace EnglishTrainer.Core.Application
{
	public interface IUserService
	{
		Guid CreateUser(string username, string login, string password);
		User LoginUser(string login, string password);
	}
}