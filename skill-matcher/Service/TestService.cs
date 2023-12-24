using SkillMatcher.DataModel;
using SkillMatcher.Dto;
using SkillMatcher.Repository.Contracts;
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
        public List<TestDto> GetTestList()
        {

            var tests = testRepository.GetTestList();
            var testDto = new List<TestDto>();
            foreach (var item in tests)
            {
                testDto.Add(new TestDto() { Id = item.Id, Name = item.Name, DateTime = item.DateTime, Level = item.Level, About = item.About });
            }
            return testDto;
        }
        public bool CreateTest(TestDto model)
        {
            Test test = new Test()
            {
                Id = model.Id,
                Name = model.Name,
                About = model.About,
                Level = model.Level,
                DateTime = DateTime.Now
            };

            return testRepository.CreateTest(test);
        }
        public bool DeleteTestById(string id)
        {
            return testRepository.DeleteTestById(id);
        }
        public int UpdateTestById(string id, TestDto testDto)
        {
            return testRepository.UpdateTestById(id, testDto);
        }
    }
}

