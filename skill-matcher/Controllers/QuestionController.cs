using Microsoft.AspNetCore.Mvc;
using SkillMatcher.DataModel;
using SkillMatcher.Dto;
using SkillMatcher.Service.Interfaces;

namespace SkillMatcher.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class QuestionController : Controller
    {
        private readonly IQuestionService questionService;

        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }

        [HttpGet("{testId}")]
        [ProducesResponseType(typeof(List<Question>), 200)]
        public IActionResult GetQuestionsByTestId(Guid testId)
        {
            var questions = questionService.GetQuestionsByTestId(testId);
            return Ok(questions);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Question), 200)]
        public IActionResult GetQuestionById(Guid id)
        {
            var questions = questionService.GetQuestionById(id);
            return Ok(questions);
        }

        [HttpGet("{testId}/{level}")]
        [ProducesResponseType(typeof(List<Question>), 200)]
        public IActionResult GetQuestionsByLevelAndTestId(Guid testId, int level)
        {
            var questions = questionService.GetQuestionsByLevelAndTestId(testId, level);
            if (questions.Count() != 0)
            {
                return Ok(questions);
            }
            else
            {
                return BadRequest("There is No Question.");
            }
        }

        [HttpPost("{testId}")]
        [ProducesResponseType(typeof(Question), 200)]
        public IActionResult CreateQuestion(Guid testId, [FromBody] PostAndPutQuestionDto model)
        {
            if (model == null)
            {
                return BadRequest("Input Is null.");
            }

            var question = questionService.CreateQuestion(testId, model);
            if (question != null)
                return Ok(question);
            else
                return BadRequest("Question was not created.");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public IActionResult DeleteQuestionById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Input Is null.");
            }

            if (questionService.DeleteQuestionById(id))
                return Ok("Question deleted successfully.");
            else
                return BadRequest("Question was not deleted.");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult UpdateQuestionById(Guid id, [FromBody] PostAndPutQuestionDto questionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Input Is null.");
            }

            var result = questionService.UpdateQuestionById(id, questionDto);
            if (result == 1 || result == 0)
            {
                return Ok("Question updated successfully.");
            }
            else if (result == -1)
            {
                return NotFound("The question was not updated.");
            }
            else
            {
                return BadRequest("Question update failed.");
            }
        }
    }
}