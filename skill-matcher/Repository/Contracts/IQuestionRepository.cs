using SkillMatcher.DataModel;
using SkillMatcher.Dto;

namespace SkillMatcher.Repository.Contracts
{
    public interface IQuestionRepository
    {
        Guid InsertQuestion(Question question);
        List<Question> GetQuestionsByTestId(Guid testId);
        bool DeleteQuestionById(Guid id);
        int UpdateQuestionById(Guid id, PostAndPutQuestionDto question);
    }
}