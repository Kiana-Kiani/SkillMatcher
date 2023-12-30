using MongoDB.Bson.Serialization.Attributes;
using SkillMatcher.Dto.QuestionOption;
using SkillMatcher.Enums;

namespace SkillMatcher.DataModel
{
    public class Question
    {
        [BsonId]
        public Guid Id { get; set; } // MongoDB-generated ID
        public Guid TestId { get; set; } // Foreign key to Test
                                         //public Dictionary<string, string> QuestionText { get; set; } = new Dictionary<string, string>() 
                                         //{

        //};
        public QuestionDictDto QuestionText { get; set; } = new QuestionDictDto();

        public string Type { get; set; }
        public int Level { get; set; }
        public int AnswerCount { get; set; }
        public List<Option> Options { get; set; } = new List<Option> { new Option() };
    }
}