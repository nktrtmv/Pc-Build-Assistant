using Generator.Bll.Models.BuildTypes;
using Generator.Bll.Models.BuildTypes.Enums;
using Generator.Bll.Models.BuildTypes.Interfaces;

namespace Generator.Bll.Services.Interfaces;

public interface IBuildGeneratorService
{
    public IBuild? GenerateBuild(int budget, BuildType type);
}