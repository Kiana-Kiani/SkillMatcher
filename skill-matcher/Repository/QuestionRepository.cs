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
        public List<Question> GetQuestionsByTestId(Guid testId)
        {
            var filter = Builders<Question>.Filter.Eq(q => q.TestId, testId);
            var question = QuestionsCollection.Find(filter).ToList();
            return question;
        }
        public Guid InsertQuestion(Question question)
        {
            try
            {
                QuestionsCollection.InsertOne(question);
                return question.Id;
            }
            catch
            {
                return Guid.Empty;
            }
        }
        public int UpdateQuestionById(Guid id, QuestionDto questionDto)
        {
            var question = new Question();
            question.Options = new List<Option>();
            var option = new Option();

            foreach (var optionDto in questionDto.Options)
            {
                option.OptionText["English"] = optionDto.EnglishOptionText;
                option.OptionText["Persian"] = optionDto.PersianOptionText;
                question.Options.Add(option);
            }
            var updateDefinition = Builders<Question>.Update
                .Set(q => q.QuestionText["Persian"], questionDto.PersianText)
                .Set(q => q.QuestionText["English"], questionDto.EnglishText)
                .Set(q => q.Type, questionDto.Type)
                .Set(q => q.Options, question.Options)
                .Set(q => q.AnswerCount, question.AnswerCount)
                .Set(q => q.Level, questionDto.Level);

            var filter = Builders<Question>.Filter.Eq(q => q.Id, id);
            var result = QuestionsCollection.UpdateOne(filter, updateDefinition);
            return (int)result.ModifiedCount;
        }
    }
}
