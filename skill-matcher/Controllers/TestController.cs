using Microsoft.AspNetCore.Mvc;
using SkillMatcher.DataModel;
using SkillMatcher.Dto.Test;
using SkillMatcher.Service.Interfaces;

namespace SkillMatcher.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
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
            List<Test> testList = testService.GetTestList();
            return Ok(testList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Test), 200)]
        public IActionResult GetTestById(Guid id)
        {
            Test test = testService.GetTestById(id);
            if (test == null)
            {
                return BadRequest("Test not found");
            }
            return Ok(test);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Test), 200)]
        public IActionResult CreateTest([FromBody] PostAndPutTestDto testDto)
        {
            Test test = testService.CreateTest(testDto);
            return Ok(test);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public IActionResult DeleteTestById(Guid id)
        {
            if (testService.DeleteTestById(id))
                return Ok(new { message = "Test deleted successfully." });
            else
                return BadRequest("Test was not deleted.");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public IActionResult UpdateTestById(Guid id, [FromBody] PostAndPutTestDto testDto)
        {
            var result = testService.UpdateTestById(id, testDto);
            if (result == 1)
            {
                return Ok("Test updated successfully.");
            }
            else
            {
                return BadRequest("Test update failed.");
            }
        }
    }
}