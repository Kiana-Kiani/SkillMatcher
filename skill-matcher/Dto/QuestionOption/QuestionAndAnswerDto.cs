using SkillMatcher.DataModel;

namespace SkillMatcher.Dto.QuestionOption
{
    public class QuestionAndAnswerDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Question Questions { get; set; } = new Question();
        public string Answers { get; set; }
    }
}
