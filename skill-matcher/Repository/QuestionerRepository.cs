using MongoDB.Bson;
using MongoDB.Driver;
using SkillMatcher.DataModel;
using SkillMatcher.Dto;
using SkillMatcher.Repository.Contracts;
using System.Reflection.Emit;
using System.Security.Cryptography;

namespace SkillMatcher.Repository
{


    public class QuestionerRepository : IQuestionerRepository
    {
        private readonly IMongoDatabase db;
        private readonly IMongoCollection<Questioner> QuestionerCollection;
        private readonly IConfiguration configuration;

        public QuestionerRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            var connectionString = configuration.GetConnectionString("MongoDb");
            var client = new MongoClient(connectionString);
            db = client.GetDatabase("JobOffererTest");
            QuestionerCollection = db.GetCollection<Questioner>("Questioners");
        }
        public Guid InsertQuestionAnswer( QuestionAndAnswerDto questionAndAnswerDto)
        {
            try
            {
                var filter = Builders<Questioner>.Filter.And(
                          Builders<Questioner>.Filter.Eq("UserId", questionAndAnswerDto.UserId),
                          Builders<Questioner>.Filter.Eq("Id", questionAndAnswerDto.Id)
                      );

                Questioner questionerdb = QuestionerCollection.Find(filter).FirstOrDefault();

                QuestionerContent newlist = new QuestionerContent()
                {
                    Questions = questionAndAnswerDto.Questions,
                    Answers = questionAndAnswerDto.Answers
                };

                questionerdb.Chat.Add(newlist);

                var updateDefinition = Builders<Questioner>.Update
                           .Set(q => q.Chat, questionerdb.Chat);

                var result = QuestionerCollection.UpdateOne(filter, updateDefinition);

                if (result.MatchedCount == 1 || result.ModifiedCount == 1)
                {
                    return questionAndAnswerDto.Id;
                }
                else
                {
                    return Guid.Empty;
                }
            }
            catch
            {
                return Guid.Empty;
            }
        }

        public Guid InsertUserId(Questioner questioner)
        {
            QuestionerCollection.InsertOne(questioner);
            return questioner.Id;

        }
    }
}
