using SkillMatcher.DataModel;
using SkillMatcher.Dto;

namespace SkillMatcher.Repository.Contracts
{
    public interface IQuestionerRepository
    {
        public Guid InsertQuestionAnswer(QuestionAndAnswerDto questionAndAnswerDto);
        public Guid InsertUserId(Questioner questioner);
    }
}
