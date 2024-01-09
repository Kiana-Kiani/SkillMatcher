using SkillMatcher.DataModel;

namespace SkillMatcher.Dto.Questioner
{
    public class ReportListFromUIDto
    {
        public List<Option> Answers { get; set; } = new List<Option>();
        public List<int> OptionNo { get; set; } = new List<int>();

        public List<Question> Questions { get; set; } = new List<Question>();
    }
}
