using System;

namespace EnglishTrainer.Core.Domain.Features
{
	public class TranslationTrainerSettings
	{
		public TranslationTrainerSettings(int exerciseTasksCount, int userWordsToCompletion, int wordsCountInChoiceExerciseTask)
		{
			if (exerciseTasksCount <= 0) throw new ArgumentOutOfRangeException(nameof(exerciseTasksCount));
			if (userWordsToCompletion <= 0) throw new ArgumentOutOfRangeException(nameof(userWordsToCompletion));
			if (wordsCountInChoiceExerciseTask <= 0) throw new ArgumentOutOfRangeException(nameof(wordsCountInChoiceExerciseTask));
			ExerciseTasksCount = exerciseTasksCount;
			UserWordsToCompletion = userWordsToCompletion;
			WordsCountInChoiceExerciseTask = wordsCountInChoiceExerciseTask;
		}

		public int ExerciseTasksCount { get; }
		
		public int WordsCountInChoiceExerciseTask { get; }

		public int UserWordsToCompletion { get; }
	}
}