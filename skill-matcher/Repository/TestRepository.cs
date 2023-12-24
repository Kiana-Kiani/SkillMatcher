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
        public bool CreateTest(Test test)
        {
            try
            {
                TestCollection.InsertOne(test);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteTestById(string id)
        {
            var deleteResult = TestCollection.DeleteOne(q => q.Id == id);
            if (deleteResult.DeletedCount == 1)
                return true;
            return false;
        }
        public int UpdateTestById(string id, TestDto testDto)
        {
            var updateDefinition = Builders<Test>.Update.Set(q => q.Name, testDto.Name)
                .Set(q => q.DateTime, DateTime.Now)
                .Set(q => q.Level, testDto.Level)
                .Set(q => q.About, testDto.About);
            var filter = Builders<Test>.Filter.Eq(q => q.Id, id);

            var result = TestCollection.UpdateOne(filter, updateDefinition);
            return (int)result.ModifiedCount;
        }
    }
}