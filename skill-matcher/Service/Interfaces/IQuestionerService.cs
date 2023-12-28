using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SkillMatcher.Dto;

namespace SkillMatcher.Service.Interfaces
{
    public interface IQuestionerService
    {
        public Guid InsertQuestionAnswer(QuestionAndAnswerFromUiDto questionAndAnswerDto);
        public Guid InsertUserId(Guid userId);
    }
}
