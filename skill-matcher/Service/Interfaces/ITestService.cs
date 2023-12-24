using SkillMatcher.Dto;

namespace SkillMatcher.Service.Interfaces
{
    public interface ITestService
    {
        List<TestDto> GetTestList();
        TestDto GetTest(Guid id);
        Guid CreateTest(TestDto testDto);
        bool DeleteTestById(Guid id);
        int UpdateTestById(Guid id, TestDto testDto);
    }
}
