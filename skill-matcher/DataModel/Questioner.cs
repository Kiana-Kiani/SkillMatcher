using MongoDB.Bson.Serialization.Attributes;

namespace SkillMatcher.DataModel
{
    public class Questioner
    {
        [BsonId]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime StartedDateTime { get; set; }
        public List<QuestionerContent> Chat { get; set; } = new List<QuestionerContent>();
        public List<QuestionerResult> Result { get; set; } = new List<QuestionerResult>();
        public List<QuestionerReport> Report { get; set; } = new List<QuestionerReport>();
    }

    public class QuestionerContent
    {
        public Question Questions { get; set; } = new Question();
        public string Answers { get; set; }
    }

    public class QuestionerResult
    {
        public string Result { get; set; }
        public bool IsFinalResult { get; set; }
        public string UserComment { get; set; }
        public List<Option> Answers { get; set; } = new List<Option>();
        public List<Question> Questions { get; set; } = new List<Question>();
    }

    public class QuestionerReport
    {
        public List<ReportText> Reports { get; set; }
        public List<Option> Answers { get; set; } = new List<Option>();
        public List<int> OptionNo { get; set; } = new List<int>();
        public List<Question> Questions { get; set; } = new List<Question>();
    }
}