using Generator.Bll.Models.BuildTypes;
using Generator.Bll.Models.BuildTypes.Enums;
using Generator.Bll.Models.BuildTypes.Interfaces;
using Generator.Bll.Services.Interfaces;

namespace Generator.Bll.Services;

public class BuildGeneratorService : IBuildGeneratorService
{
    public IBuild? GenerateBuild(int budget, BuildType type) => type switch
    {
        BuildType.GameBuild => GenerateGameBuild(budget),
        BuildType.GraphicsBuild => GenerateGraphicsBuild(budget),
        BuildType.ItBuild => GenerateItBuild(budget),
        BuildType.OfficeBuild => GenerateOfficeBuild(budget),
        _ => null
    };
    
    private static GameBuild GenerateGameBuild(int budget)
    {
        var build = new GameBuild(budget);
        return build;
    }
    
    private static GraphicsBuild GenerateGraphicsBuild(int budget)
    {
        var build = new GraphicsBuild(budget);
        return build;
    }
    
    private static ItBuild GenerateItBuild(int budget)
    {
        var build = new ItBuild(budget);
        return build;
    }
    
    private static OfficeBuild GenerateOfficeBuild(int budget)
    {
        var build = new OfficeBuild(budget);
        return build;
    }
}