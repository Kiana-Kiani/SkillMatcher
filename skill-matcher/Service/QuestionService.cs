using SkillMatcher.DataModel;
using SkillMatcher.Dto.QuestionOption;
using SkillMatcher.Repository.Interfaces;
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

            question.QuestionText = model.QuestionText;

            question.Level = model.Level;
            question.AnswerCount = model.AnswerCount;
            question.Type = model.Type;
            question.Options = model.Options;

            Question q = questionRepository.InsertQuestion(question);

            return q;
        }

        public List<Question> GetQuestionsByLevelAndTestId(Guid testId, int level)
        {
            List<Question> questions = questionRepository.GetQuestionsByLevelAndTestId(testId, level);
            return questions;
        }

        public bool DeleteQuestionById(Guid id)
        {
            return questionRepository.DeleteQuestionById(id);
        }

        public List<Question> GetQuestionsByTestId(Guid testId)
        {
            var questions = questionRepository.GetQuestionsByTestId(testId);
            return questions;
        }

        public Question GetQuestionById(Guid id)
        {
            Question question = questionRepository.GetQuestionById(id);
            if (question == null)
            {
                return null;
            }
            return question;
        }

        public int UpdateQuestionById(Guid id, PostAndPutQuestionDto questionDto)
        {
            return questionRepository.UpdateQuestionById(id, questionDto);
        }
    }
}

