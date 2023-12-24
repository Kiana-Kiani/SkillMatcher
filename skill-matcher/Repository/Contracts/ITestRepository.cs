using SkillMatcher.DataModel;
using SkillMatcher.Dto;

namespace SkillMatcher.Repository.Contracts
{
    public interface ITestRepository
    {
        List<Test> GetTestList();
        Test GetTestById(Guid id);
        Guid CreateTest(Test test);
        bool DeleteTestById(Guid id);
        int UpdateTestById(Guid id, PostAndPutTestDto testDto);
    }
}