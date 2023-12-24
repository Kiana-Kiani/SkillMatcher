using SkillMatcher.Enums;

namespace SkillMatcher.Dto
{
    public class PostAndPutQuestionDto
    {
     //   public ObjectId Id { get; set; }
        public string EnglishText { get; set; }
        public string PersianText { get; set; }
        public QuestionType Type { get; set; }
        public int Level { get; set; }
        public int AnswerCount { get; set; }
        public List<OptionDto> Options { get; set; }
    }
}