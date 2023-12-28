using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillMatcher.DataModel;
using SkillMatcher.Dto;
using SkillMatcher.Repository.Contracts;
using SkillMatcher.Service;
using SkillMatcher.Service.Interfaces;

namespace SkillMatcher.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class QuestionerController : Controller
    {
        private readonly IQuestionerService questionerService;

        public QuestionerController(IQuestionerService questionerService)
        {
            this.questionerService = questionerService;
        }

        //[HttpPost]
        //public IActionResult InsertQuestionAnswer([FromBody] QuestionAndAnswerDto questionAndAnswerDto)
        //{

        //    var questionerId = questionerService.InsertQuestionAnswer(questionAndAnswerDto);
        //    return Ok(questionerId);
        //}
        [HttpPut]
        public IActionResult InsertQuestionAnswer([FromBody] QuestionAndAnswerFromUiDto questionAndAnswerDto)
        {

            var questionerId = questionerService.InsertQuestionAnswer(questionAndAnswerDto);
            if (questionerId == Guid.Empty)
                return BadRequest("It was not updated");
            return Ok(questionerId);
        }




        [HttpPost("{userId}")]
        public IActionResult InsertUserId(Guid userId)
        {

            var questionerId = questionerService.InsertUserId(userId);
            return Ok(questionerId);
        }


    }
}
