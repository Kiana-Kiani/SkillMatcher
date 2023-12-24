using SkillMatcher.Dto;

namespace SkillMatcher.Service.Interfaces
{
    public interface ITestService
    {
        List<TestDto> GetTestList();
        bool CreateTest(TestDto testDto);
        bool DeleteTestById(string id);
        int UpdateTestById(string id, TestDto testDto);
    }
}
