using Microsoft.AspNetCore.Mvc;
using SkillMatcher.DataModel;
using SkillMatcher.Dto.Prompt;
using SkillMatcher.Service.Interfaces;

namespace SkillMatcher.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PromptController : ControllerBase
    {
        private readonly IPromptService promptService;


        public PromptController(IPromptService promptService)
        {
            this.promptService = promptService;
        }

        // GET: Get a single prompt by ID
        /// <summary>
        /// Get a single prompt by ID
        /// </summary>
        /// <param name="id">The ID of the prompt to retrieve</param>
        /// <response code="404">If the prompt with the specified ID is not found</response>
        /// <response code="500">If there is an internal server error</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Prompt), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetPromptById(Guid id)
        {
            try
            {
                Prompt prompt = promptService.GetPromptById(id);

                if (prompt == default)
                {
                    return NotFound();
                }

                return Ok(prompt);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.\r" + ex.Message);  // Return a 500 status code
            }
        }

        /// <summary>
        /// Get all prompts
        /// </summary>
        /// <response code="200">Returns the list of all prompts</response>
        /// <response code="500">If there is an internal server error</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Prompt>), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetPrompts()
        {
            try
            {
                List<Prompt> prompts = promptService.GetPrompts();
                return Ok(prompts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.\r" + ex.Message);  // Return a 500 status code
            }
        }


        /// <summary>
        /// Insert a new prompt
        /// </summary>
        /// <param name="Text">The text for the new prompt</param>
        /// <response code="200">Returns the created prompt</response>
        /// <response code="500">If there is an internal server error</response>
        [HttpPost]
        [ProducesResponseType(typeof(Prompt), 200)]
        [ProducesResponseType(500)]
        public IActionResult CreatePrompt([FromBody] PromptDto promptDto)
        {
            try
            {
                var prompt = promptService.CreatePrompt(promptDto);
                return Ok(prompt);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.\r" + ex.Message);  // Return a 500 status code
            }
        }


        // POST: Insert a new prompt
        //[HttpPost]
        //public IActionResult CreatePrompt([FromBody] string Text)
        //{
        //    var prompt = promptService.CreatePrompt(Text);
        //    if (prompt != default)
        //    {
        //        return Ok(prompt);
        //    }
        //    return BadRequest(" Create new Prompt Faild.");

        //}

        /// <summary>
        /// Update an existing prompt
        /// </summary>
        /// <param name="id">The ID of the prompt to update</param>
        /// <param name="Text">The updated text for the prompt</param>
        /// <response code="200">Returns the updated text of the prompt</response>
        /// <response code="400">If the update prompt operation fails</response>
        /// <response code="404">If the prompt with the specified ID is not found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PromptDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePrompt(Guid id, [FromBody] PromptDto promptDto)
        {
            try
            {

                bool isUpdated = promptService.UpdatePrompt(id, promptDto);

                if (isUpdated)
                    return Ok(promptDto);
                else
                    return BadRequest("Update Prompt Faild.");
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);  // Return a 404 status code
            }

        }

        /// <summary>
        /// Delete a prompt
        /// </summary>
        /// <param name="id">The ID of the prompt to delete</param>
        /// <response code="200">If the prompt is deleted successfully</response>
        /// <response code="400">If the delete prompt operation fails</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeletePrompt(Guid id)
        {

            bool isDeleted = promptService.DeletePrompt(id);

            if (!isDeleted)
                return BadRequest("Delete Prompt Faild.");
            else
                return Ok();
        }
    }
}
