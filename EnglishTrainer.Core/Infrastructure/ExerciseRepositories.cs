using EnglishTrainer.Core.Domain.Repositories;

namespace EnglishTrainer.Core.Infrastructure
{
    public class ExerciseRepositories : IExerciseRepositories
    {
        public ExerciseRepository<string, bool> ForSprint()
        {
            return _sprintExerciseRepository;
        }
        
        public ExerciseRepository<string[], string> ForChoice()
        {
            return _choiceExerciseRepository;
        }

        private ExerciseRepository<string, bool> _sprintExerciseRepository = new ExerciseRepository<string, bool>();
        private ExerciseRepository<string[], string> _choiceExerciseRepository = 
            new ExerciseRepository<string[], string>();
    }
}