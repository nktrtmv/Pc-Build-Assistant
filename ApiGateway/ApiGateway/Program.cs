using ApiGateway.Api;
using ApiGateway.Dal;

var builder = WebApplication.CreateBuilder(args);

var  gatewayOrigins = "_gatewayOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: gatewayOrigins,
        policy  =>
        {
            policy.WithOrigins(
                "http://localhost:63342"
            ).AllowAnyHeader().AllowAnyMethod();
        });
});


builder.Services.AddSingleton<IDatabase, Database>();

builder.Services.AddHostedService<HardwareDbUpdate>();

builder.Services.AddHttpClient();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(gatewayOrigins);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
