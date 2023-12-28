using SkillMatcher.DataModel;
using SkillMatcher.Dto;
using SkillMatcher.Enums;
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
        public QuestionTypeForUi CreateQuestion(Guid testId, PostAndPutQuestionDto model)
        {
            var question = new Question();
            question.TestId = testId;

            //  question.QuestionText["Persian"] = model.Persian;
            //  question.QuestionText["English"] = model.English;

            question.QuestionText.Persian = model.QuestionText.Persian;
            question.QuestionText.English = model.QuestionText.English;
            question.Level = model.Level;
            question.AnswerCount = model.AnswerCount;
            question.Type = model.Type.ToString();
            question.Options = new List<Option>();
            foreach (var optionDto in model.Options)
            {
                var option = new Option();
                //option.OptionText["English"] = optionDto.English;
                //option.OptionText["Persian"] = optionDto.Persian;
                option.English = optionDto.English;
                option.Persian = optionDto.Persian;

                question.Options.Add(option);
            }

            Question q = questionRepository.InsertQuestion(question);
            QuestionTypeForUi questionTypeForUi = MappQuestionToQuestionTypeForUi(q);
            return questionTypeForUi;
        }

        public List<QuestionTypeForUi> GetQuestionsByLevelAndTestId(Guid testId, int level)
        {
            var questions = questionRepository.GetQuestionsByLevelAndTestId(testId, level);
            List<QuestionTypeForUi> questionsTypeForUi = new List<QuestionTypeForUi>();
            foreach (var question in questions)
            {
                questionsTypeForUi.Add(MappQuestionToQuestionTypeForUi(question));
            }
            return questionsTypeForUi;
        }
        public bool DeleteQuestionById(Guid id)
        {
            return questionRepository.DeleteQuestionById(id);
        }

        public List<QuestionTypeForUi> GetQuestionsByTestId(Guid testId)
        {
            var questions = questionRepository.GetQuestionsByTestId(testId);
            List<QuestionTypeForUi> questionsTypeForUi = new List<QuestionTypeForUi>();
            
            foreach (var question in questions)
            {
                questionsTypeForUi .Add(MappQuestionToQuestionTypeForUi(question));
            }
            return questionsTypeForUi;
        }
        public QuestionTypeForUi GetQuestionById(Guid id)
        {
            Question question = questionRepository.GetQuestionById(id);
            QuestionTypeForUi questionTypeForUi = MappQuestionToQuestionTypeForUi(question);
            return questionTypeForUi;
        }
        public int UpdateQuestionById(Guid id, PostAndPutQuestionDto questionDto)
        {
            return questionRepository.UpdateQuestionById(id, questionDto);
        }


        public QuestionTypeForUi MappQuestionToQuestionTypeForUi(Question question)
        {
            QuestionTypeForUi questionTypeForUi = new QuestionTypeForUi()
            {
                AnswerCount = question.AnswerCount,
                Id = question.Id,
                Level = question.Level,
                Options = question.Options,
                QuestionText = question.QuestionText,
                TestId = question.TestId,
                Type = ConvertStringtoIntQuestionType(question.Type)

            };
            return questionTypeForUi;
        }
        public QuestionType ConvertStringtoIntQuestionType(string typeStr)
        {
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>()
            {
                { "MultipleChoice" , 0 },
                { "Essay" , 1 },
                { "Percent" , 2 }
            };
            return (QuestionType)keyValuePairs[typeStr];


        }

    }
}

