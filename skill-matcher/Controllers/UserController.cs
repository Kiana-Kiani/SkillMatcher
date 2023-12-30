using Microsoft.AspNetCore.Mvc;
using SkillMatcher.DataModel;
using SkillMatcher.Dto.User;
using SkillMatcher.Service.Interfaces;

namespace SkillMatcher.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService UserService;

        public UserController(IUserService UserService)
        {
            this.UserService = UserService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(User), 200)]
        public IActionResult InsertFirstInfoBot(UserFirstInfoBotDto userFirstInfoBotDto)
        {
            User userFirstInfoBot = UserService.InsertFirstInfoBot(userFirstInfoBotDto);
            if (userFirstInfoBot == null)
            {
                return BadRequest("This TelegramID already exists.");
            }
            return Ok(userFirstInfoBot);
        }

        [HttpGet("{telegrmId}")]
        [ProducesResponseType(typeof(User), 200)]
        public IActionResult GetUserInfoBot(string telegrmId)
        {
            var UserInfo = UserService.GetUserInfoBot(telegrmId.ToLower());
            if (UserInfo == null)
            {
                return NotFound("Not Found.");
            }
            return Ok(UserInfo);
        }
    }
}
