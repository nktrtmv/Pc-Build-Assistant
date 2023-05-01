using Bll.Services.Interfaces;
using Generator.Requests;
using Generator.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Generator.Controllers;

[Route("[controller]")]
public class PcBuildController : ControllerBase
{
    private readonly IBuildGeneratorService _buildGeneratorService;
    
    public PcBuildController(IBuildGeneratorService buildGeneratorService)
    {
        _buildGeneratorService = buildGeneratorService;
    }
    
    [HttpPost("generate")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BuildGenerationResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GenerateBuild(BuildGenerationRequest request)
    {
        var build = _buildGeneratorService.GenerateBuild(request.Budget, request.Type);
        return build switch
        {
            null => BadRequest("Unknown error"),
            _ => Ok(build)
        };
    }
}