using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SkillMatcher.DataModel;
using SkillMatcher.Dto.Questioner;

namespace SkillMatcher.Service.Interfaces
{
    public interface IQuestionerService
    {
        public Guid InsertQuestionAnswer(QuestionAndAnswerFromUiDto questionAndAnswerDto);
        public Guid InsertUserId(Guid userId);
        public List<ReportText> CreateReport(Guid userId, Guid questionerId, [FromBody] ReportListFromUIDto reportListFromUIDto);
          public QuestionsAnswersDto GetQuestionsAnswers(Guid questionerId);
        //public Dictionary<Question, string> GetQuestionsAnswers(Guid questionerId);
    }
}
