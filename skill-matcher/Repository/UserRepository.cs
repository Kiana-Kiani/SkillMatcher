using MongoDB.Driver;
using SkillMatcher.DataModel;
using SkillMatcher.Repository.Interfaces;

namespace SkillMatcher.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDatabase db;
        private readonly IMongoCollection<User> UserCollection;
        private readonly IConfiguration configuration;

        public UserRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            var connectionString = configuration.GetConnectionString("MongoDb");
            var client = new MongoClient(connectionString);
            db = client.GetDatabase("JobOffererTest");
            UserCollection = db.GetCollection<User>("Users");
        }

        public User InsertFirstInfoBot(User user)
        {
            user.TelegramId = user.TelegramId.ToLower();
            var filter = Builders<User>.Filter.Eq(u => u.TelegramId, user.TelegramId);
            var userWithTelegramId = UserCollection.Find(filter).FirstOrDefault();

            if (userWithTelegramId == null)
            {
                UserCollection.InsertOne(user);
                return user;
            }
            else
            {
                return null;
            }
        }

        public User GetUserInfoBot(string telegramId)
        {
            try
            {
                var filter = Builders<User>.Filter.Eq(q => q.TelegramId, telegramId);
                var user = UserCollection.Find(filter).FirstOrDefault();
                return user;
            }
            catch
            {
                return null;
            }
        }
    }
}
