using SkillMatcher.Enums;

namespace SkillMatcher.Dto.User
{
    public class UserFirstInfoBotDto
    {
        //  public Guid Id { get; set; } // Unique identifier for the user
        public string Name { get; set; } // User's name for identification and personalization
        public Language PreferredLanguage { get; set; } // Enum representing the user's preferred language for communication
        public string TelegramId { get; set; } // User's name for identification and personalization
     //   public Education EducationLevel { get; set; } // Enum representing the user's level of education
     //   public Gender GenderType { get; set; } // Enum representing the user's gender
      //  public JobStatus EmploymentStatus { get; set; } // Current employment status

    }
}
