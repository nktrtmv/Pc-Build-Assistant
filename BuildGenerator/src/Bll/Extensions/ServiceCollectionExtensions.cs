using Bll.Services;
using Bll.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Bll.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBll(this IServiceCollection services)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
        services.AddTransient<IBuildGeneratorService, BuildGeneratorService>();
        
        return services;
    }
}
