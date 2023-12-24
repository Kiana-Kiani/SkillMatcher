using SkillMatcher.DataModel;
using SkillMatcher.Dto;

namespace SkillMatcher.Repository.Contracts
{
    public interface IQuestionRepository
    {
        bool InsertQuestion(Question question);
        List<Question> GetQuestionsByTestId(string testId);
        bool DeleteQuestionById(string id);
        int UpdateQuestionById(string id, QuestionDto question);
    }
}