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
        [Route("create/conformity")]
        public IActionResult CreateConformityExercise([FromBody] CreateExerciseRequest request)
        {
            var conformityExercise = _exerciseService.CreateConformityExercise(request.ExerciseFormat, request.SetId);
            
            return Ok(conformityExercise);
        }
        
        [HttpPost]
        [Route("create/choice")]
        public IActionResult CreateChoiceExercise([FromBody] CreateExerciseRequest request)
        {
            var choiceExercise = _exerciseService.CreateChoiceExercise(request.ExerciseFormat, request.SetId);
            
            return Ok(choiceExercise);
        }

        [HttpPost]
        [Route("commit")]
        public IActionResult CommitAnswer([FromBody] CommitExerciseAnswerRequest request)
        {
            _exerciseService.CommitExerciseAnswer(
                request.ExerciseId,
                request.SetId,
                request.WordId,
                request.ChosenAnswer);

            return Ok();
        }

        [HttpGet]
        [Route("finish/{exerciseId}")]
        public IActionResult FinishSprintExercise([FromRoute] Guid exerciseId)
        {
            var exerciseResult = _exerciseService.FinishExercise(exerciseId);
            
            return Ok(exerciseResult);
        }
    }
}
