using SkillMatcher.DataModel;
using SkillMatcher.Dto.QuestionOption;

namespace SkillMatcher.Dto.Questioner
{
    public class QuestionAndAnswerFromUiDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public QuestionTypeForUi Questions { get; set; }
        public string Answers { get; set; }
    }
}
