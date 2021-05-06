using System;
using EnglishTrainer.API.Models;
using EnglishTrainer.Core.Application;
using EnglishTrainer.Core.Domain.Entities;
using EnglishTrainer.Core.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.API.Controllers
{
    [Route("sets")]
    public class SetController: ControllerBase
    {
        private readonly ISetService _setService;
        private readonly ISetRepository _setRepository;
        
        public SetController(ISetService setService, ISetRepository setRepository)
        {
            _setService = setService ?? throw new ArgumentNullException(nameof(setService));
            _setRepository = setRepository ?? throw new ArgumentNullException(nameof(setRepository));
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
        
        [HttpGet]
        [Route("studied/{setId}")]
        public IActionResult GetStudiedSetsBySetId([FromRoute] Guid setId)
        {
            var studiedSets = _setRepository.GetStudiedSetsBySetId(setId);
            
            var response = new
            {
                StudiedSets = studiedSets
            };

            return Ok(response);
        }
        
        [HttpGet]
        [Route("studied/users/{userId}")]
        public IActionResult GetStudiedSetsByUserId([FromRoute] Guid userId)
        {
            var studiedSets = _setRepository.GetStudiedSetsByUserId(userId);
            
            var response = new
            {
                StudiedSets = studiedSets
            };

            return Ok(response);
        }
        
        [HttpGet]
        [Route("studied")]
        public IActionResult GetStudiedSet([FromBody] GetStudiedSetRequest request)
        {
            var studiedSet = _setRepository.GetStudiedSet(request.UserId, request.SetId);
            
            var response = new
            {
                StudiedSet = studiedSet
            };

            return Ok(response);
        }
        
        [HttpPost]
        [Route("studied")]
        public IActionResult AddStudiedSet([FromBody] AddStudiedSetRequest request)
        {
            _setRepository.AddStudiedSet(new StudiedSetDto(request.SetId, request.UserId));

            return Ok();
        }
    }
}
