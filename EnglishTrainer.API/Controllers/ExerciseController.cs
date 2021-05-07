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
        [Route("commit/conformity")]
        public IActionResult CommitConformityAnswer([FromBody] CommitConformityAnswerRequest request)
        {
            _exerciseService.CommitConformityAnswer(
                request.ExerciseFormat,
                request.ExerciseId,
                request.SetId,
                request.WordId,
                request.TaskAnswer,
                request.UserChoice);

            return Ok();
        }
        
        [HttpPost]
        [Route("commit/choice")]
        public IActionResult CommitChoiceAnswer([FromBody] CommitChoiceAnswerRequest request)
        {
            _exerciseService.CommitChoiceAnswer(
                request.ExerciseFormat,
                request.ExerciseId,
                request.SetId,
                request.WordId,
                request.ChosenAnswer);

            return Ok();
        }

        [HttpPost]
        [Route("finish")]
        public IActionResult FinishExercise([FromBody] FinishExerciseRequest request)
        {
            var exerciseResult = _exerciseService.FinishExercise(request.ExerciseId, request.ExerciseFormat);
            
            return Ok(exerciseResult);
        }
    }
}
