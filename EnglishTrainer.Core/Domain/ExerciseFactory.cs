using System;
using System.Linq;
using EnglishTrainer.Core.Domain.Entities;
using EnglishTrainer.Core.Domain.Exercises;
using EnglishTrainer.Core.Domain.Repositories;

namespace EnglishTrainer.Core.Domain
{
	public class ExerciseFactory : IExerciseFactory
	{
		public ExerciseFactory(
			IWordsRepository wordsRepository,
			TranslationTrainerSettings settings)
		{
			_wordsRepository = wordsRepository ?? throw new ArgumentNullException(nameof(wordsRepository));
			_settings = settings ?? throw new ArgumentNullException(nameof(settings));
		}

		public Exercise<string, bool> CreateSprintExercise(Guid userId, Guid exerciseId)
		{
			var random = new Random();
			var allWords = _wordsRepository.LoadAll().ToArray();
			var exerciseTasks = allWords
				.OrderBy(_ => random.Next())
				.Take(_settings.ExerciseTasksCount)
				.Select(word => GetSprintExerciseTask(word, allWords));
			
			return new Exercise<string, bool>(exerciseId, userId, ExerciseType.Sprint, exerciseTasks);
		}
		
		public Exercise<string[], string> CreateChoiceExercise(Guid userId, Guid exerciseId)
		{
			var random = new Random();
			var allWords = _wordsRepository.LoadAll().ToArray();
			var exerciseTasks = allWords
				.OrderBy(_ => random.Next())
				.Take(_settings.ExerciseTasksCount)
				.Select(word => GetChoiceExerciseTask(word, allWords));
			
			return new Exercise<string[], string>(exerciseId, userId, ExerciseType.Choice, exerciseTasks);
		}
		
		private ExerciseTask<string, bool> GetSprintExerciseTask(Word word, Word[] allWords)
		{
			var random = new Random();
			var shouldReplaceTranslation = random.Next() % 2 == 0;
			
			if (!shouldReplaceTranslation)
			{
				return new ExerciseTask<string, bool>(
					word.Original,
					word.Translation,
					true);
			}

			var alternativeTranslation = allWords
				.Except(new[] {word})
				.ToArray()[random.Next(allWords.Length - 1)].Translation;
			return new ExerciseTask<string, bool>(
				word.Original,
				alternativeTranslation,
				false);
		}
		
		private ExerciseTask<string[], string> GetChoiceExerciseTask(Word word, Word[] allWords)
		{
			var random = new Random();
			var correctWordPosition = random.Next(_settings.WordsCountInChoiceExerciseTask);
			var translations = new string[_settings.WordsCountInChoiceExerciseTask];

			for (int i = 0; i < _settings.WordsCountInChoiceExerciseTask; i++)
			{
				if (i == correctWordPosition)
				{
					translations[i] = word.Translation;
				}
				else
				{
					translations[i] = allWords
						.Except(new[] {word})
						.ToArray()[random.Next(allWords.Length - 1)].Translation;
				}
			}

			return new ExerciseTask<string[], string>(
				word.Original,
				translations,
				word.Translation);
		}

		private readonly IWordsRepository _wordsRepository;
		private readonly TranslationTrainerSettings _settings;
	}
}