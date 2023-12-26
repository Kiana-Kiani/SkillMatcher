using SkillMatcher.DataModel;
using SkillMatcher.Dto;
using SkillMatcher.Repository.Contracts;
using SkillMatcher.Service.Interfaces;

namespace SkillMatcher.Service
{
    public class QuestionService : IQuestionService
    {

        IQuestionRepository questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }
        public Question CreateQuestion(Guid testId, PostAndPutQuestionDto model)
        {
            var question = new Question();
           question.TestId = testId;
            question.QuestionText["Persian"] = model.PersianText;
            question.QuestionText["English"] = model.EnglishText;
            question.Level = model.Level;
            question.AnswerCount = model.AnswerCount;
            question.Type = model.Type;
            question.Options = new List<Option>();
            foreach (var optionDto in model.Options)
            {
                var option = new Option();
                option.OptionText["English"] = optionDto.EnglishOptionText;
                option.OptionText["Persian"] = optionDto.PersianOptionText;
                question.Options.Add(option);
            }
            return questionRepository.InsertQuestion(question);
        }

        public List<Question> GetQuestionsByLevelAndTestId(Guid testId, int level)
        {
            return questionRepository.GetQuestionsByLevelAndTestId(testId, level);

        }
        public bool DeleteQuestionById(Guid id)
        {
            return questionRepository.DeleteQuestionById(id);
        }



        public List<Question> GetQuestionsByTestId(Guid testId)
        {
            return questionRepository.GetQuestionsByTestId(testId);
        }
        public Question GetQuestionById(Guid id)
        {
            return questionRepository.GetQuestionById(id);
        }
        public int UpdateQuestionById(Guid id, PostAndPutQuestionDto questionDto)
        {
            return questionRepository.UpdateQuestionById(id, questionDto);
        }

    }
}

