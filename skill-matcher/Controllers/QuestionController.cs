using Microsoft.AspNetCore.Mvc;
using SkillMatcher.Dto;
using SkillMatcher.Service.Interfaces;

namespace SkillMatcher.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class QuestionController : Controller
    {

        private readonly IQuestionService questionService;

        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }

        [HttpGet("{testId}")]
        public IActionResult GetQuestionsByTestId(string testId)
        {
            var questions = questionService.GetQuestionsByTestId(testId);
            return Ok(questions);
        }

        [HttpPost]
        public IActionResult CreateQuestion([FromBody] QuestionDto model)
        {
            if (model == null)
            {
                return BadRequest(new { message = "Error." });
            }
            if (questionService.CreateQuestion(model))
                return Ok("Question Creasted successfully.");
            else
                return BadRequest(new { message = "Error." });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuestionById(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (questionService.DeleteQuestionById(id))
                return Ok(new { message = "Question deleted successfully." });
            else
                return BadRequest(new { message = "Error." });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateQuestionById(string id, [FromBody] QuestionDto questionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Error." });
            }

            var result = questionService.UpdateQuestionById(id, questionDto);
            if (result == 1)
            {
                return Ok(new { message = "Question updated successfully." });
            }
            else if (result == 0)
            {
                return NotFound("Question not found.");
            }
            else
            {
                return StatusCode(500, "Question update failed.");
            }
        }
    }
}