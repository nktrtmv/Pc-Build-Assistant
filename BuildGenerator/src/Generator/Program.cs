using Microsoft.AspNetCore.Mvc;
using Generator.BuildTypes;
using Generator.Hardware;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/gen-build/{budget:int}/{type}", (int budget, string type) =>
{
    IBuild? build = null;
    if (type == "gaming")
    {
        build = new GameBuild(budget);
    }
    else if (type == "graphics")
    {
        build = new GraphicsBuild(budget);
    }
    else if (type == "it")
    {
        build = new ItBuild(budget);
    }
    else if (type == "office")
    {
        build = new OfficeBuild(budget);
    }

    return build == null ? Results.Problem("error") : Results.Ok(build);
});

app.Run();