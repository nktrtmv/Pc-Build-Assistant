using Bll.Extensions;
using Bll.Services;
using Bll.Services.Interfaces;
using Dal.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(o =>
{
    o.CustomSchemaIds(x => x.FullName);
});

builder.Services
    .AddBll();

builder.Services
    .Configure<DalOptions>(builder.Configuration.GetSection(nameof(DalOptions)));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();