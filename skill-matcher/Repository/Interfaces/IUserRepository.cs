using SkillMatcher.DataModel;
using SkillMatcher.Dto;

namespace SkillMatcher.Repository.Interfaces
{
    public interface IUserRepository
    {
        public User InsertFirstInfoBot(User user);
        public User GetUserInfoBot(string telegramId);
    }
}
