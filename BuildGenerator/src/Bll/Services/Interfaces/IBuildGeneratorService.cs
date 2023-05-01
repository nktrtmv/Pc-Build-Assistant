using Bll.Models.BuildTypes.Enums;
using Bll.Models.BuildTypes.Interfaces;

namespace Bll.Services.Interfaces;

public interface IBuildGeneratorService
{
    public IBuild? GenerateBuild(int budget, BuildType type);
}