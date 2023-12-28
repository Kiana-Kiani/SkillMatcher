using SkillMatcher.Enums;

namespace SkillMatcher.Dto
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        //public string English { get; set; }
        //public string Persian { get; set; }
        public QuestionDictDto QuestionText { get; set; } = new QuestionDictDto();

        public QuestionType Type { get; set; }
        public int Level { get; set; }
        public int AnswerCount { get; set; }
        public List<OptionDto> Options { get; set; }
    }
}