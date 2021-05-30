using System;
using System.IO;
using System.Linq;
using System.Text;
using EnglishTrainer.API.Extensions;
using EnglishTrainer.API.Models;
using EnglishTrainer.Core.Domain.Entities;
using EnglishTrainer.Core.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.API.Controllers
{
    [Route("words")]
    [Authorize]
    public class WordsController: ControllerBase
    {
        private readonly IWordsRepository _wordsRepository;
        private readonly IExerciseWordsRepository _exerciseWordsRepository;
        
        public WordsController(IWordsRepository wordsRepository, IExerciseWordsRepository exerciseWordsRepository)
        {
            _wordsRepository = wordsRepository ?? throw new ArgumentNullException(nameof(wordsRepository));
            _exerciseWordsRepository = exerciseWordsRepository ?? 
                                       throw new ArgumentNullException(nameof(exerciseWordsRepository));
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllWords()
        {
            var words = _wordsRepository.GetAll();

            var response = new
            {
                Words = words
            };

            return Ok(response);
        }
        
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetWordById([FromRoute] int id)
        {
            var word = _wordsRepository.GetById(id);

            return Ok(word);
        }
        
        [HttpPost]
        [Route("create")]
        public IActionResult CreateWord()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (StreamReader reader = new StreamReader(@"D:\vocabulary.txt", Encoding.Default))
            {
                while (!reader.EndOfStream)
                {
                    var original = reader.ReadLine();
                    var translation = reader.ReadLine();

                    var word = new Word(original, translation);

                    _wordsRepository.Create(word);
                }
            }

            return Ok();
        }
        
        [HttpGet]
        [Route("inSet/{setId}")]
        public IActionResult GetSetWords([FromRoute] Guid setId)
        {
            var setWords = _wordsRepository.GetSetWords(setId);

            var response = new
            {
                SetWords = setWords
            };

            return Ok(response);
        }
        
        [HttpPost]
        [Route("inSet")]
        public IActionResult AddSetWord([FromBody] AddSetWordRequest request)
        {
            _wordsRepository.AddSetWord(request.SetId, request.WordId);

            return Ok();
        }
        
        [HttpGet]
        [Route("studied")] 
        public IActionResult GetStudiedWords()
        {
            var studiedWordsDtos = _wordsRepository.GetStudiedWordsByUserId(User.GetUserId());
            var studiedWords = studiedWordsDtos
                .Select(swd => new StudiedWord(
                    swd.UserId,
                    _wordsRepository.GetById(swd.WordId),
                    swd.RiskFactor,
                    swd.CorrectAnswers,
                    swd.IncorrectAnswers,
                    swd.LastAppearanceDate,
                    swd.Status))
                .ToList();

            var response = new
            {
                StudiedWords = studiedWords
            };

            return Ok(response);
        }
        
        [HttpPost]
        [Route("studied")]
        public IActionResult AddStudiedWord([FromBody] AddStudiedWordRequest request)
        {
            var studiedWordDto = new StudiedWordDto(
                User.GetUserId(),
                request.WordId,
                request.CorrectAnswers,
                request.IncorrectAnswers,
                request.LastAppearanceDate);
            
            _wordsRepository.AddStudiedWord(studiedWordDto);

            return Ok();
        }
        
        [HttpGet]
        [Route("exercise/{exerciseId}")]
        public IActionResult GetExerciseWords([FromRoute] Guid exerciseId)
        {
            var exerciseWords = _exerciseWordsRepository.GetExerciseWordsByExerciseId(exerciseId);

            var response = new
            {
                ExerciseWords = exerciseWords
            };

            return Ok(response);
        }
    }
}
