using MongoDB.Driver;
using SkillMatcher.DataModel;
using SkillMatcher.Dto.Questioner;
using SkillMatcher.Dto.QuestionOption;
using SkillMatcher.Repository.Interfaces;

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
        public Guid InsertQuestionAnswer(QuestionAndAnswerDto questionAndAnswerDto)
        {
            try
            {
                var filter = Builders<Questioner>.Filter.And(
                          Builders<Questioner>.Filter.Eq("UserId", questionAndAnswerDto.UserId),
                          Builders<Questioner>.Filter.Eq("Id", questionAndAnswerDto.Id)
                      );

                Questioner questionerdb = QuestionerCollection.Find(filter).FirstOrDefault();

                if (questionerdb == null)
                    return Guid.Empty;

                QuestionerContent questionerChat = new QuestionerContent()
                {
                    Questions = questionAndAnswerDto.Questions,
                    Answers = questionAndAnswerDto.Answers
                };

                if (questionerdb.Chat.Count() == 1 && questionerdb.Chat[0].Answers == null && questionerdb.Chat[0].Questions.TestId == Guid.Empty)
                    questionerdb.Chat[0] = questionerChat;
                else
                    questionerdb.Chat.Add(questionerChat);

                var updateDefinition = Builders<Questioner>.Update
                           .Set(q => q.Chat, questionerdb.Chat);

                var result = QuestionerCollection.UpdateOne(filter, updateDefinition);

                if (result.MatchedCount == 1 || result.ModifiedCount == 1)
                    return questionAndAnswerDto.Id;
                else
                    return Guid.Empty;
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

        public List<ReportText> CreateReport(Guid userId, Guid questionerId, ReportListFromUIDto reportListFromUIDto, List<ReportText> report)
        {
            try
            {
                var filter = Builders<Questioner>.Filter.And(
                          Builders<Questioner>.Filter.Eq("UserId", userId),
                          Builders<Questioner>.Filter.Eq("Id", questionerId)
                      );

                Questioner questionerdb = QuestionerCollection.Find(filter).FirstOrDefault();

                if (questionerdb == null)
                    return null;

                QuestionerReport questionerReport = new QuestionerReport()
                {
                    Answers = reportListFromUIDto.Answers,
                    Questions = reportListFromUIDto.Questions,
                    OptionNo = reportListFromUIDto.OptionNo,
                    Reports = report
                };

                if (questionerdb.Report.Count() == 1 && questionerdb.Report[0].Reports == null && questionerdb.Report[0].Answers.Count() == 0)
                    questionerdb.Report[0] = questionerReport;
                else
                    questionerdb.Report.Add(questionerReport);


                var updateDefinition = Builders<Questioner>.Update
                          .Set(q => q.Report, questionerdb.Report);

                var result = QuestionerCollection.UpdateOne(filter, updateDefinition);

                if (result.MatchedCount == 1 || result.ModifiedCount == 1)
                    return questionerReport.Reports;
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public QuestionsAnswersDto GetQuestionsAnswers(Guid questionerId)
        {

            var filter = Builders<Questioner>.Filter.Eq(q => q.Id, questionerId);
            Questioner questioner = QuestionerCollection.Find(filter).FirstOrDefault();


            List<QuestionerContent> questionerContent = new List<QuestionerContent>();
            questionerContent = questioner.Chat;

            QuestionsAnswersDto questionsAnswersDto = new QuestionsAnswersDto();


            // Dictionary<Question,string> keyValuePairs = new Dictionary<Question,string>();

            foreach (var item in questionerContent)
            {
                questionsAnswersDto.Answers.Add(item.Answers);
                questionsAnswersDto.Questions.Add(item.Questions);


            }
            return questionsAnswersDto;

        }
    }
}
