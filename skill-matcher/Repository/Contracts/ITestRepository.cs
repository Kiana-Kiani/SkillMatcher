using SkillMatcher.DataModel;
using SkillMatcher.Dto.Test;

namespace SkillMatcher.Repository.Contracts
{
    public interface ITestRepository
    {
        List<Test> GetTestList();
        Test GetTestById(Guid id);
        Test CreateTest(Test test);
        bool DeleteTestById(Guid id);
        int UpdateTestById(Guid id, PostAndPutTestDto testDto);
    }
}