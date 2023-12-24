using SkillMatcher.Dto;

namespace SkillMatcher.Service.Interfaces
{
    public interface ITestService
    {
        List<TestDto> GetTestList();
        bool CreateTest(TestDto testDto);
        bool DeleteTestById(Guid id);
        int UpdateTestById(Guid id, TestDto testDto);
    }
}
