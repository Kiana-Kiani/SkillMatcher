using MongoDB.Bson.Serialization.Attributes;

namespace SkillMatcher.DataModel
{
    public class Prompt
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }

    }
}
