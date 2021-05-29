using System;
using System.Linq;
using EnglishTrainer.API.Extensions;
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
        private readonly IStudiedSetsRepository _studiedSetsRepository;
        
        public SetController(ISetService setService, IStudiedSetsRepository studiedSetsRepository)
        {
            _setService = setService ?? throw new ArgumentNullException(nameof(setService));
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
            var setId = _setService.CreateSet(User.GetUserId(), request.StudyTopic, request.SetWordsIds);

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
        [Route("studied/user")]
        public IActionResult GetStudiedSetsByUserId()
        {
            var studiedSets = _studiedSetsRepository.GetStudiedSetsByUserId(User.GetUserId());
            
            var response = new
            {
                StudiedSets = studiedSets
            };

            return Ok(response);
        }

        [HttpGet]
        [Route("studied/user/{setId}")]
        public IActionResult GetStudiedSet([FromRoute] Guid setId)
        {
            var studiedSet = _studiedSetsRepository.GetStudiedSet(User.GetUserId(), setId);

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
            _studiedSetsRepository.AddStudiedSet(new StudiedSetDto(request.SetId, User.GetUserId(), request.CorrectAnswers));

            return Ok();
        }
        
        [HttpGet]
        [Route("studied/all")]
        public IActionResult GetStudiedSets()
        {
            var studiedSets = _studiedSetsRepository.GetStudiedSets();
            
            var response = new
            {
                StudiedSets = studiedSets
            };

            return Ok(response);
        }
        
        [HttpGet]
        [Route("user")]
        public IActionResult GetUserCreatedSets()
        {
            var createdSets = _setService.GetUserCreatedSets(User.GetUserId());

            var createSetsForResponse = createdSets
                .Select(s => new
                {
                    StudyTopic = s.StudyTopic,
                    Complexity = s.Complexity,
                    Efficiency = s.Efficiency,
                    Popularity = s.Popularity,
                    AverageStudyTime = s.AverageStudyTime
                })
                .ToList();

            var response = new
            {
                CreatedSets = createSetsForResponse
            };

            return Ok(response);
        }
    }
}
