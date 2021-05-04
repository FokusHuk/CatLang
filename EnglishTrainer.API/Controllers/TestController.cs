using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.API.Controllers
{
    public class TestController: ControllerBase
    {
        [HttpGet]
        [Route("test")]
        [Authorize]
        public IActionResult Test()
        {
            var result = new
            {
                Status = "Healthy"
            };
            return Ok(result);
        }
    }
}