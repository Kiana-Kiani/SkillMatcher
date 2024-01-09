using SkillMatcher.DataModel;
using SkillMatcher.Dto.Questioner;
using SkillMatcher.Dto.QuestionOption;

namespace SkillMatcher.Repository.Interfaces
{
    public interface IQuestionerRepository
    {
        public Guid InsertQuestionAnswer(QuestionAndAnswerDto questionAndAnswerDto);
        public Guid InsertUserId(Questioner questioner);
       public List<ReportText> CreateReport(Guid userId, Guid questionerId, ReportListFromUIDto reportListFromUIDto, List<ReportText> repo);
          public QuestionsAnswersDto GetQuestionsAnswers(Guid questionerId);
      //  public Dictionary<Question, string> GetQuestionsAnswers(Guid questionerId);
    }
}
