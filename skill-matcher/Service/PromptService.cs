using SkillMatcher.DataModel;
using SkillMatcher.Dto.Prompt;
using SkillMatcher.Repository.Interfaces;
using SkillMatcher.Service.Interfaces;

namespace SkillMatcher.Service
{
    public class PromptService : IPromptService
    {
        IPromptRepository PromptRepository;
        public PromptService(IPromptRepository PromptRepository)
        {
            this.PromptRepository = PromptRepository;
        }

        public Prompt CreatePrompt(PromptDto promptDto)
        {
            try
            {
                return PromptRepository.CreatePrompt(promptDto);

            }
            catch (Exception ex)
            {
                // Propagate the exception with a meaningful message
                throw new Exception(ex.Message);
            }
        }

        public bool DeletePrompt(Guid id)
        {
            return PromptRepository.DeletePrompt(id);
        }

        public Prompt GetPromptById(Guid id)
        {
            try
            {
                return PromptRepository.GetPromptById(id);
            }
            catch (Exception ex)
            {
                // Propagate the exception with a meaningful message
                throw new Exception(ex.Message);
            }
        }

        public List<Prompt> GetPrompts()
        {
            try
            {
                return PromptRepository.GetPrompts();

            }
            catch (Exception ex)
            {
                // Propagate the exception with a meaningful message
                throw new Exception(ex.Message);
            }
        }

        public bool UpdatePrompt(Guid id, PromptDto promptDto)
        {
            try
            {
                return PromptRepository.UpdatePrompt(id, promptDto);

            }
            catch (Exception ex)
            {
                // Propagate the exception with a meaningful message
                throw new Exception(ex.Message);
            }
        }
    }
}
