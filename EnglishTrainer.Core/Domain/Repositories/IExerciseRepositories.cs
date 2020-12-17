using EnglishTrainer.Core.Infrastructure;

namespace EnglishTrainer.Core.Domain.Repositories
{
    public interface IExerciseRepositories
    {
        ExerciseRepository<string, bool> ForSprint();
        ExerciseRepository<string[], string> ForChoice();
    }
}