using System;
using EnglishTrainer.API.Extensions;
using EnglishTrainer.Core.Application;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.API.Controllers
{
    [Route("recommendations")]
    public class RecommendationController: ControllerBase
    {
        private readonly IRecommendationService _recommendationService;

        public RecommendationController(IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        [HttpGet]
        public IActionResult GetRecommendationsForUser()
        {
            var recommendedSets = _recommendationService.GetByUserId(User.GetUserId());

            var response = new
            {
                RecommendedSets = recommendedSets
            };

            return Ok(response);
        }

        [HttpPost]
        public IActionResult GenerateRecommendations()
        {
            _recommendationService.Generate();
            
            return Ok();
        }
    }
}
