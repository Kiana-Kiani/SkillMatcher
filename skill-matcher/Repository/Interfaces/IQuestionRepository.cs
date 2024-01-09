using SkillMatcher.DataModel;
using SkillMatcher.Dto.QuestionOption;

namespace SkillMatcher.Repository.Interfaces
{
    public interface IQuestionRepository
    {
        Question InsertQuestion(Question question);
        Question GetQuestionById(Guid id);
        List<Question> GetQuestionsByTestId(Guid testId);
        List<Question> GetQuestionsByLevelAndTestId(Guid testId, int level);
        bool DeleteQuestionById(Guid id);
        int UpdateQuestionById(Guid id, PostAndPutQuestionDto question);
    }
}