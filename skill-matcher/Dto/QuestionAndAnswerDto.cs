using SkillMatcher.DataModel;

namespace SkillMatcher.Dto
{
    public class QuestionAndAnswerDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Question Questions { get; set; }
        public string Answers { get; set; }
    }
}
