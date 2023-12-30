using Microsoft.AspNetCore.Mvc;
using SkillMatcher.DataModel;
using SkillMatcher.Dto.Questioner;
using SkillMatcher.Dto.QuestionOption;
using SkillMatcher.Repository;
using SkillMatcher.Repository.Contracts;
using SkillMatcher.Service.Interfaces;

namespace SkillMatcher.Service
{
    public class QuestionerService: IQuestionerService
    {
        IQuestionerRepository questionerRepository;

        public QuestionerService(IQuestionerRepository questionerRepository)
        {
            this.questionerRepository = questionerRepository;
        }
        public Guid InsertQuestionAnswer(QuestionAndAnswerFromUiDto questionAndAnswerFromUiDto)
        {
            //var questioner = new Questioner();
            //questioner.Id = questionAndAnswerDto.Id;
            //questioner.UserId = questionAndAnswerDto.UserId;
            //questioner.Chat = new List<QuestionerContent>();


            //QuestionerContent questionerContent = new QuestionerContent();
            //questionerContent.Questions = questionAndAnswerDto.Questions;
            //questionerContent.Answers = questionAndAnswerDto.Answers;

            //questioner.Chat.Add(questionerContent);
            QuestionAndAnswerDto questionAndAnswerDto = new QuestionAndAnswerDto();

            questionAndAnswerDto.Answers = questionAndAnswerFromUiDto.Answers;
            questionAndAnswerDto.UserId = questionAndAnswerFromUiDto.UserId;
            questionAndAnswerDto.Id = questionAndAnswerFromUiDto.Id;

            questionAndAnswerDto.Questions = new Question();
            questionAndAnswerDto.Questions.AnswerCount = questionAndAnswerFromUiDto.Questions.AnswerCount;
            questionAndAnswerDto.Questions.Options = questionAndAnswerFromUiDto.Questions.Options;
            questionAndAnswerDto.Questions.QuestionText = questionAndAnswerFromUiDto.Questions.QuestionText;
            questionAndAnswerDto.Questions.TestId = questionAndAnswerFromUiDto.Questions.TestId;
            questionAndAnswerDto.Questions.Level = questionAndAnswerFromUiDto.Questions.Level;
            questionAndAnswerDto.Questions.Type = questionAndAnswerFromUiDto.Questions.Type.ToString();
            questionAndAnswerDto.Questions.Id = questionAndAnswerFromUiDto.Questions.Id;

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
