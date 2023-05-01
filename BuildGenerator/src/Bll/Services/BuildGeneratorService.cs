using Bll.Models.BuildTypes;
using Bll.Models.BuildTypes.Enums;
using Bll.RepositoryInterfaces;
using Bll.Services.Interfaces;

namespace Bll.Services;

public class BuildGeneratorService : IBuildGeneratorService
{
    private readonly IHardwareRepository _hardwareRepository;
    
    public BuildGeneratorService(IHardwareRepository hardwareRepository)
    {
        _hardwareRepository = hardwareRepository;
    }
    
    public async Task<GamePcBuild> GenerateGamePcBuild(int budget, CancellationToken token)
    {
        var pcParts = await _hardwareRepository.QueryHardware(token);
        throw new NotImplementedException();
    }
    
    public async Task<GraphicsPcBuild> GenerateGraphicsPcBuild(int budget, CancellationToken token)
    {
        throw new NotImplementedException();
    }
    
    public async Task<ItPcBuild> GenerateItPcBuild(int budget, CancellationToken token)
    {
        throw new NotImplementedException();
    }
    
    public async Task<OfficePcBuild> GenerateOfficePcBuild(int budget, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}