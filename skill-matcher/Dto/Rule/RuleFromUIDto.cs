namespace SkillMatcher.Dto.Rule
{
    public class RuleFromUIDto
    {
        public int LevelQuestions { get; set; }
        public ReportText Report { get; set; }
        public List<RuleDto> Items { get; set; }

    }
    public class ReportText
    {
        public string English { get; set; }
        public string Persian { get; set; }
    }
}