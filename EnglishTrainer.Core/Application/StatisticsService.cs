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
        private readonly IStudiedSetsRepository _studiedSetsRepository;
        private readonly IWordsRepository _wordsRepository;
        private readonly ISetRepository _setRepository;

        public StatisticsService(
            IStudiedSetsRepository studiedSetsRepository,
            IWordsRepository wordsRepository,
            ISetRepository setRepository)
        {
            _studiedSetsRepository = studiedSetsRepository;
            _wordsRepository = wordsRepository;
            _setRepository = setRepository;
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
                        newStudiedWord.IsCorrect ? 1 : 0,
                        newStudiedWord.IsCorrect ? 0 : 1,
                        newStudiedWord.Date));
                }
                else
                {
                    var correctAnswers = (newStudiedWord.IsCorrect ? 1 : 0) + studiedWord.CorrectAnswers;
                    var incorrectAnswers = (newStudiedWord.IsCorrect ? 0 : 1) + studiedWord.IncorrectAnswers;
                    var riskFactor = studiedWord.RiskFactor + (newStudiedWord.IsCorrect ? -50.0 : +25.0);
                    if (riskFactor > 100) riskFactor = 100;
                    if (riskFactor < 0) riskFactor = 0;
                    var K = (double) correctAnswers / (correctAnswers + incorrectAnswers);
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

            var studiedSet = _studiedSetsRepository.GetStudiedSet(userId, setId);

            if (studiedSet == null)
            {
                _studiedSetsRepository.AddStudiedSet(new StudiedSetDto(
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

                    _studiedSetsRepository.UpdateStudiedSet(studiedSet);
                }
            }
        }

        public void UpdateSetStatistics()
        {
            var studiedSets = _studiedSetsRepository.GetStudiedSets();

            var studiedSetsIds = studiedSets.Select(s => s.SetId).ToList();

            foreach (var setId in studiedSetsIds)
            {
                var setInfo = studiedSets.Where(s => s.SetId == setId).ToList();

                var correctSetAnswersCount = setInfo.Sum(s => s.CorrectAnswers);
                var commonSetAnswersCount = setInfo.Sum(s => s.AnswersCount);
                var incorrectSetAnswersCount = commonSetAnswersCount - correctSetAnswersCount;

                var successAttemptsCount = setInfo.Where(s => s.IsStudied).Sum(s => s.AttemptsCount);
                var commonAttemptsCount = setInfo.Sum(s => s.AttemptsCount);
                var notSuccessAttemptsCount = commonAttemptsCount - successAttemptsCount;

                var successUsersCount = setInfo.Count(s => s.IsStudied);
                var commonUsersCount = setInfo.Count;
                var notSuccessUsersCount = commonUsersCount - successUsersCount;

                var complexity = Math.Round(((double) incorrectSetAnswersCount / commonSetAnswersCount +
                                  (double) notSuccessAttemptsCount / commonAttemptsCount) / 2.0 * 100.0, 2);

                var popularity = notSuccessUsersCount + 2 * successUsersCount;

                var efficiency = Math.Round(((double) correctSetAnswersCount / commonSetAnswersCount +
                                             (double) successUsersCount / commonUsersCount) / 2.0 * 100.0, 2);

                var set = _setRepository.GetById(setId);

                set.Complexity = complexity;
                set.Popularity = popularity;
                set.Efficiency = efficiency;
                set.AverageStudyTime = Math.Round((double) commonAttemptsCount / commonUsersCount, 2);

                _setRepository.UpdateSet(set);
            }
        }
    }
}
