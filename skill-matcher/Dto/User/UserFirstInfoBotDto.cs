using SkillMatcher.Enums;

namespace SkillMatcher.Dto.User
{
    public class UserFirstInfoBotDto
    {
        //  public Guid Id { get; set; } 
        public string Name { get; set; }
        public Language PreferredLanguage { get; set; }
        public string TelegramId { get; set; }
    }
}
