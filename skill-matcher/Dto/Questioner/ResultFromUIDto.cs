using SkillMatcher.DataModel;
using SkillMatcher.Dto.QuestionOption;

namespace SkillMatcher.Dto.Questioner
{
    public class ResultFromUIDto
    {
        //public Guid Id { get; set; }
        //public Guid UserId { get; set; }
        public string Result { get; set; }
        public bool IsFinalResult { get; set; }
        public string UserScore { get; set; }
        public List<string> Answers { get; set; } = new List<string>();
        public List<QuestionTypeForUi> Questions { get; set; } = new List<QuestionTypeForUi>();

    }
}
