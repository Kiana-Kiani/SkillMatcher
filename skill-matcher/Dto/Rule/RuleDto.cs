using SkillMatcher.DataModel;

namespace SkillMatcher.Dto.Rule
{
    public class RuleDto
    {
        public List<Question> Question { get; set; } = new List<Question>();

        public Option Option { get; set; }
        public int OptionNo { get; set; }

    }
}
