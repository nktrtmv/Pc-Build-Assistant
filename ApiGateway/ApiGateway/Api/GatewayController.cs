using ApiGateway.Dal;
using ApiGateway.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Api;

public class GatewayController : ControllerBase
{
    private readonly IDatabase _database;

    public GatewayController(IDatabase db)
    {
        _database = db;
    }


    [HttpPost("/generate-build/")]
    public async Task<IActionResult> GenerateBuild([FromBody] BuildGenerationRequest request)
    {
        switch (request.Type)
        {
            case BuildType.GameBuild or BuildType.GraphicsBuild when
                request.Budget is < 50000 or > 400000:
                return BadRequest(
                    "Invalid budget, minimum budget for this type of build is 50000 and maximum is 400000");
            case BuildType.OfficeBuild or BuildType.ItBuild when request.Budget is < 30000 or > 400000:
                return BadRequest(
                    "Invalid budget, minimum budget for this type of build is 30000 and maximum is 400000");
        }

        if (request.Type != BuildType.GameBuild && request.Type != BuildType.GraphicsBuild &&
            request.Type != BuildType.OfficeBuild && request.Type != BuildType.ItBuild)
        {
            return BadRequest("Invalid build type");
        }

        using var httpClient = new HttpClient();

        using var response = await httpClient.PostAsJsonAsync("http://build_generator/PcBuild/generate", request);

        var buildGenerationResponse = await response.Content.ReadFromJsonAsync<BuildGenerationResponse>();

        var id = _database.SaveBuild(buildGenerationResponse!.PcBuild);

        return Ok(
            new GenerateBuildResponse(
                buildGenerationResponse.PcBuild,
                buildGenerationResponse.TotalPrice,
                id)
        );
    }

    [HttpGet("/get-build/{id:guid}")]
    public IActionResult GetBuild(Guid id)
    {
        var build = _database.GetBuild(id);

        if (build is null)
        {
            return NotFound("There is no build with the specified id");
        }

        return Ok(
            new BuildGenerationResponse(
                build,
                build.Cpu.Price + build.Motherboard.Price + build.Ram.Price + build.Storage.Price +
                build.PowerSupply.Price + build.Case.Price + build.Cooler.Price + (build.Gpu?.Price ?? 0))
        );
    }
}