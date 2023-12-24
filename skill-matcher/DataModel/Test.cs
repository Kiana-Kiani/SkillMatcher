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
        public DateTime DateTime { get; set; }
    }
}