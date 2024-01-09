using MongoDB.Bson.Serialization.Attributes;
using SkillMatcher.Dto.Rule;

namespace SkillMatcher.DataModel
{
    public class Rule
    {
        //[BsonId]

        //public Guid Id { get; set; }
        public List<RuleDto> Items { get; set; } = new List<RuleDto>();
        public ReportText Report { get; set; }
        public int LevelQuestions { get; set; }
        public int Type { get; set; }

    }

    public class ReportText
    {
        public string English { get; set; }
        public string Persian { get; set; }
    }
}
