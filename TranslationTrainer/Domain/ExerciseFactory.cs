using System;
using System.Linq;
using TranslationTrainer.Domain.Exercises;

namespace TranslationTrainer.Domain
{
	public class ExerciseFactory : IExerciseFactory
	{
		public ExerciseFactory(
			IUserRepository userRepository,
			IWordsRepository wordsRepository,
			TranslationTrainerSettings settings)
		{
			_wordsRepository = wordsRepository ?? throw new ArgumentNullException(nameof(wordsRepository));
			_settings = settings ?? throw new ArgumentNullException(nameof(settings));
		}

		public SprintExercise CreateSprintExercise(Guid userId, Guid exerciseId)
		{
			var random = new Random();
			var allWords = _wordsRepository.LoadAll().ToArray();
			var exerciseTasks = allWords
				.OrderBy(_ => random.Next())
				.Take(_settings.ExerciseWordsCount)
				.Select(word => GetSprintExerciseTask(exerciseId, word, allWords, random));
			
			return new SprintExercise(exerciseId, userId, exerciseTasks);
		}

		private static SprintExerciseTask GetSprintExerciseTask(
			Guid exerciseId,
			Word word,
			Word[] allWords,
			Random random)
		{
			var shouldReplaceTranslation = random.Next() % 2 == 0;
			
			if (!shouldReplaceTranslation)
			{
				return new SprintExerciseTask(
					exerciseId,
					word.Original,
					word.Translation,
					true);
			}

			var alternativeTranslation = allWords[random.Next(allWords.Length)].Translation;
			return new SprintExerciseTask(
				exerciseId,
				word.Original,
				alternativeTranslation,
				true);
		}

		private readonly IWordsRepository _wordsRepository;
		private readonly TranslationTrainerSettings _settings;
	}
}