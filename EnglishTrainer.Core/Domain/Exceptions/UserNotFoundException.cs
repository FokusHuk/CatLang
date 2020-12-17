using System;

namespace EnglishTrainer.Core.Domain.Exceptions
{
	public class UserNotFoundException : Exception
	{
		public UserNotFoundException(Guid userId) : base($"User with id {userId} not found")
		{
		}
	}
}