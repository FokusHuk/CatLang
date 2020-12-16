using System;
using System.Linq;
using EnglishTrainer.Core.Domain.Entities;
using EnglishTrainer.Core.Domain.Exercises;
using EnglishTrainer.Core.Domain.Exercises.Choise;
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

		public SprintExercise CreateSprintExercise(Guid userId, Guid exerciseId)
		{
			var random = new Random();
			var allWords = _wordsRepository.LoadAll().ToArray();
			var exerciseTasks = allWords
				.OrderBy(_ => random.Next())
				.Take(_settings.ExerciseTasksCount)
				.Select(word => GetSprintExerciseTask(word, allWords));
			
			return new SprintExercise(exerciseId, userId, exerciseTasks);
		}
		
		public ChoiceExercise CreateChoiceExercise(Guid userId, Guid exerciseId)
		{
			var random = new Random();
			var allWords = _wordsRepository.LoadAll().ToArray();
			var exerciseTasks = allWords
				.OrderBy(_ => random.Next())
				.Take(_settings.ExerciseTasksCount)
				.Select(word => GetChoiceExerciseTask(word, allWords));
			
			return new ChoiceExercise(exerciseId, userId, exerciseTasks);
		}

		private SprintExerciseTask GetSprintExerciseTask(Word word, Word[] allWords)
		{
			var random = new Random();
			var shouldReplaceTranslation = random.Next() % 2 == 0;
			
			if (!shouldReplaceTranslation)
			{
				return new SprintExerciseTask(
					word.Original,
					word.Translation,
					true);
			}

			var alternativeTranslation = allWords[random.Next(allWords.Length)].Translation;
			return new SprintExerciseTask(
				word.Original,
				alternativeTranslation,
				false);
		}
		
		private ChoiceExerciseTask GetChoiceExerciseTask(Word word, Word[] allWords)
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

			return new ChoiceExerciseTask(
				word.Original,
				translations,
				word.Translation);
		}

		private readonly IWordsRepository _wordsRepository;
		private readonly TranslationTrainerSettings _settings;
	}
}