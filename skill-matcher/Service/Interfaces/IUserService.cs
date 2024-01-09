using SkillMatcher.DataModel;
using SkillMatcher.Dto.User;

namespace SkillMatcher.Service.Interfaces
{
    public interface IUserService
    {
        public User InsertFirstInfoBot(UserFirstInfoBotDto userFirstInfoDto);
        public User GetUserInfoBot(string telegramId);
    }
}
