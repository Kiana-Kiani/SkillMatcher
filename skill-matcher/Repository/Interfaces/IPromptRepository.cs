using SkillMatcher.DataModel;
using SkillMatcher.Dto.Prompt;

namespace SkillMatcher.Repository.Interfaces
{
    public interface IPromptRepository
    {
        public Prompt GetPromptById(Guid id);
        public List<Prompt> GetPrompts();
        public Prompt CreatePrompt(PromptDto promptDto);

        public bool UpdatePrompt(Guid id, PromptDto promptDto);
        public bool DeletePrompt(Guid id);
    }
}
