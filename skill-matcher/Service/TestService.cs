using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using SkillMatcher.DataModel;
using SkillMatcher.Repository.Contracts;
using SkillMatcher.Service.Interfaces;
using static System.Net.Mime.MediaTypeNames;
using SkillMatcher.Dto.Test;

namespace SkillMatcher.Service
{
    public class TestService : ITestService
    {

        ITestRepository testRepository;
        public TestService(ITestRepository testRepository)
        {
            this.testRepository = testRepository;
        }
        public List<TestDto> GetTestList()
        {
            //BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
            //BsonDefaults.GuidRepresentationMode = GuidRepresentationMode.V3;

            var tests = testRepository.GetTestList();
            var testDto = new List<TestDto>();
            foreach (var item in tests)
            {
                testDto.Add(new TestDto() { Id = item.Id, Name = item.Name, DateTime = item.DateTime, Level = item.Level, About = item.About });
            }
            return testDto;
        }
        public TestDto GetTestById(Guid id)
        {
            var test = testRepository.GetTestById(id);
            if (test == null)
            {
                return null;
            }
            var testDto = new TestDto()
            {
                Id = test.Id,
                Name = test.Name,
                About = test.About,
                Level = test.Level,
                DateTime = test.DateTime,


            };
            return testDto;
        }

        public Test CreateTest(PostAndPutTestDto model)
        {
            Test test = new Test()
            {
             //   Id = Guid.NewGuid(),
                Name = model.Name,
                About = model.About,
                Level = model.Level,
                DateTime = DateTime.Now
            };

            return testRepository.CreateTest(test);
        }
        public bool DeleteTestById(Guid id)
        {
            return testRepository.DeleteTestById(id);
        }
        public int UpdateTestById(Guid id, PostAndPutTestDto testDto)
        {
            return testRepository.UpdateTestById(id, testDto);
        }

       
    }
}

