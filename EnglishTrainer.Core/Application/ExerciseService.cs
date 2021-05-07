using System;
using System.Linq;
using EnglishTrainer.Core.Domain;
using EnglishTrainer.Core.Domain.Exercises;
using EnglishTrainer.Core.Domain.Repositories;

namespace EnglishTrainer.Core.Application
{
	public class ExerciseService : IExerciseService
	{
		public ExerciseService(
			IExerciseFactory exerciseFactory,
			IWordsRepository wordsRepository,
			IExerciseWordsRepository exerciseWordsRepository)
		{
			_exerciseFactory = exerciseFactory ?? throw new ArgumentNullException(nameof(exerciseFactory));
			_wordsRepository = wordsRepository;
			_exerciseWordsRepository = exerciseWordsRepository;
		}

		public ConformityExercise CreateConformityExercise(ExerciseFormat format, Guid setId)
		{
			var exercise = _exerciseFactory.GetConformityExercise(format, setId);

			return exercise;
		}
		
		public ChoiceExercise CreateChoiceExercise(ExerciseFormat format, Guid setId)
		{
			var exercise = _exerciseFactory.GetChoiceExercise(format, setId);

			return exercise;
		}

		public void CommitConformityAnswer(
			ExerciseFormat format, 
			Guid exerciseId, 
			Guid setId, 
			int wordId, 
			string taskAnswer, 
			bool userChoice)
		{
			var date = DateTime.Now;
			var word = _wordsRepository.GetById(wordId);
			var isCorrect = format == ExerciseFormat.EnRu
				? word.Translation == taskAnswer
				: word.Original == taskAnswer;
			isCorrect = isCorrect == userChoice;
			
			var exerciseWordDto = new ExerciseWordDto(0, exerciseId, setId, wordId, taskAnswer, date, isCorrect);
			
			_exerciseWordsRepository.AddExerciseWord(exerciseWordDto);
		}
		
		public void CommitChoiceAnswer(
			ExerciseFormat format, 
			Guid exerciseId, 
			Guid setId, 
			int wordId, 
			string chosenAnswer)
		{
			var date = DateTime.Now;
			var word = _wordsRepository.GetById(wordId);
			var isCorrect = format == ExerciseFormat.EnRu
				? word.Translation == chosenAnswer
				: word.Original == chosenAnswer;

			var exerciseWordDto = new ExerciseWordDto(0, exerciseId, setId, wordId, chosenAnswer, date, isCorrect);
			
			_exerciseWordsRepository.AddExerciseWord(exerciseWordDto);
		}

		public ExerciseResult FinishExercise(Guid exerciseId, ExerciseFormat format)
		{
			var exerciseWords = _exerciseWordsRepository.GetExerciseWordsByExerciseId(exerciseId);

			var exerciseResultWords = exerciseWords
				.Where(w => !w.IsCorrect)
				.Select(w => new ExerciseResultWord(
					format == ExerciseFormat.EnRu
						? _wordsRepository.GetById(w.WordId).Original
						: _wordsRepository.GetById(w.WordId).Translation,
					w.Answer,
					format == ExerciseFormat.EnRu
						? _wordsRepository.GetById(w.WordId).Translation
						: _wordsRepository.GetById(w.WordId).Original))
				.ToList();

			var exerciseResult = new ExerciseResult(
				exerciseWords.Count(w => w.IsCorrect),
				exerciseWords.Count,
				exerciseResultWords);
			
			// TODO: Обновление стастики пользователя (изученные слова и набор)
			
			_exerciseWordsRepository.DeleteExerciseWordsByExerciseId(exerciseId);

			return exerciseResult;
		}
		
		private readonly IExerciseFactory _exerciseFactory;
		private readonly IWordsRepository _wordsRepository;
		private readonly IExerciseWordsRepository _exerciseWordsRepository;
	}
}
