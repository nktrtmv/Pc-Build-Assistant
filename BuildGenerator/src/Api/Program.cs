using Bll.Extensions;
using Dal.Extensions;
using FluentValidation.AspNetCore;
using Generator.NamingPolicies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = new SnakeCaseNamingPolicy();
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(o =>
{
    o.CustomSchemaIds(x => x.FullName);
});

builder.Services.AddFluentValidation(conf =>
{
    conf.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
    conf.AutomaticValidationEnabled = true;
});

builder.Services
    .AddBll()
    .AddDalInfrastructure(builder.Configuration)
    .AddDalRepositories();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.MigrateUp();

var httpClient = new HttpClient();
httpClient.GetAsync("http://hardware_info_collector:3000/fill-db");

app.Run();