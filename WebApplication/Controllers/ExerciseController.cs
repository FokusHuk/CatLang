using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TranslationTrainer.Application;
using TranslationTrainer.Domain;

namespace WebApplication.Controllers
{
    public class ExerciseController: ControllerBase
    {
        private readonly IExerciseService _exerciseService;
        private readonly IWordsRepository _wordsRepository;

        public ExerciseController(IExerciseService exerciseService, IWordsRepository wordsRepository)
        {
            _exerciseService = exerciseService;
            _wordsRepository = wordsRepository;
        }

        [HttpPost]
        [Route("exercise/start")]
        public IActionResult StartExercise()
        {
            var status = _exerciseService.StartExercise(Guid.NewGuid());
            return Ok(status);
        }

        [HttpPost]
        [Route("exercise/commit")]
        public IActionResult Commit([FromBody] CommitRequestBody body)
        {
            var words = _wordsRepository.LoadAll();
            var word = words.Where(w => w.Original == body.word).First();
            var isCorrect = word.Translation == body.translation;
            var status = _exerciseService.CommitCurrentWord(body.guid, isCorrect);
            return Ok(status);
        }

        [HttpGet]
        [Route("exercise/finish/{id}")]
        public IActionResult Finish([FromRoute] Guid id)
        {
            var result = _exerciseService.FinishExercise(id);
            return Ok(result);
        }
    }

    public class CommitRequestBody
    {
        public Guid guid { get; set; }
        public string word { get; set; }
        
        public string translation { get; set; }
    }
}