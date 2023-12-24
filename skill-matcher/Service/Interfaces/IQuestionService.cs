using SkillMatcher.DataModel;
using SkillMatcher.Dto;

namespace SkillMatcher.Service.Interfaces
{
    public interface IQuestionService
    {
        bool CreateQuestion(QuestionDto question);
        List<Question> GetQuestionsByTestId(string testId);
        bool DeleteQuestionById(string id);

        int UpdateQuestionById(string id, QuestionDto question);
    }
}










