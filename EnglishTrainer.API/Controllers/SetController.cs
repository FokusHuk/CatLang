using System;
using EnglishTrainer.API.Models;
using EnglishTrainer.Core.Application;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.API.Controllers
{
    [Route("sets")]
    public class SetController: ControllerBase
    {
        private readonly ISetService _setService;
        
        public SetController(ISetService setService)
        {
            _setService = setService ?? throw new ArgumentNullException(nameof(setService));
        }
        
        [HttpGet]
        public IActionResult GetAllSets()
        {
            var sets = _setService.GetAllSets();

            var response = new
            {
                Sets = sets
            };

            return Ok(response);
        }
        
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSetById([FromRoute] Guid id)
        {
            var set = _setService.GetSetById(id);

            return Ok(set);
        }
        
        [HttpPost]
        public IActionResult CreateSet([FromBody] CreateSetRequest request)
        {
            var setId = _setService.CreateSet(request.UserId, request.StudyTopic, request.SetWordsIds);

            var response = new
            {
                SetId = setId
            };

            return Ok(response);
        }
    }
}
