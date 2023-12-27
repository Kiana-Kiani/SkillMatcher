using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SkillMatcher.Dto;

namespace SkillMatcher.Service.Interfaces
{
    public interface IQuestionerService
    {
        public Guid InsertQuestionAnswer(QuestionAndAnswerDto questionAndAnswerDto);
        public Guid InsertUserId(Guid userId);
    }
}
