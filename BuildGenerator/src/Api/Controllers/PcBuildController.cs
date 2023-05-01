using Bll.Commands;
using Bll.Models;
using Bll.Services.Interfaces;
using Generator.Requests;
using Generator.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Generator.Controllers;

[Route("[controller]")]
public class PcBuildController : ControllerBase
{
    private readonly IMediator _mediator;

    public PcBuildController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("generate")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BuildGenerationResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GenerateBuild(
        BuildGenerationRequest request,
        CancellationToken token)
    {
        var generateBuildResult = await _mediator.Send(new GenerateBuildCommand(request.Budget, request.Type), token);

        if (generateBuildResult.Build is null)
        {
            return BadRequest("Unknown error");
        }


        return Ok(generateBuildResult.Build);
    }
}