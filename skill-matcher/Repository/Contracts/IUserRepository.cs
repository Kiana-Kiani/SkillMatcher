using SkillMatcher.DataModel;
using SkillMatcher.Dto;

namespace SkillMatcher.Repository.Contracts
{
    public interface IUserRepository
    {
        public User InsertFirstInfoBot(User user);
        public User GetUserInfoBot(string telegrmId);
    }
}
