using SkillMatcher.DataModel;
using SkillMatcher.Dto;

namespace SkillMatcher.Service.Interfaces
{
    public interface IQuestionService
    {
        Guid CreateQuestion(PostAndPutQuestionDto question);
        List<Question> GetQuestionsByTestId(Guid testId);
        bool DeleteQuestionById(Guid id);

        int UpdateQuestionById(Guid id, PostAndPutQuestionDto question);
    }
}










