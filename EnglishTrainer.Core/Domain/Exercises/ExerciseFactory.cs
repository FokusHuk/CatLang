using System;
using System.Collections.Generic;
using System.Linq;
using EnglishTrainer.Core.Domain.Entities;
using EnglishTrainer.Core.Domain.Exercises;
using EnglishTrainer.Core.Domain.Repositories;

namespace EnglishTrainer.Core.Domain
{
	public class ExerciseFactory : IExerciseFactory
	{
		private readonly IWordsRepository _wordsRepository;

		public ExerciseFactory(IWordsRepository wordsRepository)
		{
			_wordsRepository = wordsRepository ?? throw new ArgumentNullException(nameof(wordsRepository));
		}

		public ConformityExercise GetConformityExercise(ExerciseFormat format, Guid setId)
		{
			var random = new Random();
			var setWords = _wordsRepository.GetSetWords(setId);

			var exerciseId = Guid.NewGuid();
			var exerciseTasks = setWords
				.OrderBy(_ => random.Next())
				.Select(word => GetConformityExerciseTask(format, word, setWords))
				.ToList();

			return new ConformityExercise(exerciseId, setId, exerciseTasks);
		}
		
		private ConformityExerciseTask GetConformityExerciseTask(ExerciseFormat format, Word word, List<Word> setWords)
		{
			var random = new Random();
			var shouldReplaceTranslation = random.Next() % 2 == 0;
			var taskWord = format == ExerciseFormat.EnRu ? word : word.SwapOriginalAndTranslation();

			if (!shouldReplaceTranslation)
			{
				return new ConformityExerciseTask(
					word.Id,
					taskWord.Original,
					taskWord.Translation);
			}

			var alternativeWord = setWords
				.Where(sw => sw.Id != word.Id)
				.ToArray()
				[random.Next(setWords.Count - 1)];

			var answerWord = format == ExerciseFormat.EnRu
				? alternativeWord.Translation
				: alternativeWord.Original;

			return new ConformityExerciseTask(
				word.Id,
				taskWord.Original,
				answerWord);
		}
		
		public ChoiceExercise GetChoiceExercise(ExerciseFormat format, Guid setId)
		{
			var random = new Random();
			var setWords = _wordsRepository.GetSetWords(setId);

			var exerciseId = Guid.NewGuid();
			var exerciseTasks = setWords
				.OrderBy(_ => random.Next())
				.Select(word => GetChoiceExerciseTask(format, word, setWords))
				.ToList();

			return new ChoiceExercise(exerciseId, setId, exerciseTasks);
		}

		private ChoiceExerciseTask GetChoiceExerciseTask(ExerciseFormat format, Word word, List<Word> setWords)
		{
			var random = new Random();
			var correctWordPosition = random.Next(4);
			var translations = new string[4];
			var taskWord = format == ExerciseFormat.EnRu ? word : word.SwapOriginalAndTranslation();

			for (int i = 0; i < 4; i++)
			{
				if (i == correctWordPosition)
				{
					translations[i] = taskWord.Translation;
				}
				else
				{
					var alternativeWord = setWords
						.Where(sw => sw.Id != word.Id)
						.ToArray()
						[random.Next(setWords.Count - 1)];

					translations[i] = format == ExerciseFormat.EnRu
						? alternativeWord.Translation
						: alternativeWord.Original;
				}
			}

			if (format == ExerciseFormat.RuEn)
				word = word.SwapOriginalAndTranslation();

			return new ChoiceExerciseTask(
				word.Id,
				taskWord.Original,
				translations);
		}
	}
}
