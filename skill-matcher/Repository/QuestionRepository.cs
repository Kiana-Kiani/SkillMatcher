using MongoDB.Bson;
using MongoDB.Driver;
using SkillMatcher.DataModel;
using SkillMatcher.Dto;
using SkillMatcher.Repository.Contracts;
using static System.Net.Mime.MediaTypeNames;

namespace SkillMatcher.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IMongoDatabase db;
        private readonly IMongoCollection<Question> QuestionsCollection;
        private readonly IConfiguration configuration;

        public QuestionRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            var connectionString = configuration.GetConnectionString("MongoDb");
            var client = new MongoClient(connectionString);
            db = client.GetDatabase("JobOffererTest");
            QuestionsCollection = db.GetCollection<Question>("Questions");
        }
        public bool DeleteQuestionById(Guid id)
        {
            var deleteResult = QuestionsCollection.DeleteOne(q => q.Id == id);
            if (deleteResult.DeletedCount == 1)
                return true;
            return false;
        }

        public Question GetQuestionById(Guid id)
        {
            var filter = Builders<Question>.Filter.Eq(q => q.Id, id);
            var question = QuestionsCollection.Find(filter).FirstOrDefault();
    
            return question;
        }


        public List<Question> GetQuestionsByTestId(Guid testId)
        {
            var filter = Builders<Question>.Filter.Eq(q => q.TestId, testId);
            var question = QuestionsCollection.Find(filter).ToList();
            return question;
        }

        public List<Question> GetQuestionsByLevelAndTestId(Guid testId, int level)
        {
            try
            {
                var filter = new BsonDocument
                {
                    { "TestId" ,testId },
                    { "Level", level }
                };

                var questions = QuestionsCollection.Find(filter).ToList();
                return questions;
            }
            catch
            {
                return null;
            }
        }


        public Question InsertQuestion(Question question)
        {
            try
            {
                QuestionsCollection.InsertOne(question);
                return question;
            }
            catch
            {
                return null;
            }
        }
        public int UpdateQuestionById(Guid id, PostAndPutQuestionDto questionDto)
        {
            var question = new Question();
            question.Options = new List<Option>();

            foreach (var optionDto in questionDto.Options)
            {
                Option option = new Option();
                option.Persian = optionDto.Persian;
                option.English = optionDto.English;
                //option.OptionText["English"] = optionDto.English;
                //option.OptionText["Persian"] = optionDto.Persian;
                question.Options.Add(option);
            }
            var updateDefinition = Builders<Question>.Update
                .Set(q => q.QuestionText.Persian, questionDto.QuestionText.Persian)
                .Set(q => q.QuestionText.English, questionDto.QuestionText.English)
                .Set(q => q.Type, questionDto.Type.ToString())
                .Set(q => q.Options, question.Options)
                .Set(q => q.AnswerCount, questionDto.AnswerCount)
                .Set(q => q.Level, questionDto.Level);

            var filter = Builders<Question>.Filter.Eq(q => q.Id, id);
            try
            {
                var result = QuestionsCollection.UpdateOne(filter, updateDefinition);
                if (result.ModifiedCount == 1 || result.MatchedCount == 1)
                { return 1; }
                else
                    return 0;
            }
            catch
            {
                return -1;
            }
        }
    }
}
