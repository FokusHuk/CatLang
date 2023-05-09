using System;
using System.Collections.Generic;
using System.Linq;
using EnglishTrainer.Core.Domain.Entities;
using EnglishTrainer.Core.Domain.Repositories;

namespace EnglishTrainer.Core.Application
{
    public class RecommendationService: IRecommendationService
    {
        private readonly ISetRepository _setRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWordsRepository _wordsRepository;
        private readonly IStudiedSetsRepository _studiedSetsRepository;

        public RecommendationService(
            ISetRepository setRepository,
            IUserRepository userRepository,
            IWordsRepository wordsRepository,
            IStudiedSetsRepository studiedSetsRepository,
            IRecommendedSetsRepository recommendedSetsRepository)
        {
            _setRepository = setRepository;
            _userRepository = userRepository;
            _wordsRepository = wordsRepository;
            _studiedSetsRepository = studiedSetsRepository;
            _recommendedSetsRepository = recommendedSetsRepository;
        }

        private readonly IRecommendedSetsRepository _recommendedSetsRepository;

        public List<Guid> GetByUserId(Guid userId)
        {
            var recommendations = _recommendedSetsRepository
                .GetByUserId(userId)
                .OrderByDescending(rs => rs.LastAppearanceDate)
                .Take(10)
                .Select(rs => rs.SetId)
                .ToList();

            return recommendations;
        }
        
        public void Generate()
        {
            Console.WriteLine("RecommendationService: start generation.");
            
            var complexityLimit = 20.0;

            var sets = _setRepository.GetAll();
            var studiedSets = _studiedSetsRepository.GetStudiedSets();

            var users = _userRepository.GetAll();
            var usersIds = users.Select(u => u.Id).ToList();

            foreach (var userId in usersIds)
            {
                var userPreviousRecommendations = _recommendedSetsRepository.GetByUserId(userId);
                var userPreviousRecommendationsIds = userPreviousRecommendations
                    .Select(upr => upr.SetId)
                    .ToList();
                var lastRecommendedSetsIds = userPreviousRecommendations
                    .OrderByDescending(upr => upr.LastAppearanceDate)
                    .Take(10)
                    .Select(upr => upr.SetId)
                    .ToList();
                
                var userStudiedSets = studiedSets.Where(s => s.UserId == userId).ToList();
                var userCompletelyStudiedSetsIds = userStudiedSets
                    .Where(s => s.IsStudied)
                    .Select(s => s.SetId).ToList();
                
                var averageSetsComplexity = userStudiedSets
                                                .Sum(ss => sets
                                                    .Single(set => set.Id == ss.SetId).Complexity)
                                            / userStudiedSets.Count();

                var filteredSets = sets
                    .Where(s => s.Complexity <= averageSetsComplexity + complexityLimit &&
                                s.Complexity >= averageSetsComplexity - complexityLimit)
                    .Where(s => !userCompletelyStudiedSetsIds.Contains(s.Id))
                    .Where(s => !lastRecommendedSetsIds.Contains(s.Id))
                    .ToList();

                var wordsWithHighRiskFactorIds = _wordsRepository
                    .GetStudiedWordsByUserId(userId)
                    .Where(w => w.RiskFactor > 70.0)
                    .Select(w => w.WordId)
                    .ToList();
                
                var setsWithWordsToRepeat = filteredSets
                    .Where(fs => CheckForWordsWithHighRiskFactor(fs.Id, wordsWithHighRiskFactorIds))
                    .ToList();
                
                var effectiveSets = filteredSets.OrderBy(s => s.Efficiency).ToList();
                var popularSets = filteredSets.OrderBy(s => s.Popularity).ToList();

                var random = new Random();

                var recommendedSets = setsWithWordsToRepeat
                    .Take(30)
                    .Union(effectiveSets
                        .Take(20))
                    .Union(popularSets
                        .Take(20))
                    .ToList()
                    .OrderBy(_ => random.Next())
                    .Take(10)
                    .ToList();

                foreach (var set in recommendedSets)
                {
                    if (!userPreviousRecommendationsIds.Contains(set.Id))
                        _recommendedSetsRepository.Create(new RecommendedSet(
                            set.Id, userId, 1, DateTime.Now.ToUniversalTime()));
                    else
                    {
                        var recommendedSetToUpdate = userPreviousRecommendations
                            .Single(upr => upr.SetId == set.Id);

                        recommendedSetToUpdate.OffersCount += 1;
                        recommendedSetToUpdate.LastAppearanceDate = DateTime.Now.ToUniversalTime();

                        _recommendedSetsRepository.UpdateSet(recommendedSetToUpdate);
                    }
                }
            }
            
            Console.WriteLine("RecommendationService: generation finished.");
        }

        private bool CheckForWordsWithHighRiskFactor(Guid verifiableSetId, List<int> wordsIds)
        {
            var setWordsIds = _wordsRepository
                .GetSetWords(verifiableSetId)
                .Select(w => w.Id);

            var wordsCount = setWordsIds.Intersect(wordsIds).Count();

            return wordsCount > 2;
        }
    }
}
