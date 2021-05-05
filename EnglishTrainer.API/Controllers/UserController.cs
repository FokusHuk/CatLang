using System;
using EnglishTrainer.API.Authentication;
using EnglishTrainer.API.Models;
using EnglishTrainer.Core.Application;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.API.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IJwtIssuer _jwtIssuer;
        private readonly IUserService _userService;
        
        public UserController(IJwtIssuer jwtIssuer, IUserService userService)
        {
            _jwtIssuer = jwtIssuer ?? throw new ArgumentNullException(nameof(jwtIssuer));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }
        
        [HttpPost]
        [Route("authentication")]
        public IActionResult Authenticate([FromBody]SignInRequest request)
        {
            var user = _userService.LoginUser(request.Login, request.Password);
            
            var token = _jwtIssuer.GenerateToken(user);
            
            var response = new SignInResponse(token);
            return Ok(response);
        }
        
        [HttpPost]
        [Route("registration")]
        public IActionResult CreateUser([FromBody]SignUpRequest request)
        {
            var userId = _userService.CreateUser(request.Username, request.Login, request.Password);
            
            var result = new
            {
                UserId = userId,
                Login = request.Login
            };
            
            return Ok(result);
        }
    }
}
