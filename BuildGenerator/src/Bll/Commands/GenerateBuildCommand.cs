using Bll.Models;
using Bll.Models.BuildTypes.Abstractions;
using Bll.Models.BuildTypes.Enums;
using Bll.Services.Interfaces;
using MediatR;

namespace Bll.Commands;

public record GenerateBuildCommand(
    int Budget,
    BuildType Type
) : IRequest<GenerateBuildResult>;

public class GenerateBuildCommandHandler 
    : IRequestHandler<GenerateBuildCommand, GenerateBuildResult>
{
    private readonly IBuildGeneratorService _buildGeneratorService;
    
    public GenerateBuildCommandHandler(
        IBuildGeneratorService buildGeneratorService)
    {
        _buildGeneratorService = buildGeneratorService;
    }
    
    public async Task<GenerateBuildResult> Handle(
        GenerateBuildCommand request,
        CancellationToken cancellationToken)
    {
        PcBuild? build = request.Type switch
        {
            BuildType.GameBuild => await _buildGeneratorService.GenerateGamePcBuild(request.Budget, cancellationToken),
            BuildType.GraphicsBuild => await _buildGeneratorService.GenerateGraphicsPcBuild(request.Budget, cancellationToken),
            BuildType.ItBuild => await _buildGeneratorService.GenerateItPcBuild(request.Budget, cancellationToken),
            BuildType.OfficeBuild => await _buildGeneratorService.GenerateOfficePcBuild(request.Budget, cancellationToken),
            _ => null
        };
        
        return new GenerateBuildResult(build);
    }
}
