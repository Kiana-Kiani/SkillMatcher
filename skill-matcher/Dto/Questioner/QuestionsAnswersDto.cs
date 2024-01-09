using SkillMatcher.DataModel;

namespace SkillMatcher.Dto.Questioner
{
    public class QuestionsAnswersDto
    {
        public List<string> Answers { get; set; } = new List<string>();
        public List<Question> Questions { get; set; } = new List<Question>();


    //    public List<int> OptionNo { get; set; } = new List<int>();

    }
}
