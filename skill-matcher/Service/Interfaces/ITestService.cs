using MongoDB.Bson;
using SkillMatcher.Dto;

namespace SkillMatcher.Service.Interfaces
{
    public interface ITestService
    {
        List<TestDto> GetTestList();
        TestDto GetTestById(Guid id);

        Guid CreateTest(PostAndPutTestDto testDto);
        bool DeleteTestById(Guid id);
        int UpdateTestById(Guid id, PostAndPutTestDto testDto);
    }
}
