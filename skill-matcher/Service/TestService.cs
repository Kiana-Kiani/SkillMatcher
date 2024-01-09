using SkillMatcher.DataModel;
using SkillMatcher.Dto.Test;
using SkillMatcher.Repository.Interfaces;
using SkillMatcher.Service.Interfaces;

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

