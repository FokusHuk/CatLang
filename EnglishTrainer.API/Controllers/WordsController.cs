using System;
using System.IO;
using System.Text;
using EnglishTrainer.API.Models;
using EnglishTrainer.Core.Domain.Entities;
using EnglishTrainer.Core.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.API.Controllers
{
    [Route("words")]
    public class WordsController: ControllerBase
    {
        private readonly IWordsRepository _wordsRepository;
        
        public WordsController(IWordsRepository wordsRepository)
        {
            _wordsRepository = wordsRepository ?? throw new ArgumentNullException(nameof(wordsRepository));
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
        [Route("inSet/{id}")]
        public IActionResult GetSetWords([FromRoute] Guid id)
        {
            var setWords = _wordsRepository.GetSetWords(id);

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
    }
}
