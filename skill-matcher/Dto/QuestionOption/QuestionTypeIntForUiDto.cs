using MongoDB.Bson.Serialization.Attributes;
using SkillMatcher.DataModel;
using SkillMatcher.Enums;

namespace SkillMatcher.Dto.QuestionOption
{
    public class QuestionTypeForUi
    {
        [BsonId]
        public Guid Id { get; set; } // MongoDB-generated ID
        public Guid TestId { get; set; } // Foreign key to Test
                                         //   public Dictionary<string, string> QuestionText { get; set; } = new Dictionary<string, string>();
        public QuestionDictDto QuestionText { get; set; }
        public QuestionType Type { get; set; }
        public int Level { get; set; }
        public int AnswerCount { get; set; }
        public List<Option> Options { get; set; }
    }
}
