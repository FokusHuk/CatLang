using System;
using System.Collections.Generic;
using EnglishTrainer.Core.Domain.Entities;

namespace EnglishTrainer.Core.Application
{
	public interface IUserService
	{
		void CreateUser(string username, string login, string password);
		bool LoginUser(string login, string password);
	}
}