using Microsoft.AspNetCore.Mvc;
using SkillMatcher.DataModel;
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
        [ProducesResponseType(typeof(Question), 200)]
        public IActionResult GetQuestionsByTestId(Guid testId)
        {
            var questions = questionService.GetQuestionsByTestId(testId);
            return Ok(questions);
        }

        [HttpPost("{testId}")]
     //   [ProducesResponseType(typeof(Guid), 200)]

        public IActionResult CreateQuestion(Guid testId, [FromBody] PostAndPutQuestionDto model)
        {
            if (model == null)
            {
                return BadRequest(new { message = "Error." });
            }

            var question = questionService.CreateQuestion(testId, model);
            if (question != null)
                return Ok(question);
            else
                return BadRequest(new { message = "Error." });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult DeleteQuestionById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (questionService.DeleteQuestionById(id))
                return Ok(new { message = "Question deleted successfully." });
            else
                return BadRequest("Error.");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult UpdateQuestionById(Guid id, [FromBody] PostAndPutQuestionDto questionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error.");
            }

            var result = questionService.UpdateQuestionById(id, questionDto);
            if (result == 1)
            {
                return Ok("Question updated successfully.");
            }
            else if (result == 0)
            {
                return NotFound("Question not found.");
            }
            else
            {
                return BadRequest("Question update failed.");
            }
        }
    }
}