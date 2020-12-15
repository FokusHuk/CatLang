using System;
using System.Collections.Generic;

namespace TranslationTrainer.Domain
{
	public class ExerciseStatus
	{
		public ExerciseStatus(
			Guid exerciseId,
			int wordsDone,
			int wordsLeft,
			bool isFinished,
			ExercisedWord currentWord,
			IEnumerable<ExercisedWord> wordsConsideredCorrect,
			IEnumerable<ExercisedWord> wordsConsideredIncorrect)
		{
			TasksDone = wordsDone;
			TasksLeft = wordsLeft;
			IsFinished = isFinished;
			CurrentWord = currentWord;
			WordsConsideredCorrect = wordsConsideredCorrect;
			WordsConsideredIncorrect = wordsConsideredIncorrect;
			ExerciseId = exerciseId;
		}

		public Guid ExerciseId { get; }
		public int TasksDone { get; }
		public int TasksLeft { get; }
		public bool IsFinished { get; }
		public ExercisedWord CurrentWord { get; }
		public IEnumerable<ExercisedWord> WordsConsideredCorrect { get; }
		public IEnumerable<ExercisedWord> WordsConsideredIncorrect { get; }
	}
}