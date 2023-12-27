using SkillMatcher.DataModel;
using SkillMatcher.Dto;
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
        public Guid InsertQuestionAnswer(QuestionAndAnswerDto questionAndAnswerDto)
        {
            //var questioner = new Questioner();
            //questioner.Id = questionAndAnswerDto.Id;
            //questioner.UserId = questionAndAnswerDto.UserId;
            //questioner.Chat = new List<QuestionerContent>();


            //QuestionerContent questionerContent = new QuestionerContent();
            //questionerContent.Questions = questionAndAnswerDto.Questions;
            //questionerContent.Answers = questionAndAnswerDto.Answers;

            //questioner.Chat.Add(questionerContent);

            return questionerRepository.InsertQuestionAnswer(questionAndAnswerDto);
        }
        public Guid InsertUserId(Guid userId)
        {


            var questioner = new Questioner();

            questioner.UserId = userId;
            questioner.StartedDateTime = DateTime.Now;
            questioner.Chat = new List<QuestionerContent> { new QuestionerContent() };

            return questionerRepository.InsertUserId(questioner);

        }


    }
}
