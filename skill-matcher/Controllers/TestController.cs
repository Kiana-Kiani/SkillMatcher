using Microsoft.AspNetCore.Mvc;
using SkillMatcher.DataModel;
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
        [ProducesResponseType(typeof(List<Test>), 200)]
        public IActionResult GetTestList()
        {
            return Ok(testService.GetTestList());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Test), 200)]
        public IActionResult GetTestById(Guid id)
        {
            return Ok(testService.GetTestById(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        public IActionResult CreateTest([FromBody] PostAndPutTestDto model)
        {
            if (model == null)
            {
                return BadRequest(new { message = "Error." });
            }

            var test = testService.CreateTest(model);
     //       if (test. != null)
                return Ok(test);
            //else
            //    return BadRequest(new { message = "Error." });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult DeleteTestById(Guid id)
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
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult UpdateTestById(Guid id, [FromBody] PostAndPutTestDto model)
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