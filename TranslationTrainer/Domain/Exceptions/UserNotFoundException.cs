using System;

namespace TranslationTrainer.Domain.Exceptions
{
	public class UserNotFoundException : Exception
	{
		public UserNotFoundException(Guid userId) : base($"User with id {userId} not found")
		{
		}

		public UserNotFoundException(string message) : base(message)
		{
		}

		public UserNotFoundException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}