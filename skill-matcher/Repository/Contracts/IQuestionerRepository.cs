using Microsoft.AspNetCore.Mvc;
using SkillMatcher.DataModel;
using SkillMatcher.Dto.Questioner;
using SkillMatcher.Dto.QuestionOption;

namespace SkillMatcher.Repository.Contracts
{
    public interface IQuestionerRepository
    {
        public Guid InsertQuestionAnswer(QuestionAndAnswerDto questionAndAnswerDto);
        public Guid InsertUserId(Questioner questioner);
    }
}
