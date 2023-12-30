using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SkillMatcher.Enums;

namespace SkillMatcher.DataModel
{
    public class User
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TelegramId { get; set; }


        [BsonRepresentation(BsonType.String)]
        public Education EducationLevel { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Gender GenderType { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Language PreferredLanguage { get; set; }

        [BsonRepresentation(BsonType.String)]
        public JobStatus EmploymentStatus { get; set; }

        //    public JobStatus EmploymentStatus { get; set; } 
        //public Gender GenderType { get; set; } 
        //  public Language PreferredLanguage { get; set; }
        //public Education EducationLevel { get; set; } 
    }
}


