using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SkillMatcher.Dto.QuestionOption;
using SkillMatcher.Enums;

namespace SkillMatcher.DataModel
{
    public class Question
    {
        [BsonId]
        public Guid Id { get; set; }
        public Guid TestId { get; set; }
        public QuestionDictDto QuestionText { get; set; } = new QuestionDictDto();

        [BsonRepresentation(BsonType.String)]
        public QuestionType Type { get; set; }
        public int Level { get; set; }
        public int AnswerCount { get; set; }
        public List<Option> Options { get; set; } = new List<Option> { new Option() };
    }
}