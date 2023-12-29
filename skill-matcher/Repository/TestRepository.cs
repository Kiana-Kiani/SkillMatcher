using MongoDB.Bson;
using MongoDB.Driver;
using SkillMatcher.DataModel;
using SkillMatcher.Dto;
using SkillMatcher.Repository.Contracts;

namespace SkillMatcher.Repository
{
    public class TestRepository : ITestRepository
    {
        private readonly IMongoDatabase db;
        private readonly IMongoCollection<Test> TestCollection;
        private readonly IConfiguration configuration;

        public TestRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            var connectionString = configuration.GetConnectionString("MongoDb");
            var client = new MongoClient(connectionString);
            db = client.GetDatabase("JobOffererTest");
            TestCollection = db.GetCollection<Test>("Tests");
        }

        public List<Test> GetTestList()
        {
            var tests = TestCollection.Find(_ => true).ToList();
            return tests;
        }
        public Test CreateTest(Test test)
        {

            //try
            //{
            TestCollection.InsertOne(test);
            return test;
            //}
            //catch
            //{
            //    return Guid.Empty;
            //}
        }
        public bool DeleteTestById(Guid id)
        {
            var deleteResult = TestCollection.DeleteOne(q => q.Id == id);
            if (deleteResult.DeletedCount == 1)
                return true;
            return false;
        }
        public int UpdateTestById(Guid id, PostAndPutTestDto testDto)
        {
            var updateDefinition = Builders<Test>.Update.Set(q => q.Name, testDto.Name)
                .Set(q => q.DateTime, DateTime.Now)
                .Set(q => q.Level, testDto.Level)
                .Set(q => q.About, testDto.About);

            var filter = Builders<Test>.Filter.Eq(q => q.Id, id);
            try
            {
                var result = TestCollection.UpdateOne(filter, updateDefinition);
                if(result.ModifiedCount ==1 || result.MatchedCount ==1)
                   return 1;
                else return 0;
            }
            catch
            {
                return -1;
            }
        }

        public Test GetTestById(Guid id)
        {
            var test = TestCollection.Find(q => q.Id == id).FirstOrDefault();
            return test;
        }
    }
}