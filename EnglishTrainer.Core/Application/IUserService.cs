using System;
using System.Collections.Generic;
using EnglishTrainer.Core.Domain.Entities;

namespace EnglishTrainer.Core.Application
{
	public interface IUserService
	{
		Guid RegisterUser(string username, string login, string password);

		IEnumerable<StudiedWord> GetStudiedWords(Guid userId);
	}
}