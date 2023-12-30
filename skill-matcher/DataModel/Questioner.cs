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
    }

    public class QuestionerContent
    {
        public Question Questions { get; set; }  = new Question();
        public string Answers { get; set; } 
    }

    public class QuestionerResult
    {
        public string Result { get; set; }
        public bool IsFinalResult { get; set; }
        public string UserScore { get; set; }
        public List<string> Answers { get; set; } = new List<string>();
        public List<Question> Questions { get; set; } = new List<Question>();
    }
}