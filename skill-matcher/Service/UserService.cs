using SkillMatcher.DataModel;
using SkillMatcher.Dto.User;
using SkillMatcher.Enums;
using SkillMatcher.Repository.Interfaces;
using SkillMatcher.Service.Interfaces;

namespace SkillMatcher.Service
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User InsertFirstInfoBot(UserFirstInfoBotDto userFirstInfoDto)
        {
            User user = new User();

            user.TelegramId = userFirstInfoDto.TelegramId;
            user.CreatedAt = DateTime.Now;
            user.Name = userFirstInfoDto.Name;
            user.PreferredLanguage = userFirstInfoDto.PreferredLanguage;

            user.GenderType = Gender.NotSelected;
            user.EducationLevel = Education.NotSelected;
            user.EmploymentStatus = JobStatus.NotSelected;

            return userRepository.InsertFirstInfoBot(user);
        }

        public User GetUserInfoBot(string telegramId)
        {
            return userRepository.GetUserInfoBot(telegramId);
        }
    }
}
