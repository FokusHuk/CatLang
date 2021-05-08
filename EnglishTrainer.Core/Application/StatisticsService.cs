using System;
using System.Collections.Generic;
using System.Linq;
using EnglishTrainer.Core.Domain.Entities;
using EnglishTrainer.Core.Domain.Exercises;
using EnglishTrainer.Core.Domain.Repositories;

namespace EnglishTrainer.Core.Application
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ISetRepository _setRepository;
        private readonly IWordsRepository _wordsRepository;

        public StatisticsService(ISetRepository setRepository, IWordsRepository wordsRepository)
        {
            _setRepository = setRepository;
            _wordsRepository = wordsRepository;
        }
        
        public void UpdateUserStudiedWords(Guid userId, List<ExerciseWordDto> newStudiedWords)
        {
            foreach (var newStudiedWord in newStudiedWords)
            {
                var studiedWord = _wordsRepository.GetStudiedWord(userId, newStudiedWord.WordId);

                if (studiedWord == null)
                {
                    _wordsRepository.AddStudiedWord(new StudiedWordDto(
                        userId,
                        newStudiedWord.WordId,
                        newStudiedWord.IsCorrect ? 1: 0,
                        newStudiedWord.IsCorrect ? 0: 1,
                        newStudiedWord.Date));
                }
                else
                {
                    var correctAnswers = (newStudiedWord.IsCorrect ? 1 : 0) + studiedWord.CorrectAnswers;
                    var incorrectAnswers = (newStudiedWord.IsCorrect ? 0 : 1) + studiedWord.IncorrectAnswers;
                    var riskFactor = studiedWord.RiskFactor + (newStudiedWord.IsCorrect ? -50.0: +25.0);
                    if (riskFactor > 100) riskFactor = 100;
                    if (riskFactor < 0) riskFactor = 0;
                    var K = (double)correctAnswers / (correctAnswers + incorrectAnswers);
                    var status = K > 0.8 ? WordStudyStatus.Complete : WordStudyStatus.NeedPractice;

                    studiedWord.CorrectAnswers = correctAnswers;
                    studiedWord.IncorrectAnswers = incorrectAnswers;
                    studiedWord.RiskFactor = riskFactor;
                    studiedWord.Status = status;
                    studiedWord.LastAppearanceDate = newStudiedWord.Date;
                    
                    _wordsRepository.UpdateStudiedWord(studiedWord);
                }
            }
        }

        public void UpdateUserStudiedSet(Guid userId, List<ExerciseWordDto> newStudiedWords)
        {
            var setId = newStudiedWords.FirstOrDefault().SetId;
            var correctAnswers = newStudiedWords.Count(sw => sw.IsCorrect);
            var answersCount = newStudiedWords.Count;
            var isStudied = correctAnswers == answersCount;
            
            var studiedSet = _setRepository.GetStudiedSet(userId, setId);

            if (studiedSet == null)
            {
                _setRepository.AddStudiedSet(new StudiedSetDto(
                    0,
                    setId,
                    userId,
                    1,
                    isStudied,
                    correctAnswers,
                    answersCount));
            }
            else
            {
                if (!studiedSet.IsStudied)
                {
                    studiedSet.AttemptsCount += 1;
                    studiedSet.CorrectAnswers += correctAnswers;
                    studiedSet.AnswersCount += answersCount;
                    studiedSet.IsStudied = isStudied;
                    
                    _setRepository.UpdateStudiedSet(studiedSet);
                }
            }
        }
    }
}
