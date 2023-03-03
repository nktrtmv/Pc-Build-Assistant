using Generator.Bll.Models.BuildTypes;
using Generator.Bll.Models.BuildTypes.Enums;
using Generator.Bll.Models.BuildTypes.Interfaces;
using Generator.Bll.Services.Interfaces;

namespace Generator.Bll.Services;

public class BuildGeneratorService : IBuildGeneratorService
{
    public IBuild? GenerateBuild(int budget, BuildType type) => type switch
    {
        BuildType.GameBuild => new GameBuild(budget),
        BuildType.GraphicsBuild => new GraphicsBuild(budget),
        BuildType.ItBuild => new ItBuild(budget),
        BuildType.OfficeBuild => new OfficeBuild(budget),
        _ => null
    };
}