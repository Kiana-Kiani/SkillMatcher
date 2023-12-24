using Microsoft.AspNetCore.Mvc;
using SkillMatcher.Dto;
using SkillMatcher.Service.Interfaces;

namespace SkillMatcher.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly ITestService testService;

        public TestController(ITestService testService)
        {
            this.testService = testService;
        }

        [HttpGet]
        public IActionResult GetTestList()
        {
            return Ok(testService.GetTestList());
        }

        [HttpPost]
        public IActionResult CreateTest([FromBody] TestDto model)
        {
            if (model == null)
            {
                return BadRequest(new { message = "Error." });
            }
            if (testService.CreateTest(model))
                return Ok("Test Creasted successfully.");
            else
                return BadRequest(new { message = "Error." });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestById(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (testService.DeleteTestById(id))
                return Ok(new { message = "Test deleted successfully." });
            else
                return BadRequest(new { message = "Error." });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTestById(string id, [FromBody] TestDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Error." });
            }

            var result = testService.UpdateTestById(id, model);
            if (result == 1)
            {
                return Ok(new { message = "Test updated successfully." });
            }
            else if (result == 0)
            {
                return NotFound("Test not found.");
            }
            else
            {
                return StatusCode(500, "Test update failed.");
            }
        }
    }
}