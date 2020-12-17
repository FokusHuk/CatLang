using System;
using EnglishTrainer.Core.Domain.Exercises;

namespace EnglishTrainer.Core.Domain.Repositories
{
	public interface IExerciseRepository<TPossibleAnswer, TUserAnswer>
	{
		void Save(Exercise<TPossibleAnswer, TUserAnswer> exercise);
		Exercise<TPossibleAnswer, TUserAnswer> Get(Guid exerciseId);
		void Delete(Guid exerciseId);
	}
}