using SkillMatcher.DataModel;
using SkillMatcher.Dto.User;
using SkillMatcher.Enums;
using SkillMatcher.Repository.Contracts;
using SkillMatcher.Service.Interfaces;

namespace SkillMatcher.Service
{
    public class UserService: IUserService
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
            user.PreferredLanguage = userFirstInfoDto.PreferredLanguage.ToString();

            user.GenderType = Gender.NotSelected.ToString();
            user.EducationLevel = Gender.NotSelected.ToString();
            user.EmploymentStatus = Gender.NotSelected.ToString();

            //user.GenderType = userFirstInfoDto.GenderType.ToString();
            //user.EducationLevel = userFirstInfoDto.EducationLevel.ToString();
            //user.EmploymentStatus = userFirstInfoDto.EmploymentStatus.ToString();

            //   return null;

            return userRepository.InsertFirstInfoBot(user);
        }

        public User GetUserInfoBot(string telegrmId)
        {
            return userRepository.GetUserInfoBot(telegrmId);

        }
    }
}
