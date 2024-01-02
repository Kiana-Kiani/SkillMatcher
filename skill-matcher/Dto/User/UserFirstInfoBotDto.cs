using SkillMatcher.Enums;

namespace SkillMatcher.Dto.User
{
    public class UserFirstInfoBotDto
    {
        public string Name { get; set; }
        public Language PreferredLanguage { get; set; }
        public string TelegramId { get; set; }
    }
}
