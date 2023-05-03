using ApiGateway.Api;
using ApiGateway.Dal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDatabase, Database>();

builder.Services.AddHostedService<HardwareDbUpdate>();

builder.Services.AddHttpClient();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();