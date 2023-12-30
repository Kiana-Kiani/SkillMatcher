using SkillMatcher.DataModel;
using SkillMatcher.Dto.QuestionOption;

namespace SkillMatcher.Service.Interfaces
{
    public interface IQuestionService
    {
        QuestionTypeForUi CreateQuestion(Guid testId, PostAndPutQuestionDto question);
        List<QuestionTypeForUi> GetQuestionsByTestId(Guid testId);
        QuestionTypeForUi GetQuestionById(Guid id);
        List<QuestionTypeForUi> GetQuestionsByLevelAndTestId(Guid testId, int level);
        bool DeleteQuestionById(Guid id);

        int UpdateQuestionById(Guid id, PostAndPutQuestionDto question);
    }
}










