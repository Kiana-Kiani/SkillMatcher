using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SkillMatcher.DataModel;
using SkillMatcher.Dto.Prompt;
using SkillMatcher.Dto.Questioner;
using SkillMatcher.Dto.Rule;
using SkillMatcher.Repository.Interfaces;

namespace SkillMatcher.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReportController : Controller
    {
        private readonly IMongoDatabase db;
        private readonly IMongoCollection<Test> TestCollection;
        private readonly IConfiguration configuration;

        public ReportController(IConfiguration configuration)
        {
            this.configuration = configuration;
            var connectionString = configuration.GetConnectionString("MongoDb");
            var client = new MongoClient(connectionString);
            db = client.GetDatabase("JobOffererTest");
            TestCollection = db.GetCollection<Test>("Tests");
        }

        //private readonly IMongoDatabase db;
        //private readonly IMongoCollection<Rule> RulesCollection;
        //private readonly IConfiguration configuration;

        //public ReportController(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //    var connectionString = configuration.GetConnectionString("MongoDb");
        //    var client = new MongoClient(connectionString);
        //    db = client.GetDatabase("JobOffererTest");
        //    RulesCollection = db.GetCollection<Rule>("Rules");
        //}
        // GET: Get a single rule by ID
        /// <summary>
        /// Get a single rule by ID
        /// </summary>
        /// <param name="id">The ID of the rule to retrieve</param>
        /// <response code="404">If the rule with the specified ID is not found</response>
        /// <response code="500">If there is an internal server error</response>
        //[HttpGet("{id}")]
        //[ProducesResponseType(typeof(Prompt), 200)]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(500)]
        //public IActionResult GetRulsById(Guid id)
        //{
        //    try
        //    {
        //        // Prompt prompt = promptService.GetPromptById(id);

        //        if (prompt == default)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(prompt);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Internal server error.\r" + ex.Message);  // Return a 500 status code
        //    }
        //}

        /// <summary>
        /// Get all rules
        /// </summary>
        /// <response code="200">Returns the list of all rules</response>
        /// <response code="500">If there is an internal server error</response>
        //[HttpGet]
        //[ProducesResponseType(typeof(List<Prompt>), 200)]
        //[ProducesResponseType(500)]
        //public IActionResult GetRuls()
        //{
        //try
        //{
        //    //  List<Prompt> prompts = promptService.GetPrompts();
        //    return Ok(prompts);
        //}
        //catch (Exception ex)
        //{
        //    return StatusCode(500, "Internal server error.\r" + ex.Message);  // Return a 500 status code
        //}
        //   }


        /// <summary>
        /// Insert a new rule
        /// </summary>
        /// <param name="Text">The text for the new rule</param>
        /// <response code="200">Returns the created rule</response>
        /// <response code="500">If there is an internal server error</response>
        [HttpPost("{TestId}")]
        [ProducesResponseType(typeof(RuleDto), 200)]
        [ProducesResponseType(500)]
        public IActionResult CreateRules(Guid TestId, [FromBody] Rule ruleFromUI)
        {
            try
            {
                // var updateDefinition = Builders<Test>.Update.Set(q => q.Rule.ReportNumber, ruleFromUIDto.ReportNumber)
                //.Set(q => q.Rule.Rules, ruleFromUIDto.Rules)
                //.Set(q => q.Rule.LevelQuestions, ruleFromUIDto.LevelQuestions);
                //Rule rule = new Rule() { 
                //LevelQuestions = ruleFromUI.LevelQuestions,
                //ReportNumber = ruleFromUI.ReportNumber,
                //Rules = ruleFromUI.Rules,
                //};

                var filter = Builders<Test>.Filter.Eq(q => q.Id, TestId);
                Test test = TestCollection.Find(filter).FirstOrDefault();

                test.Rule.Add(ruleFromUI);

                var updateDefinition = Builders<Test>.Update.Set(q => q.Rule, test.Rule);

                var result = TestCollection.UpdateOne(filter, updateDefinition);
                if (result.ModifiedCount == 1 || result.MatchedCount == 1)
                    return Ok(ruleFromUI);
                else
                    return StatusCode(500, "Internal server error.");  // Return a 500 status code

                //  TestCollection.InsertOne(ruleDtos);


                //var prompt = promptService.CreatePrompt(promptDto);
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
        /// Update an existing rule
        /// </summary>
        /// <param name="id">The ID of the rule to update</param>
        /// <param name="Text">The updated text for the rule</param>
        /// <response code="200">Returns the updated text of the rule</response>
        /// <response code="400">If the update rule operation fails</response>
        /// <response code="404">If the rule with the specified ID is not found</response>
        //[HttpPut("{id}")]
        //[ProducesResponseType(typeof(PromptDto), 200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(404)]
        //public IActionResult UpdateRuls(Guid id, [FromBody] Rule ruleFromUI)
        //{

        //    var filter = Builders<Test>.Filter.Eq(q => q.Id,);

        //    Test findTest = TestCollection.Find(filter).FirstOrDefault();


        //    var updateDefinition = Builders<Test>.Update.Set(q => q.Rule, ruleFromUI);


        //    var filter = Builders<Test>.Filter.Eq(q => q.Id, id);
        //    try
        //    {
        //        var result = TestCollection.UpdateOne(filter, updateDefinition);
        //        if (result.ModifiedCount == 1 || result.MatchedCount == 1)
        //            return 1;
        //        else return 0;
        //    }
        //    catch
        //    {
        //        return -1;
        //    }
        //    try
        //    {

        //        // bool isUpdated = promptService.UpdatePrompt(id, promptDto);

        //        if (isUpdated)
        //            return Ok(promptDto);
        //        else
        //            return BadRequest("Update Prompt Faild.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(404, ex.Message);  // Return a 404 status code
        //    }

        //}

        /// <summary>
        /// Delete a rule
        /// </summary>
        /// <param name="id">The ID of the rule to delete</param>
        /// <response code="200">If the rule is deleted successfully</response>
        ///// <response code="400">If the delete rule operation fails</response>
        //[HttpDelete("{TestId}/{RuleId}")]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        //public IActionResult DeleteRulesById(Guid TestId, Guid RuleId)
        //{
        //    int x = 0;
        //    //bool isDeleted = promptService.DeletePrompt(id);
        //    var filter = Builders<Test>.Filter.Eq(x => x.Id, TestId);

        //    // Find the specific test
        //    Test test = TestCollection.Find(filter).FirstOrDefault();

        //    if (test != null)
        //    {
        //        // Find and remove the rule by Id from the Rule list
        //        Rule ruleToRemove = test.Rule.FirstOrDefault(r => r.Id == RuleId);
        //        if (ruleToRemove != null)
        //        {
        //            test.Rule.Remove(ruleToRemove);

        //            // Update the modified test in the database
        //            var update = Builders<Test>.Update.Set(x => x.Rule, test.Rule);
        //            TestCollection.UpdateOne(filter, update);
        //            x = 1;
                    
        //        }
        //        else
        //        {
        //            //   Console.WriteLine("Rule with the specified Id not found.");
        //            x = 2;
        //        }
        //    }
        //    else
        //    {
        //        // Console.WriteLine("Test with the specified Id not found.");
        //        x = 3;
        //    }

        //    if (x == 1)
        //        return Ok();
        //    else if (x == 2)
        //        return BadRequest("Rule with the specified Id not found.");
        //    else if (x == 3)
        //        return BadRequest("Test with the specified Id not found.");
        //    else
        //        return BadRequest();


        //}        //[HttpDelete("{TestId}/{RuleId}")]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        //public IActionResult DeleteRulesById(Guid TestId, Guid RuleId)
        //{
        //    int x = 0;
        //    //bool isDeleted = promptService.DeletePrompt(id);
        //    var filter = Builders<Test>.Filter.Eq(x => x.Id, TestId);

        //    // Find the specific test
        //    Test test = TestCollection.Find(filter).FirstOrDefault();

        //    if (test != null)
        //    {
        //        // Find and remove the rule by Id from the Rule list
        //        Rule ruleToRemove = test.Rule.FirstOrDefault(r => r.Id == RuleId);
        //        if (ruleToRemove != null)
        //        {
        //            test.Rule.Remove(ruleToRemove);

        //            // Update the modified test in the database
        //            var update = Builders<Test>.Update.Set(x => x.Rule, test.Rule);
        //            TestCollection.UpdateOne(filter, update);
        //            x = 1;
                    
        //        }
        //        else
        //        {
        //            //   Console.WriteLine("Rule with the specified Id not found.");
        //            x = 2;
        //        }
        //    }
        //    else
        //    {
        //        // Console.WriteLine("Test with the specified Id not found.");
        //        x = 3;
        //    }

        //    if (x == 1)
        //        return Ok();
        //    else if (x == 2)
        //        return BadRequest("Rule with the specified Id not found.");
        //    else if (x == 3)
        //        return BadRequest("Test with the specified Id not found.");
        //    else
        //        return BadRequest();


        //}


    }
}
