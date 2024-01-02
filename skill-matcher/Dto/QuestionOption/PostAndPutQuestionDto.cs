using SkillMatcher.DataModel;
using SkillMatcher.Enums;

namespace SkillMatcher.Dto.QuestionOption
{
    public class PostAndPutQuestionDto
    {
        public QuestionDictDto QuestionText { get; set; }
        public QuestionType Type { get; set; }
        public int Level { get; set; }
        public int AnswerCount { get; set; }
        public List<Option> Options { get; set; }
    }
}