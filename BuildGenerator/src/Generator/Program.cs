using Microsoft.AspNetCore.Mvc;
using Generator.BuildTypes;
using Generator.Hardware;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/gen-build/{budget:int}/{type}", (int budget, string type) =>
{
    IBuild? build = type switch
    {
        "gaming" => new GameBuild(budget),
        "graphics" => new GraphicsBuild(budget),
        "it" => new ItBuild(budget),
        "office" => new OfficeBuild(budget),
        var _ => null
    };

    return build == null ? Results.Problem("error") : Results.Ok(build);
});

app.Run();