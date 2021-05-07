using System;
using System.Collections.Generic;
using System.Linq;
using EnglishTrainer.Core.Domain.Entities;
using EnglishTrainer.Core.Domain.Features;
using EnglishTrainer.Core.Domain.Repositories;

namespace EnglishTrainer.Core.Domain.Exercises
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

			var correctTasksCount = (int) (Math.Round(0.35 * setWords.Count));
			var mixedSetWords = setWords.OrderBy(_ => random.Next()).ToList();
			var wrongSetWords = GetIncorrectSetWords(mixedSetWords.Skip(correctTasksCount).ToList(), format);
			var exerciseWords = mixedSetWords.Take(correctTasksCount).ToList();
			exerciseWords.AddRange(wrongSetWords);

			var exerciseTasks = exerciseWords
				.OrderBy(_ => random.Next())
				.Select(word => GetConformityExerciseTask(format, word))
				.ToList();

			return new ConformityExercise(exerciseId, setId, exerciseTasks);
		}

		private List<Word> GetIncorrectSetWords(List<Word> words, ExerciseFormat format)
		{
			var random = new Random();
			
			if (format == ExerciseFormat.EnRu)
			{
				var translations = words
					.Select(w => w.Translation)
					.OrderBy(_ => random.Next())
					.ToList();

				for (int i = 0; i < words.Count; i++)
				{
					words[i].Translation = translations[i];
				}

				return words;
			}
			else
			{
				var originals = words
					.Select(w => w.Original)
					.OrderBy(_ => random.Next())
					.ToList();

				for (int i = 0; i < words.Count; i++)
				{
					words[i].Original = originals[i];
				}

				return words;
			}
		}
		
		private ConformityExerciseTask GetConformityExerciseTask(ExerciseFormat format, Word word)
		{
			return format == ExerciseFormat.EnRu
				? new ConformityExerciseTask(word.Id, word.Original, word.Translation)
				: new ConformityExerciseTask(word.Id, word.Translation, word.Original);
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
			var usedAnswerWords = new List<int>();

			for (int i = 0; i < 4; i++)
			{
				if (i == correctWordPosition)
				{
					translations[i] = taskWord.Translation;
				}
				else
				{
					var alternativeWords = setWords
						.Where(sw => sw.Id != word.Id && !usedAnswerWords.Contains(sw.Id))
						.ToArray();
					
					var alternativeWord = alternativeWords[random.Next(alternativeWords.Length - 1)];

					translations[i] = format == ExerciseFormat.EnRu
						? alternativeWord.Translation
						: alternativeWord.Original;

					usedAnswerWords.Add(alternativeWord.Id);
				}
			}

			return new ChoiceExerciseTask(
				word.Id,
				taskWord.Original,
				translations);
		}
	}
}
