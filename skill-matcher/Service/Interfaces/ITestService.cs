using MongoDB.Bson;
using SkillMatcher.DataModel;
using SkillMatcher.Dto.Test;

namespace SkillMatcher.Service.Interfaces
{
    public interface ITestService
    {
        List<TestDto> GetTestList();
        TestDto GetTestById(Guid id);

        Test CreateTest(PostAndPutTestDto testDto);
        bool DeleteTestById(Guid id);
        int UpdateTestById(Guid id, PostAndPutTestDto testDto);
    }
}
