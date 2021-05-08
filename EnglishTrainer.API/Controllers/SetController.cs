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
        private readonly IStudiedSetsRepository _studiedSetsRepository;
        
        public SetController(ISetService setService, ISetRepository setRepository, IStudiedSetsRepository studiedSetsRepository)
        {
            _setService = setService ?? throw new ArgumentNullException(nameof(setService));
            _setRepository = setRepository ?? throw new ArgumentNullException(nameof(setRepository));
            _studiedSetsRepository = studiedSetsRepository ?? throw new ArgumentNullException(nameof(studiedSetsRepository));
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
            var studiedSets = _studiedSetsRepository.GetStudiedSetsBySetId(setId);
            
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
            var studiedSets = _studiedSetsRepository.GetStudiedSetsByUserId(userId);
            
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
            var studiedSet = _studiedSetsRepository.GetStudiedSet(request.UserId, request.SetId);
            
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
            _studiedSetsRepository.AddStudiedSet(new StudiedSetDto(request.SetId, request.UserId, request.CorrectAnswers));

            return Ok();
        }
    }
}
