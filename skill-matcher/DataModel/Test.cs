using MongoDB.Bson.Serialization.Attributes;

namespace SkillMatcher.DataModel
{
    public class Test
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string About { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime DateTime { get; set; }
        public List<Rule> Rule { get; set; } = new List<Rule>();

    }
}