using EnglishTrainer.API.Filters;
using EnglishTrainer.Core.Application;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.API.Controllers
{
    [GlobalExceptionsFilter]
    [Route("statistics")]
    public class StatisticsController: ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }
        
        [HttpPost]
        [Route("update")]
        public IActionResult CreateConformityExercise()
        {
            _statisticsService.UpdateSetStatistics();
            
            return Ok();
        }
    }
}
