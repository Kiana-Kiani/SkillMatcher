using SkillMatcher.DataModel;
using SkillMatcher.Dto.Questioner;
using SkillMatcher.Dto.QuestionOption;
using SkillMatcher.Repository.Contracts;
using SkillMatcher.Service.Interfaces;

namespace SkillMatcher.Service
{
    public class QuestionerService : IQuestionerService
    {
        IQuestionerRepository questionerRepository;

        public QuestionerService(IQuestionerRepository questionerRepository)
        {
            this.questionerRepository = questionerRepository;
        }
        public Guid InsertQuestionAnswer(QuestionAndAnswerFromUiDto questionAndAnswerFromUiDto)
        {
            QuestionAndAnswerDto questionAndAnswerDto = new QuestionAndAnswerDto();

            questionAndAnswerDto.Answers = questionAndAnswerFromUiDto.Answers;
            questionAndAnswerDto.UserId = questionAndAnswerFromUiDto.UserId;
            questionAndAnswerDto.Id = questionAndAnswerFromUiDto.Id;

            questionAndAnswerDto.Questions = questionAndAnswerFromUiDto.Questions;

            return questionerRepository.InsertQuestionAnswer(questionAndAnswerDto);
        }

        public Guid InsertUserId(Guid userId)
        {
            var questioner = new Questioner();

            questioner.UserId = userId;
            questioner.StartedDateTime = DateTime.Now;
            questioner.Chat = new List<QuestionerContent> { new QuestionerContent() };
            questioner.Result = new List<QuestionerResult> { new QuestionerResult() };

            return questionerRepository.InsertUserId(questioner);
        }


    }
}
