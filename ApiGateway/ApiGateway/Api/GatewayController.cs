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
        using var httpClient = new HttpClient();

        using var response = await httpClient.PostAsJsonAsync("https://localhost:7024/PcBuild/generate", request);
        
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
    public Task<PcBuild> GetBuild(Guid id)
    {
        return Task.FromResult(_database.GetBuild(id));
    }
}