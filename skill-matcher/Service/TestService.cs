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
        public List<Test> GetTestList()
        {
            List<Test> tests = testRepository.GetTestList();
            foreach (Test test in tests)
            {
                test.DateTime = ConvertToTehranTime(test.DateTime);

            }
            // var testDto = new List<TestDto>();
            //foreach (var item in tests)
            //{
            //    testDto.Add(new TestDto() { Id = item.Id, Name = item.Name, DateTime = item.DateTime, Level = item.Level, About = item.About });
            //}
            return tests;
        }
        public Test GetTestById(Guid id)
        {
            Test test = testRepository.GetTestById(id);
            test.DateTime = ConvertToTehranTime(test.DateTime);
            if (test == null)
            {
                return null;
            }
            //var testDto = new TestDto()
            //{
            //    Id = test.Id,
            //    Name = test.Name,
            //    About = test.About,
            //    Level = test.Level,
            //    DateTime = test.DateTime,


            //};
            return test;
        }

        public Test CreateTest(PostAndPutTestDto testDto)
        {
            Test test = new Test()
            {
                Name = testDto.Name,
                About = testDto.About,
                Level = testDto.Level,
                DateTime = DateTime.UtcNow
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

        public DateTime ConvertToTehranTime(DateTime utcDateTime)
        {
            var tehranTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Tehran");
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, tehranTimeZone);
        }
    }
}

