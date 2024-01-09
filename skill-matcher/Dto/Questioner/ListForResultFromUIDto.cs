using SkillMatcher.DataModel;
using SkillMatcher.Dto.QuestionOption;

namespace SkillMatcher.Dto.Questioner
{
    public class ListForResultFromUIDto
    {
      //  public string ResultStr { get; set; }
        //public bool IsFinalResult { get; set; }
        //public string  UserComment { get; set; }
        public List<Option> Answers { get; set; } = new List<Option>();
        public List<int> OptionNo { get; set; } = new List<int>();

        public List<Question> Questions { get; set; } = new List<Question>();

    }
}
