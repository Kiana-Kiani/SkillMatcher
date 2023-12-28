using SkillMatcher.DataModel;

namespace SkillMatcher.Dto
{
    public class QuestionAndAnswerFromUiDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public QuestionTypeForUi Questions { get; set; }
        public string Answers { get; set; }
    }
}
