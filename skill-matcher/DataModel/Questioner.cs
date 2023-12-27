﻿using MongoDB.Bson.Serialization.Attributes;

namespace SkillMatcher.DataModel
{
    public class Questioner
    {
        [BsonId]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime StartedDateTime { get; set; }
        public List<QuestionerContent> Chat { get; set; }
        public List<QuestionerResult> Result { get; set; }
    }

    public class QuestionerContent
    {
        public Question Questions { get; set; } 
        public string Answers { get; set; } 
    }

    public class QuestionerResult
    {
        public string Result { get; set; }
        public bool IsFinalResult { get; set; }
        public string UserScore { get; set; }
    }
}