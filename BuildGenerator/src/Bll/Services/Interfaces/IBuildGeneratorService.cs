using Bll.Models.BuildTypes;
using Bll.Models.BuildTypes.Enums;

namespace Bll.Services.Interfaces;

public interface IBuildGeneratorService
{
    Task<GamePcBuild> GenerateGamePcBuild(int budget, CancellationToken token);

    Task<GraphicsPcBuild> GenerateGraphicsPcBuild(int budget, CancellationToken token);

    Task<ItPcBuild> GenerateItPcBuild(int budget, CancellationToken token);

    Task<OfficePcBuild> GenerateOfficePcBuild(int budget, CancellationToken token);
}