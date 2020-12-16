using System;
using EnglishTrainer.API.Filters;
using EnglishTrainer.API.Models;
using EnglishTrainer.Core.Application;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.API.Controllers
{
    [GlobalExceptionsFilter]
    [Route("exercises")]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpPost]
        [Route("sprint/start")]
        public IActionResult StartSprintExercise()
        {
            var status = _exerciseService.StartSprintExercise(Guid.NewGuid());
            return Ok(status);
        }

        [HttpPost]
        [Route("sprint/commit")]
        public IActionResult CommitSprintAnswer([FromBody] CommitSprintAnswerRequest request)
        {
            var status = _exerciseService.CommitSprintExerciseAnswer(
                Guid.NewGuid(),
                request.ExerciseId,
                request.Word,
                request.Answer);
            return Ok(status);
        }

        [HttpGet]
        [Route("sprint/finish/{exerciseId}")]
        public IActionResult FinishSprintExercise([FromRoute] Guid exerciseId)
        {
            var result = _exerciseService.FinishSprintExercise(exerciseId);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("choice/start")]
        public IActionResult StartChoiceExercise()
        {
            var status = _exerciseService.StartChoiceExercise(Guid.NewGuid());
            return Ok(status);
        }

        [HttpPost]
        [Route("choice/commit")]
        public IActionResult CommitChoiceAnswer([FromBody] CommitChoiceAnswerRequest request)
        {
            var status = _exerciseService.CommitChoiceExerciseAnswer(
                Guid.NewGuid(),
                request.ExerciseId,
                request.Word,
                request.Answer);
            return Ok(status);
        }

        [HttpGet]
        [Route("choice/finish/{exerciseId}")]
        public IActionResult FinishChoiceExercise([FromRoute] Guid exerciseId)
        {
            var result = _exerciseService.FinishChoiceExercise(exerciseId);
            return Ok(result);
        }
    }
}
