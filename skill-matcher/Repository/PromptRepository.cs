using MongoDB.Driver;
using SkillMatcher.DataModel;
using SkillMatcher.Dto.Prompt;
using SkillMatcher.Repository.Interfaces;

namespace SkillMatcher.Repository
{
    public class PromptRepository : IPromptRepository
    {
        private readonly IMongoDatabase db;
        private readonly IMongoCollection<Prompt> PromptsCollection;
        private readonly IConfiguration configuration;

        public PromptRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            var connectionString = configuration.GetConnectionString("MongoDb");
            var client = new MongoClient(connectionString);
            db = client.GetDatabase("JobOffererTest");
            PromptsCollection = db.GetCollection<Prompt>("Prompts");
        }
        public Prompt CreatePrompt(PromptDto promptDto)
        {
            Prompt prompt = new Prompt()
            {
                Text = promptDto.Text,
                Title = promptDto.Title,
                DateTime = DateTime.Now,
            };
            try
            {
                PromptsCollection.InsertOne(prompt);
                return prompt;
            }
            catch (MongoWriteException ex)
            {
                throw new Exception(ex + ". MongoDB error occurred while inserting prompt: " + promptDto.Text); // Rethrow for further handling
            }
            catch (Exception ex)
            {
                throw new Exception(ex + ". An unexpected error occurred while inserting prompt: " + promptDto.Text); // Rethrow for further handling
            }
        }

        public bool DeletePrompt(Guid id)
        {
            var filter = Builders<Prompt>.Filter.Eq(q => q.Id, id);

            var result = PromptsCollection.DeleteOne(filter);

            if (result.DeletedCount == 0)
                return false;
            else
                return true;
        }

        public Prompt GetPromptById(Guid id)
        {
            var filter = Builders<Prompt>.Filter.Eq(q => q.Id, id);

            try
            {
                var prompt = PromptsCollection.Find(filter).FirstOrDefault();
                return prompt;
            }
            catch (MongoWriteException ex)
            {
                throw new Exception(ex + ". MongoDB error occurred while Get Prompt By ID: " + id); // Rethrow for further handling
            }
            catch (Exception ex)
            {
                throw new Exception(ex + ". An unexpected error occurred while Get Prompt By ID: " + id); // Rethrow for further handling
            }

        }

        public List<Prompt> GetPrompts()
        {
            try
            {
                List<Prompt> prompts = PromptsCollection.Find(_ => true).ToList();
                return prompts;
            }
            catch (MongoWriteException ex)
            {
                throw new Exception(ex + ". MongoDB error occurred while Get Prompts "); // Rethrow for further handling
            }
            catch (Exception ex)
            {
                throw new Exception(ex + ". An unexpected error occurred while Get Prompts "); // Rethrow for further handling
            }
        }

        public bool UpdatePrompt(Guid id, PromptDto promptDto)
        {
            var filter = Builders<Prompt>.Filter.Eq(q=>q.Id, id);
            var update = Builders<Prompt>.Update.Set(q => q.Text,promptDto.Text).Set(q=>q.Title,promptDto.Title);

            Prompt prompt = PromptsCollection.Find(filter).FirstOrDefault();
            if (prompt == null)
            {
                throw new Exception("Not Found This Id.");
            }
            var result = PromptsCollection.UpdateOne(filter, update);

            if (result.ModifiedCount == 1 || result.MatchedCount == 1)
                return true;
            else
                return false;
        }
    }
}
