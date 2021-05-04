using System;
using System.IO;
using System.Text;
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
    }
}
