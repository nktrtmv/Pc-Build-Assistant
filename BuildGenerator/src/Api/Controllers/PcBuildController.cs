using Bll.Commands;
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
        try
        {
            var generateBuildResult = await _mediator.Send(
                new GenerateBuildCommand(request.Budget, request.Type),
                token);
            if (generateBuildResult.Build is null)
            {
                return BadRequest("Unknown error");
            }

            var pcBuild = new PcBuild(
                new Hardware(
                    generateBuildResult.Build.Cpu.Price,
                    generateBuildResult.Build.Cpu.Link,
                    generateBuildResult.Build.Cpu.Model),
                new Hardware(
                    generateBuildResult.Build.Motherboard.Price,
                    generateBuildResult.Build.Motherboard.Link,
                    generateBuildResult.Build.Motherboard.Model),
                new Hardware(
                    generateBuildResult.Build.Case.Price,
                    generateBuildResult.Build.Case.Link,
                    generateBuildResult.Build.Case.Model),
                generateBuildResult.Build.Gpu is null
                    ? null
                    : new Hardware(
                        generateBuildResult.Build.Gpu.Price,
                        generateBuildResult.Build.Gpu.Link,
                        generateBuildResult.Build.Gpu.Model),
                new Hardware(
                    generateBuildResult.Build.Cooler.Price,
                    generateBuildResult.Build.Cooler.Link,
                    generateBuildResult.Build.Cooler.Model),
                new Hardware(
                    generateBuildResult.Build.Ram.Price,
                    generateBuildResult.Build.Ram.Link,
                    generateBuildResult.Build.Ram.Model),
                new Hardware(
                    generateBuildResult.Build.Storage.Price,
                    generateBuildResult.Build.Storage.Link,
                    generateBuildResult.Build.Storage.Model),
                new Hardware(
                    generateBuildResult.Build.PowerSupply.Price,
                    generateBuildResult.Build.PowerSupply.Link,
                    generateBuildResult.Build.PowerSupply.Model)
            );

            var totalPrice = pcBuild.Price();

            var response = new BuildGenerationResponse(
                pcBuild,
                totalPrice
            );
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}