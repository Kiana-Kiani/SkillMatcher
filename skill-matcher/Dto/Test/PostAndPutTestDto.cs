using SkillMatcher.DataModel;

namespace SkillMatcher.Dto.Test
{
    public class PostAndPutTestDto
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string About { get; set; }
   //     public List<RuleFromUIDto> Rule { get; set; } = new List<RuleFromUIDto>();
        public List<DataModel.Rule> Rule { get; set; } = new List<DataModel.Rule>();


    }
}