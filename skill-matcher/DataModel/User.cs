using MongoDB.Bson.Serialization.Attributes;
using SkillMatcher.Enums;

namespace SkillMatcher.DataModel
{
    public class User
    {
        [BsonId]
        public Guid Id { get; set; } // Unique identifier for the user
        public string Email { get; set; } // Primary contact information for verification and communication
        public string Name { get; set; } // User's name for identification and personalization
        public string Surname { get; set; } // User's surname for identification and personalization
        public DateTime DateOfBirth { get; set; } // Representing the user's date of birth
        public string EducationLevel { get; set; } // Enum representing the user's level of education
        //public Education EducationLevel { get; set; } // Enum representing the user's level of education
        public string TelegramId { get; set; } // Containing the user's Telegram ID
        public string GenderType { get; set; } // Enum representing the user's gender
        //public Gender GenderType { get; set; } // Enum representing the user's gender
        public DateTime CreatedAt { get; set; }  // Date and time the user account was created (Set by default)
      //  public Language PreferredLanguage { get; set; } // Enum representing the user's preferred language for communication
        public string PreferredLanguage { get; set; } // Enum representing the user's preferred language for communication
        public string EmploymentStatus { get; set; } // Current employment status
    //    public JobStatus EmploymentStatus { get; set; } // Current employment status
    }
}


