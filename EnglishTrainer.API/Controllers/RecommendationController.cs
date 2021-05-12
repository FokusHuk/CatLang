using System;
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
        [Route("{userId}")]
        public IActionResult GetRecommendationsForUser([FromRoute] Guid userId)
        {
            var recommendedSets = _recommendationService.GetByUserId(userId);

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
